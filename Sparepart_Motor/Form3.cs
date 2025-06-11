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
using System.IO;

namespace Sparepart_Motor
{
    public partial class Form3 : Form
    {
        private string connectionString = "Data Source=LAPTOP-ITV1OTU4\\HAFIZ16;Initial Catalog=manajemen_sparepart;Integrated Security=True";
        private OpenFileDialog openFileDialog1;
        public Form3()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            EnsureIndexes();
            LoadData();
        }
        private void ClearForm()
        {
            txtId_Transaksi.Clear();
            txtId_Pengguna.Clear();
            dtpTanggalTransaksi.Value = DateTime.Now;
            txtTotal_Harga.Clear();

            txtId_Transaksi.Focus();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("sp_GetAllTransaksi", conn);
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
                    if (txtId_Transaksi.Text == "" || txtId_Pengguna.Text == "" || txtTotal_Harga.Text == "")
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_CreateTransaksi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_Transaksi", txtId_Transaksi.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id_Pengguna", txtId_Pengguna.Text.Trim());
                        cmd.Parameters.AddWithValue("@Tanggal_Transaksi", dtpTanggalTransaksi.Value);
                        cmd.Parameters.AddWithValue("@Total_Harga", txtTotal_Harga.Text.Trim());

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
                            string Id_Transaksi = dgvSparepart.SelectedRows[0].Cells["Id_Transaksi"].Value.ToString();
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand("sp_DeleteTransaksi", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Id_Transaksi", Id_Transaksi);
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

                txtId_Transaksi.Text = row.Cells[0].Value.ToString();
                txtId_Pengguna.Text = row.Cells[1].Value?.ToString();
                dtpTanggalTransaksi.Value = Convert.ToDateTime(row.Cells[2].Value);
                txtTotal_Harga.Text = row.Cells[3].Value?.ToString();
            }
        }

        private void BtnUbah(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (txtId_Transaksi.Text == "" || txtId_Pengguna.Text == "" || txtTotal_Harga.Text == "")
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateTransaksi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_Transaksi", txtId_Transaksi.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id_Pengguna", txtId_Pengguna.Text.Trim());
                        cmd.Parameters.AddWithValue("@Tanggal_Transaksi", dtpTanggalTransaksi.Value);
                        cmd.Parameters.AddWithValue("@Total_Harga", txtTotal_Harga.Text.Trim());

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
                        dt.Columns.Add(headerRow.GetCell(j)?.ToString() ?? $"Column_{j}");
                    }
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        DataRow dataRow = dt.NewRow();
                        for (int j = 0; j < cellCount; j++)
                        {
                            dataRow[j] = row.GetCell(j)?.ToString() ?? string.Empty;
                        }
                        dt.Rows.Add(dataRow);
                    }

                    PreviewForm preview = new PreviewForm(dt, "Pratinjau Impor Data Transaksi");
                    if (preview.ShowDialog() == DialogResult.OK)
                    {
                        ProsesImportTransaksiKeDatabase(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membaca file Excel. Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ProsesImportTransaksiKeDatabase(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    int jumlahBerhasil = 0;
                    int jumlahGagal = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_CreateTransaksi", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Id_Transaksi", Convert.ToInt32(row["Id_Transaksi"]));
                                cmd.Parameters.AddWithValue("@Id_Pengguna", Convert.ToInt32(row["Id_Pengguna"]));
                                cmd.Parameters.AddWithValue("@Tanggal_Transaksi", Convert.ToDateTime(row["Tanggal_Transaksi"]));
                                cmd.Parameters.AddWithValue("@Total_Harga", Convert.ToDecimal(row["Total_Harga"]));
                                cmd.ExecuteNonQuery();
                                jumlahBerhasil++;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Gagal mengimpor baris untuk Id_Transaksi {row["Id_Transaksi"]}. Error: {ex.Message}");
                            jumlahGagal++;
                        }
                    }
                    MessageBox.Show($"Proses impor selesai.\nBerhasil: {jumlahBerhasil} baris.\nGagal: {jumlahGagal} baris.", "Impor Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan koneksi database: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            // Contoh query untuk mencari semua transaksi dengan total harga di atas 100000
            // Query ini akan lebih cepat jika ada indeks pada Total_Harga,
            // namun kita akan gunakan ini sebagai contoh.
            var heavyQuery = "SELECT * FROM dbo.Transaksi_Pembelian WHERE Total_Harga > 100000;";

            // Panggil metode analisis
            AnalyzeQuery(heavyQuery);
        }

        private void AnalyzeQuery(string sqlQuery)
        {
            // Menggunakan connectionString yang sudah ada di Form3
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
            // Script T-SQL untuk memeriksa dan membuat indeks pada tabel Transaksi_Pembelian
            var indexScript = @"
                IF OBJECT_ID('dbo.Transaksi_Pembelian', 'U') IS NOT NULL
                BEGIN
                    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_Transaksi_Id_Pengguna')
                        CREATE NONCLUSTERED INDEX idx_Transaksi_Id_Pengguna ON dbo.Transaksi_Pembelian(Id_Pengguna);
            
                    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_Transaksi_Tanggal')
                        CREATE NONCLUSTERED INDEX idx_Transaksi_Tanggal ON dbo.Transaksi_Pembelian(Tanggal_Transaksi);
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

        private void txtId_Transaksi_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
