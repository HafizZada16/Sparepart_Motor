using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace Sparepart_Motor
{
    public partial class LaporanPengguna : Form
    {
        public LaporanPengguna()
        {
            InitializeComponent();
        }

        private void LaporanPengguna_Load(object sender, EventArgs e)
        {
            try
            {
                PenggunaDataSetTableAdapters.PenggunaTableAdapter adapter = new PenggunaDataSetTableAdapters.PenggunaTableAdapter();
                PenggunaDataSet.PenggunaDataTable dt = new PenggunaDataSet.PenggunaDataTable();

                adapter.Fill(dt);

                ReportDataSource rds = new ReportDataSource("PenggunaDataSet", (System.Data.DataTable)dt);

                // Menggunakan nama baru: reportViewerPengguna
                this.reportViewerPengguna.LocalReport.DataSources.Clear();
                this.reportViewerPengguna.LocalReport.DataSources.Add(rds);
                this.reportViewerPengguna.LocalReport.ReportEmbeddedResource = "Sparepart_Motor.LaporanPengguna.rdlc";

                // Me-refresh ReportViewer dengan nama baru
                this.reportViewerPengguna.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan. \n\nError: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}