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
    public partial class Form4 : Form
    {
        private readonly string connectionString = "Data Source=LAPTOP-ITV1OTU4\\HAFIZ16;Initial Catalog=manajemen_sparepart;Integrated Security=True";
        private readonly OpenFileDialog openFileDialog1;
        public Form4()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            EnsureIndexes();
            LoadData();
        }
        private void ClearForm()
        {
            txtId_Detail.Clear();
            txtId_Transaksi.Clear();
            txtId_Barang.Clear();
            txtJumlah.Clear();
            txtHarga_Satuan.Clear();

            txtId_Detail.Focus();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("sp_GetAllDetail", conn);
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
                    if (txtId_Detail.Text == "" || txtId_Transaksi.Text == "" || txtId_Barang.Text == "" || txtJumlah.Text == "" || txtHarga_Satuan.Text == "")
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_CreateDetail", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_Detail", txtId_Detail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id_Transaksi", txtId_Transaksi.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id_Barang", txtId_Barang.Text.Trim());
                        cmd.Parameters.AddWithValue("@Jumlah", txtJumlah.Text.Trim());
                        cmd.Parameters.AddWithValue("@Harga_Satuan", txtHarga_Satuan.Text.Trim());

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
                            string Id_Detail = dgvSparepart.SelectedRows[0].Cells["Id_Detail"].Value.ToString();
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand("sp_DeleteDetail", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Id_Detail", Id_Detail);
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

                txtId_Detail.Text = row.Cells[0].Value.ToString();
                txtId_Transaksi.Text = row.Cells[1].Value?.ToString();
                txtId_Barang.Text = row.Cells[2].Value?.ToString();
                txtJumlah.Text = row.Cells[3].Value?.ToString();
                txtHarga_Satuan.Text = row.Cells[4].Value?.ToString();
            }
        }

        private void BtnUbah(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (txtId_Detail.Text == "" || txtId_Transaksi.Text == "" || txtId_Barang.Text == "" || txtJumlah.Text == "" || txtHarga_Satuan.Text == "")
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateDetail", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_Detail", txtId_Detail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id_Transaksi", txtId_Transaksi.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id_Barang", txtId_Barang.Text.Trim());
                        cmd.Parameters.AddWithValue("@Jumlah", txtJumlah.Text.Trim());
                        cmd.Parameters.AddWithValue("@Harga_Satuan", txtHarga_Satuan.Text.Trim());

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

        private void btnExport_Click(object sender, EventArgs e)
        {
            LaporanDetail formLaporan = new LaporanDetail();
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

                    PreviewForm preview = new PreviewForm(dt, "Pratinjau Impor Data Detail Transaksi");
                    if (preview.ShowDialog() == DialogResult.OK)
                    {
                        ProsesImportDetailKeDatabase(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membaca file Excel. Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ProsesImportDetailKeDatabase(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // 1. Deklarasikan transaksi di luar 'try' dengan nilai awal null
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    // 2. Beri nilai pada variabel transaksi di dalam 'try'
                    transaction = conn.BeginTransaction();
                    int jumlahBerhasil = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        // Panggil Stored Procedure untuk membuat Detail baru
                        using (SqlCommand cmd = new SqlCommand("sp_CreateDetail", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Sesuaikan parameter dengan kebutuhan sp_CreateDetail
                            cmd.Parameters.AddWithValue("@Id_Detail", Convert.ToInt32(row["Id_Detail"]));
                            cmd.Parameters.AddWithValue("@Id_Transaksi", Convert.ToInt32(row["Id_Transaksi"]));
                            cmd.Parameters.AddWithValue("@Id_Barang", Convert.ToInt32(row["Id_Barang"]));
                            cmd.Parameters.AddWithValue("@Jumlah", Convert.ToInt32(row["Jumlah"]));
                            cmd.Parameters.AddWithValue("@Harga_Satuan", Convert.ToDecimal(row["Harga_Satuan"]));

                            cmd.ExecuteNonQuery();
                            jumlahBerhasil++;
                        }
                    }

                    // 3. Jika semua loop berhasil, COMMIT untuk menyimpan permanen
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
            // Contoh query yang menggabungkan (JOIN) beberapa tabel.
            // Query seperti ini akan sangat merasakan manfaat dari indeks yang kita buat.
            // Misal: Melihat semua item barang untuk transaksi nomor 301
            var heavyQuery = @"
                SELECT 
                    d.Id_Detail,
                    t.Tanggal_Transaksi,
                    s.Nama_Barang,
                    d.Jumlah,
                    d.Subtotal
                FROM 
                    dbo.Detail_Pembelian d
                JOIN 
                    dbo.Transaksi_Pembelian t ON d.Id_Transaksi = t.Id_Transaksi
                JOIN 
                    dbo.Sparepart s ON d.Id_Barang = s.Id_Barang
                WHERE 
                    d.Id_Transaksi = 301;";

            // Panggil metode analisis
            AnalyzeQuery(heavyQuery);
        }

        private void AnalyzeQuery(string sqlQuery)
        {
            // Menggunakan connectionString yang sudah ada di Form4
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
            // Script T-SQL untuk memeriksa dan membuat indeks pada tabel Detail_Pembelian
            var indexScript = @"
                IF OBJECT_ID('dbo.Detail_Pembelian', 'U') IS NOT NULL
                BEGIN
                    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_Detail_Id_Transaksi')
                        CREATE NONCLUSTERED INDEX idx_Detail_Id_Transaksi ON dbo.Detail_Pembelian(Id_Transaksi);
            
                    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_Detail_Id_Barang')
                        CREATE NONCLUSTERED INDEX idx_Detail_Id_Barang ON dbo.Detail_Pembelian(Id_Barang);
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


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtId_Barang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
