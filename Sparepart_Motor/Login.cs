﻿using System;
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
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Email dan Password harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var emailAddress = new System.Net.Mail.MailAddress(txtEmail.Text);
            }
            catch
            {
                MessageBox.Show("Format email tidak valid. Pastikan formatnya benar (contoh: user@domain.com).", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
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
                    string query = "sp_LoginPengguna";

                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
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
                        MessageBox.Show("Email atau Password salah.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtEmail.Clear();
                        txtEmail.Focus();
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