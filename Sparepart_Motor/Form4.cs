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

namespace Sparepart_Motor
{
    public partial class Form4 : Form
    {
        private string connectionString = "Data Source=LAPTOP-ITV1OTU4\\HAFIZ16;Initial Catalog=manajemen_sparepart;Integrated Security=True";
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ClearForm()
        {
            txtId_Detail.Clear();
            txtId_Transaksi.Clear();
            txtId_Barang.Clear();
            txtJumlah.Clear();
            txtHarga_Satuan.Clear();

            txtId_Detail.Focus();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Id_Detail, Id_Transaksi, Id_Barang, Jumlah, Harga_Satuan FROM Detail_Pembelian";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
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
                    if (txtId_Detail.Text == "" || txtId_Transaksi.Text == "" || txtId_Barang.Text == "" || txtJumlah.Text == "" || txtHarga_Satuan.Text == "")
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    conn.Open();
                    string query = "INSERT INTO Detail_Pembelian (Id_Detail, Id_Transaksi, Id_Barang, Jumlah, Harga_Satuan) VALUES (@Id_Detail, @Id_Transaksi, @Id_Barang, @Jumlah, @Harga_Satuan)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id_Detail", txtId_Detail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id_Transaksi", txtId_Transaksi.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id_Barang", txtId_Barang.Text.Trim());
                        cmd.Parameters.AddWithValue("@Jumlah", txtJumlah.Text.Trim());
                        cmd.Parameters.AddWithValue("@Harga_Satuan", txtHarga_Satuan.Text.Trim());

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
                            string Id_Detail = dgvSparepart.SelectedRows[0].Cells["Id_Detail"].Value.ToString();
                            conn.Open();
                            string query = "DELETE FROM Detail_Pembelian WHERE Id_Detail = @Id_Detail";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@Id_Detail", Id_Detail);
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

                txtId_Detail.Text = row.Cells[0].Value.ToString();
                txtId_Transaksi.Text = row.Cells[1].Value?.ToString();
                txtId_Barang.Text = row.Cells[2].Value?.ToString();
                txtJumlah.Text = row.Cells[3].Value?.ToString();
                txtHarga_Satuan.Text = row.Cells[4].Value?.ToString();
            }
        }

        private void BtnUbah(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (txtId_Detail.Text == "" || txtId_Transaksi.Text == "" || txtId_Barang.Text == "" || txtJumlah.Text == "" || txtHarga_Satuan.Text == "")
                    {
                        MessageBox.Show("Harap isi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    conn.Open();
                    string query = "UPDATE Detail_Pembelian SET Id_Detail = @Id_Detail, Id_Barang = @Id_Barang, Jumlah = @Jumlah, Harga_Satuan = @Harga_Satuan WHERE Id_Detail = @Id_Detail";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id_Detail", txtId_Detail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Id_Transaksi", txtId_Transaksi.Text.Trim());
                        cmd.Parameters.AddWithValue("@IdBarang", txtId_Barang.Text.Trim());
                        cmd.Parameters.AddWithValue("@Jumlah", txtJumlah.Text.Trim());
                        cmd.Parameters.AddWithValue("@Harga_Satuan", txtHarga_Satuan.Text.Trim());

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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtId_Barang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
