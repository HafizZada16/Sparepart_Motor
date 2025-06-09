using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sparepart_Motor
{
    public partial class Login : Form
    {
        // Menggunakan connection string yang sama dengan form lainnya
        private string connectionString = "Data Source=LAPTOP-ITV1OTU4\\HAFIZ16;Initial Catalog=manajemen_sparepart;Integrated Security=True";

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Memeriksa apakah input username dan password kosong
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Username dan Password harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Query untuk memeriksa kecocokan data dari tabel Pengguna
                    // Username dicocokkan dengan kolom 'Nama'
                    // Password dicocokkan dengan kolom 'Id_Pengguna'
                    string query = "SELECT * FROM Pengguna WHERE Nama = @Username AND Password" +
                        " = @Password";

                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    sda.SelectCommand.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    sda.SelectCommand.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    // Jika query menghasilkan satu baris atau lebih, login berhasil
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Login berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Sembunyikan form login saat ini
                        this.Hide();

                        // Buat dan tampilkan form Beranda
                        Beranda beranda = new Beranda();
                        beranda.FormClosed += (s, args) => this.Close(); // Tutup aplikasi jika Beranda ditutup
                        beranda.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password salah.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtUsername.Clear();
                        txtUsername.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}