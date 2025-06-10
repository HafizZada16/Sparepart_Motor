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

namespace Sparepart_Motor
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=LAPTOP-ITV1OTU4\\HAFIZ16;Initial Catalog=manajemen_sparepart;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
                    if (txtId_Pengguna.Text == "" || txtNama.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || txtTelepon.Text == "" || txtAlamat.Text == "")
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (txtId_Pengguna.Text == "" || txtNama.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || txtTelepon.Text == "" || txtAlamat.Text == "")
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                try
                {
                    conn.Open();
                    int jumlahBerhasil = 0;
                    int jumlahGagal = 0;

                    // Loop melalui setiap baris data di DataTable dari pratinjau
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            // Panggil stored procedure untuk membuat pengguna baru
                            using (SqlCommand cmd = new SqlCommand("sp_CreatePengguna", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                // PENTING: Pastikan nama kolom di file Excel Anda sesuai
                                // dengan yang tertulis di sini (misal: "Id_Pengguna", "Nama", dll)
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
                        catch (Exception ex)
                        {
                            // Jika satu baris gagal (misal: format data salah), catat dan lanjutkan
                            Console.WriteLine($"Gagal mengimpor baris untuk Id_Pengguna {row["Id_Pengguna"]}. Error: {ex.Message}");
                            jumlahGagal++;
                        }
                    }

                    MessageBox.Show($"Proses impor selesai.\nBerhasil: {jumlahBerhasil} baris.\nGagal: {jumlahGagal} baris.", "Impor Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Muat ulang data di tabel utama untuk menampilkan data yang baru diimpor
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan koneksi database: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
