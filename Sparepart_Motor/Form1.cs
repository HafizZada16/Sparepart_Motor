using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Text.RegularExpressions;

namespace Sparepart_Motor
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = "Data Source=LAPTOP-ITV1OTU4\\HAFIZ16;Initial Catalog=manajemen_sparepart;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnsureIndexes();
            LoadData();
        }
        private void ClearForm()
        {
            txtId_Pengguna.Clear();
            txtNama.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtTelepon.Clear();
            txtAlamat.Clear();

            txtId_Pengguna.Focus();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "sp_GetAllPengguna";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSparepart.AutoGenerateColumns = true;
                    dgvSparepart.DataSource = dt;

                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnTambah(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (string.IsNullOrEmpty(txtId_Pengguna.Text) || string.IsNullOrEmpty(txtNama.Text) ||
                        string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text) ||
                        string.IsNullOrEmpty(txtTelepon.Text) || string.IsNullOrEmpty(txtAlamat.Text))
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. Validasi ID Pengguna (harus berupa angka)
                    if (!int.TryParse(txtId_Pengguna.Text, out _))
                    {
                        MessageBox.Show("ID Pengguna harus berupa angka.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtId_Pengguna.Focus();
                        return;
                    }

                    // 3. Validasi Nama (tidak boleh mengandung angka atau simbol)
                    if (!Regex.IsMatch(txtNama.Text, @"^[a-zA-Z\s.]+$"))
                    {
                        MessageBox.Show("Nama tidak boleh mengandung angka atau simbol selain titik.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNama.Focus();
                        return;
                    }

                    // 4. Validasi Email (menggunakan metode bawaan .NET yang andal)
                    try
                    {
                        var emailAddress = new System.Net.Mail.MailAddress(txtEmail.Text);
                        if (emailAddress.Address != txtEmail.Text.Trim())
                        {
                            // Ini untuk menangani kasus seperti "  email@example.com  " (spasi di awal/akhir)
                            throw new FormatException();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Format email tidak valid. Pastikan mengandung '@' dan domain (contoh: .com).", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Focus();
                        return;
                    }

                    // 5. Validasi Telepon (hanya boleh angka, spasi, dan simbol + di awal)
                    if (!Regex.IsMatch(txtTelepon.Text, @"^\+?[0-9\s]+$"))
                    {
                        MessageBox.Show("Nomor Telepon hanya boleh mengandung angka, spasi, dan bisa diawali simbol '+'.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTelepon.Focus();
                        return;
                    }

                    conn.Open();
                    string query = "sp_CreatePengguna";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_Pengguna", txtId_Pengguna.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telepon", txtTelepon.Text.Trim());
                        cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Data tidak berhasil ditambahkan!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void BtnHapus(object sender, EventArgs e)
        {
            if (dgvSparepart.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string Id_Pengguna = dgvSparepart.SelectedRows[0].Cells["Id_Pengguna"].Value.ToString();
                            conn.Open();
                            string query = "sp_DeletePengguna";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Id_Pengguna", Id_Pengguna);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData();
                                    ClearForm();
                                }
                                else
                                {
                                    MessageBox.Show("Data tidak ditemukan atau gagal dihapus!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnRefresh(object sender, EventArgs e)
        {
            LoadData();

            MessageBox.Show($"Jumlah Kolom: {dgvSparepart.ColumnCount}\nJumlah Baris: {dgvSparepart.RowCount}",
                "Debugging DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvSparepart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSparepart.Rows[e.RowIndex];

                txtId_Pengguna.Text = row.Cells[0].Value.ToString();
                txtNama.Text = row.Cells[1].Value?.ToString();
                txtEmail.Text = row.Cells[2].Value?.ToString();
                txtPassword.Text = row.Cells[3].Value?.ToString();
                txtTelepon.Text = row.Cells[4].Value?.ToString();
                txtAlamat.Text = row.Cells[5].Value?.ToString();
            }
        }

        private void BtnUbah(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (string.IsNullOrEmpty(txtId_Pengguna.Text) || string.IsNullOrEmpty(txtNama.Text) ||
                        string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text) ||
                        string.IsNullOrEmpty(txtTelepon.Text) || string.IsNullOrEmpty(txtAlamat.Text))
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. Validasi ID Pengguna (harus berupa angka)
                    if (!int.TryParse(txtId_Pengguna.Text, out _))
                    {
                        MessageBox.Show("ID Pengguna harus berupa angka.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtId_Pengguna.Focus();
                        return;
                    }

                    // 3. Validasi Nama (tidak boleh mengandung angka atau simbol)
                    if (!Regex.IsMatch(txtNama.Text, @"^[a-zA-Z\s.]+$"))
                    {
                        MessageBox.Show("Nama tidak boleh mengandung angka atau simbol selain titik.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNama.Focus();
                        return;
                    }

                    // 4. Validasi Email (menggunakan metode bawaan .NET yang andal)
                    try
                    {
                        var emailAddress = new System.Net.Mail.MailAddress(txtEmail.Text);
                        if (emailAddress.Address != txtEmail.Text.Trim())
                        {
                            // Ini untuk menangani kasus seperti "  email@example.com  " (spasi di awal/akhir)
                            throw new FormatException();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Format email tidak valid. Pastikan mengandung '@' dan domain (contoh: .com).", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Focus();
                        return;
                    }

                    // 5. Validasi Telepon (hanya boleh angka, spasi, dan simbol + di awal)
                    if (!Regex.IsMatch(txtTelepon.Text, @"^\+?[0-9\s]+$"))
                    {
                        MessageBox.Show("Nomor Telepon hanya boleh mengandung angka, spasi, dan bisa diawali simbol '+'.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTelepon.Focus();
                        return;
                    }

                    conn.Open();
                    string query = "sp_UpdatePengguna";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_Pengguna", txtId_Pengguna.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telepon", txtTelepon.Text.Trim());
                        cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ditemukan atau gagal diperbarui!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            // 1. Membuat instance baru dari form laporan kita (LaporanPengguna.cs)
            LaporanPengguna formLaporan = new LaporanPengguna();

            // 2. Menampilkan form laporan tersebut
            formLaporan.Show();

            // Alternatif: Gunakan ShowDialog() jika Anda ingin form utama (Form1)
            // tidak bisa di-klik sebelum form laporan ditutup.
            // formLaporan.ShowDialog(); 
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog1.Title = "Pilih file Excel untuk diimpor";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable dt = new DataTable();
                    IWorkbook workbook;

                    using (var stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                    {
                        workbook = WorkbookFactory.Create(stream);
                    }

                    ISheet sheet = workbook.GetSheetAt(0);

                    // --- (Bagian ini sudah benar) Membangun DataTable ---
                    IRow headerRow = sheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum;
                    for (int j = 0; j < cellCount; j++)
                    {
                        ICell cell = headerRow.GetCell(j);
                        dt.Columns.Add(cell?.ToString() ?? $"Column_{j}");
                    }

                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        DataRow dataRow = dt.NewRow();
                        for (int j = 0; j < cellCount; j++)
                        {
                            ICell cell = row.GetCell(j);
                            dataRow[j] = cell?.ToString() ?? string.Empty;
                        }
                        dt.Rows.Add(dataRow);
                    }

                    // --- PERBAIKAN DIMULAI DI SINI ---
                    // 1. Tampilkan PreviewForm dan TANGKAP HASILNYA
                    PreviewForm preview = new PreviewForm(dt, "Pratinjau Impor dari File Excel");
                    DialogResult result = preview.ShowDialog();

                    // 2. PERIKSA APAKAH PENGGUNA MENEKAN TOMBOL "IMPOR DATA"
                    if (result == DialogResult.OK)
                    {
                        // 3. JIKA YA, PANGGIL METODE UNTUK MENYIMPAN KE DATABASE
                        ProsesImportKeDatabase(dt);
                    }
                    // Jika pengguna hanya menutup form (bukan menekan "Impor Data"), tidak terjadi apa-apa.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membaca file Excel. Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // TAMBAHKAN METODE BARU INI DI DALAM KELAS Form1
        private void ProsesImportKeDatabase(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    int jumlahBerhasil = 0;

                    // Loop melalui setiap baris data di DataTable dari pratinjau
                    foreach (DataRow row in dt.Rows)
                    {
                        // Panggil stored procedure untuk membuat pengguna baru
                        using (SqlCommand cmd = new SqlCommand("sp_CreatePengguna", conn))
                        {
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Id_Pengguna", Convert.ToInt32(row["Id_Pengguna"]));
                            cmd.Parameters.AddWithValue("@Nama", row["Nama"].ToString());
                            cmd.Parameters.AddWithValue("@Email", row["Email"].ToString());
                            cmd.Parameters.AddWithValue("@Password", row["Password"].ToString());
                            cmd.Parameters.AddWithValue("@Telepon", row["Telepon"].ToString());
                            cmd.Parameters.AddWithValue("@Alamat", row["Alamat"].ToString());

                            cmd.ExecuteNonQuery();
                            jumlahBerhasil++;
                        }

                    }
                    transaction.Commit();
                    MessageBox.Show($"Proses impor selesai.\nBerhasil: {jumlahBerhasil} baris.", "Impor Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Muat ulang data di tabel utama untuk menampilkan data yang baru diimpor
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan koneksi database: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception rbEx)
                    {
                        // Tangani jika proses rollback itu sendiri gagal
                        MessageBox.Show("Gagal melakukan rollback: " + rbEx.Message);
                    }
                }
                finally
                {
                    // Muat ulang data untuk merefleksikan hasil akhir (sukses atau setelah rollback)
                    LoadData();
                }
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            // Contoh query 'berat' untuk dianalisis, mencari semua pengguna dengan nama berawalan 'A'
            var heavyQuery = "SELECT Nama, Email, Telepon FROM dbo.Pengguna WHERE Nama LIKE 'A%';";
            AnalyzeQuery(heavyQuery);
        }

        private void AnalyzeQuery(string sqlQuery)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                // Menangkap pesan statistik dari SQL Server dan menampilkannya di MessageBox
                conn.InfoMessage += (s, e) => MessageBox.Show(e.Message, "STATISTICS INFO");
                conn.Open();

                // Membungkus query asli dengan perintah SET STATISTICS
                var wrappedQuery = $@"
                    SET STATISTICS IO ON;
                    SET STATISTICS TIME ON;
            
                    {sqlQuery}
            
                    SET STATISTICS IO OFF;
                    SET STATISTICS TIME OFF;";

                using (var cmd = new SqlCommand(wrappedQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void EnsureIndexes()
        {
            // Script T-SQL untuk memeriksa dan membuat indeks jika belum ada
            var indexScript = @"
                IF OBJECT_ID('dbo.Pengguna', 'U') IS NOT NULL
                BEGIN
                    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_Pengguna_Nama')
                        CREATE NONCLUSTERED INDEX idx_Pengguna_Nama ON dbo.Pengguna(Nama);
                    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_Pengguna_Email')
                        CREATE NONCLUSTERED INDEX idx_Pengguna_Email ON dbo.Pengguna(Email);
                END";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(indexScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
