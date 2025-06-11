using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace Sparepart_Motor
{
    public partial class LaporanDetail : Form
    {
        public LaporanDetail()
        {
            InitializeComponent();
        }

        private void LaporanDetail_Load(object sender, EventArgs e)
        {
            try
            {
                // Membuat objek TableAdapter dan DataTable sesuai dengan DataSet Detail
                DetailDataSetTableAdapters.DetailTableAdapter adapter = new DetailDataSetTableAdapters.DetailTableAdapter();
                DetailDataSet.DetailDataTable dt = new DetailDataSet.DetailDataTable();

                // Mengisi data
                adapter.Fill(dt);

                // Membuat sumber data laporan
                ReportDataSource rds = new ReportDataSource("DetailDataSet", (System.Data.DataTable)dt);

                // Mengatur dan menampilkan laporan
                this.reportViewerDetail.LocalReport.DataSources.Clear();
                this.reportViewerDetail.LocalReport.DataSources.Add(rds);
                this.reportViewerDetail.LocalReport.ReportEmbeddedResource = "Sparepart_Motor.LaporanDetail.rdlc";

                this.reportViewerDetail.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan detail. \n\nError: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.reportViewerDetail.RefreshReport();
        }
    }
}