using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sparepart_Motor
{
    public partial class PreviewForm : Form
    {
        public PreviewForm()
        {
            InitializeComponent();
        }

        // Constructor inilah yang membuat form ini reusable
        public PreviewForm(DataTable dataToPreview, string judulLaporan)
        {
            InitializeComponent();

            this.dgvPreview.DataSource = dataToPreview;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgvPreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
