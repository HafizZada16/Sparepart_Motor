using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace Sparepart_Motor
{
    public partial class LaporanTransaksi : Form
    {
        public LaporanTransaksi()
        {
            InitializeComponent();
        }

        private void LaporanTransaksi_Load(object sender, EventArgs e)
        {
            try
            {
                // Membuat objek TableAdapter dan DataTable sesuai dengan DataSet Transaksi
                TransaksiDataSetTableAdapters.TransaksiTableAdapter adapter = new TransaksiDataSetTableAdapters.TransaksiTableAdapter();
                TransaksiDataSet.TransaksiDataTable dt = new TransaksiDataSet.TransaksiDataTable();

                // Mengisi data
                adapter.Fill(dt);

                // Membuat sumber data laporan
                ReportDataSource rds = new ReportDataSource("TransaksiDataSet", (System.Data.DataTable)dt);

                // Mengatur dan menampilkan laporan
                this.reportViewerTransaksi.LocalReport.DataSources.Clear();
                this.reportViewerTransaksi.LocalReport.DataSources.Clear();
                this.reportViewerTransaksi.LocalReport.DataSources.Add(rds);
                this.reportViewerTransaksi.LocalReport.ReportEmbeddedResource = "Sparepart_Motor.LaporanTransaksi.rdlc";

                this.reportViewerTransaksi.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan transaksi. \n\nError: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}