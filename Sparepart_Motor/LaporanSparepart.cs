using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace Sparepart_Motor
{
    public partial class LaporanSparepart : Form
    {
        public LaporanSparepart()
        {
            InitializeComponent();
        }

        private void LaporanSparepart_Load(object sender, EventArgs e)
        {
            try
            {
                // Membuat objek TableAdapter dan DataTable sesuai dengan DataSet Sparepart
                SparepartDataSetTableAdapters.SparepartTableAdapter adapter = new SparepartDataSetTableAdapters.SparepartTableAdapter();
                SparepartDataSet.SparepartDataTable dt = new SparepartDataSet.SparepartDataTable();

                // Mengisi data
                adapter.Fill(dt);

                // Membuat sumber data laporan
                ReportDataSource rds = new ReportDataSource("SparepartDataSet", (System.Data.DataTable)dt);

                // Mengatur dan menampilkan laporan
                this.reportViewerSparepart.LocalReport.DataSources.Clear();
                this.reportViewerSparepart.LocalReport.DataSources.Add(rds);
                this.reportViewerSparepart.LocalReport.ReportEmbeddedResource = "Sparepart_Motor.LaporanSparepart.rdlc";

                this.reportViewerSparepart.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan sparepart. \n\nError: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}