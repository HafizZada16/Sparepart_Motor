using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sparepart_Motor
{
    public partial class LaporanPengguna : Form
    {
        // Definisikan connection string di sini agar bisa diakses oleh metode lain
        private readonly string connectionString = "Data Source=LAPTOP-ITV1OTU4\\HAFIZ16;Initial Catalog=manajemen_sparepart;Integrated Security=True";

        public LaporanPengguna()
        {
            InitializeComponent();
        }

        // Metode ini berjalan saat form dimuat
        private void LaporanPengguna_Load(object sender, EventArgs e)
        {
            // Panggil metode untuk menyiapkan data
            SetupReportViewer();

            // Refresh report untuk menampilkan data
            this.reportViewerPengguna.RefreshReport();
        }

        // Metode utama untuk mengambil data dan mengaturnya ke ReportViewer
        private void SetupReportViewer()
        {
            try
            {
                // Query SQL untuk mengambil data pengguna
                string query = "SELECT Id_Pengguna, Nama, Email, Telepon, Alamat FROM Pengguna";

                // Membuat DataTable untuk menampung data
                DataTable dt = new DataTable();

                // Menggunakan SqlDataAdapter untuk mengisi DataTable
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }

                // Membuat ReportDataSource. Nama "DataSet1" diambil dari materi Anda.
                // PASTIKAN nama ini sama dengan nama DataSet di dalam file .rdlc Anda.
                ReportDataSource rds = new ReportDataSource("PenggunaDataSet", dt);

                // Membersihkan data source lama dan menambahkan yang baru
                this.reportViewerPengguna.LocalReport.DataSources.Clear();
                this.reportViewerPengguna.LocalReport.DataSources.Add(rds);

                // --- PENTING: Pengaturan Path Laporan ---
                // Materi Anda menggunakan ReportPath absolut, ini tidak portabel.
                // Cara yang lebih baik adalah menggunakan ReportEmbeddedResource.
                // Silakan pilih salah satu, tapi yang direkomendasikan adalah baris kedua.

                // CARA 1: Sesuai Materi (Ganti dengan path absolut Anda, TIDAK DIREKOMENDASIKAN)
                this.reportViewerPengguna.LocalReport.ReportPath = @"D:\_kuliah\coding4\PABD\Sparepart_Motor\Sparepart_Motor\LaporanPengguna.rdlc";

                // CARA 2: Cara yang Lebih Baik dan Portabel (DIREKOMENDASIKAN)
                //this.reportViewerPengguna.LocalReport.ReportEmbeddedResource = "Sparepart_Motor.LaporanPengguna.rdlc";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan. \n\nError: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}