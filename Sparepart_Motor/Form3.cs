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
using System.Text.RegularExpressions;

namespace Sparepart_Motor
{
    public partial class Form3 : Form
    {
        private readonly string connectionString = "Data Source=LAPTOP-ITV1OTU4\\HAFIZ16;Initial Catalog=manajemen_sparepart;Integrated Security=True";
        private readonly OpenFileDialog openFileDialog1;
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
                    if (string.IsNullOrEmpty(txtId_Transaksi.Text) || string.IsNullOrEmpty(txtId_Pengguna.Text) || string.IsNullOrEmpty(txtTotal_Harga.Text))
                    {
                        MessageBox.Show("Harap isi semua kolom ID dan Total Harga!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. Validasi ID Transaksi (harus berupa angka)
                    if (!int.TryParse(txtId_Transaksi.Text, out _))
                    {
                        MessageBox.Show("ID Transaksi harus berupa angka.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtId_Transaksi.Focus();
                        return;
                    }

                    // 3. Validasi ID Pengguna (harus berupa angka)
                    if (!int.TryParse(txtId_Pengguna.Text, out _))
                    {
                        MessageBox.Show("ID Pengguna harus berupa angka.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtId_Pengguna.Focus();
                        return;
                    }

                    // 4. Validasi Total Harga (harus berupa angka atau desimal)
                    if (!decimal.TryParse(txtTotal_Harga.Text, out _))
                    {
                        MessageBox.Show("Total Harga harus berupa angka atau desimal.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTotal_Harga.Focus();
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
                    if (string.IsNullOrEmpty(txtId_Transaksi.Text) || string.IsNullOrEmpty(txtId_Pengguna.Text) || string.IsNullOrEmpty(txtTotal_Harga.Text))
                    {
                        MessageBox.Show("Harap isi semua kolom ID dan Total Harga!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. Validasi ID Transaksi (harus berupa angka)
                    if (!int.TryParse(txtId_Transaksi.Text, out _))
                    {
                        MessageBox.Show("ID Transaksi harus berupa angka.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtId_Transaksi.Focus();
                        return;
                    }

                    // 3. Validasi ID Pengguna (harus berupa angka)
                    if (!int.TryParse(txtId_Pengguna.Text, out _))
                    {
                        MessageBox.Show("ID Pengguna harus berupa angka.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtId_Pengguna.Focus();
                        return;
                    }

                    // 4. Validasi Total Harga (harus berupa angka atau desimal)
                    if (!decimal.TryParse(txtTotal_Harga.Text, out _))
                    {
                        MessageBox.Show("Total Harga harus berupa angka atau desimal.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTotal_Harga.Focus();
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            LaporanTransaksi formLaporan = new LaporanTransaksi();
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
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    int jumlahBerhasil = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_CreateTransaksi", conn, transaction))
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

                    transaction.Commit();
                    MessageBox.Show($"Proses impor selesai. Berhasil: {jumlahBerhasil} baris.", "Impor Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan. Semua proses impor dibatalkan. \n\nError: " + ex.Message, "Impor Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    try
                    {
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
                    LoadData();
                }
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
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
