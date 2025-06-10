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
    public partial class Beranda : Form
    {
        public Beranda()
        {
            InitializeComponent();
        }

        private void btnPengguna_Click(object sender, EventArgs e)
        {
            // Membuka Form1
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void btnSparepart_Click(object sender, EventArgs e)
        {
            // Membuka Form2
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
