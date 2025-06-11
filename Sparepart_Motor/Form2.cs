using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Sparepart_Motor
{
    public partial class Form2 : Form
    {
        private readonly string connectionString = "Data Source=LAPTOP-ITV1OTU4\\HAFIZ16;Initial Catalog=manajemen_sparepart;Integrated Security=True";
        private readonly OpenFileDialog openFileDialog1;
        public Form2()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            EnsureIndexes();
            LoadData();
        }
        private void ClearForm()
        {
            txtId_Barang.Clear();
            txtNama_Barang.Clear();
            txtHarga.Clear();

            txtId_Barang.Focus();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("sp_GetAllSparepart", conn);
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
                    if (string.IsNullOrEmpty(txtId_Barang.Text) || string.IsNullOrEmpty(txtNama_Barang.Text) || string.IsNullOrEmpty(txtHarga.Text))
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. Validasi ID Barang (harus berupa angka)
                    if (!int.TryParse(txtId_Barang.Text, out _))
                    {
                        MessageBox.Show("ID Barang harus berupa angka.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtId_Barang.Focus();
                        return;
                    }

                    // 3. Validasi Harga (harus berupa angka atau desimal)
                    if (!decimal.TryParse(txtHarga.Text, out _))
                    {
                        MessageBox.Show("Harga harus berupa angka atau desimal.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtHarga.Focus();
                        return;
                    }

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_CreateSparepart", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_Barang", txtId_Barang.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nama_Barang", txtNama_Barang.Text.Trim());
                        cmd.Parameters.AddWithValue("@Harga", txtHarga.Text.Trim());

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
                            string Id_Barang = dgvSparepart.SelectedRows[0].Cells["Id_Barang"].Value.ToString();
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand("sp_DeleteSparepart", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Id_Barang", Id_Barang);
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

                txtId_Barang.Text = row.Cells[0].Value.ToString();
                txtNama_Barang.Text = row.Cells[1].Value?.ToString();
                txtHarga.Text = row.Cells[2].Value?.ToString();
            }
        }

        private void BtnUbah(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (string.IsNullOrEmpty(txtId_Barang.Text) || string.IsNullOrEmpty(txtNama_Barang.Text) || string.IsNullOrEmpty(txtHarga.Text))
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. Validasi ID Barang (harus berupa angka)
                    if (!int.TryParse(txtId_Barang.Text, out _))
                    {
                        MessageBox.Show("ID Barang harus berupa angka.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtId_Barang.Focus();
                        return;
                    }

                    // 3. Validasi Harga (harus berupa angka atau desimal)
                    if (!decimal.TryParse(txtHarga.Text, out _))
                    {
                        MessageBox.Show("Harga harus berupa angka atau desimal.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtHarga.Focus();
                        return;
                    }

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateSparepart", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_Barang", txtId_Barang.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nama_Barang", txtNama_Barang.Text.Trim());
                        cmd.Parameters.AddWithValue("@Harga", txtHarga.Text.Trim());

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
            LaporanSparepart formLaporan = new LaporanSparepart();
            formLaporan.Show();
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
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

                    PreviewForm preview = new PreviewForm(dt, "Pratinjau Impor Data Sparepart");
                    if (preview.ShowDialog() == DialogResult.OK)
                    {
                        ProsesImportSparepartKeDatabase(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membaca file Excel. Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ProsesImportSparepartKeDatabase(DataTable dt)
        {
            // Menggunakan connectionString yang ada di Form2
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    int jumlahBerhasil = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_CreateSparepart", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Sesuaikan parameter dengan kebutuhan sp_CreateSparepart
                            cmd.Parameters.AddWithValue("@Id_Barang", Convert.ToInt32(row["Id_Barang"]));
                            cmd.Parameters.AddWithValue("@Nama_Barang", row["Nama_Barang"].ToString());
                            cmd.Parameters.AddWithValue("@Harga", Convert.ToDecimal(row["Harga"]));

                            cmd.ExecuteNonQuery();
                            jumlahBerhasil++;
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show($"Proses impor selesai. Berhasil: {jumlahBerhasil} baris.", "Impor Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan. Semua proses impor dibatalkan. \n\nError: " + ex.Message, "Impor Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    try
                    {
                        // 4. Jika ada error, ROLLBACK untuk membatalkan semua
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }
                    }
                    catch (Exception rbEx)
                    {
                        MessageBox.Show("Gagal melakukan rollback: " + rbEx.Message);
                    }
                }
                finally
                {
                    // Selalu refresh data di tabel setelah proses selesai
                    LoadData();
                }
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            // Contoh query untuk mencari semua sparepart yang namanya berawalan 'O' (misal: Oli)
            var heavyQuery = "SELECT Nama_Barang, Harga FROM dbo.Sparepart WHERE Nama_Barang LIKE 'O%';";

            // Panggil metode analisis
            AnalyzeQuery(heavyQuery);
        }

        private void AnalyzeQuery(string sqlQuery)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.InfoMessage += (s, e) => MessageBox.Show(e.Message, "STATISTICS INFO");
                conn.Open();

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
            // Script T-SQL untuk memeriksa dan membuat indeks pada tabel Sparepart
            var indexScript = @"
                IF OBJECT_ID('dbo.Sparepart', 'U') IS NOT NULL
                BEGIN
                    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_Sparepart_Nama_Barang')
                        CREATE NONCLUSTERED INDEX idx_Sparepart_Nama_Barang ON dbo.Sparepart(Nama_Barang);
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



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bttnUbah_Click(object sender, EventArgs e)
        {

        }
    }
}
