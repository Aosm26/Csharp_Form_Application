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

namespace _1
{
    public partial class kayit : Form
    {
        public kayit()
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numara = txtNumara.Text;
            string sifre = txtSifre.Text;
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string sinif = txtSinif.Text;

            if (string.IsNullOrEmpty(numara) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(sinif))
            {
                MessageBox.Show("Tüm alanları doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string connectionString = "Data Source=AOSM\\MSSQLSERVER01;Initial Catalog=GaziU;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO obs (numara, sifre, ad, soyad, sinif) VALUES (@numara, @sifre, @ad, @soyad, @sinif)";

                        command.Parameters.AddWithValue("@numara", numara);
                        command.Parameters.AddWithValue("@sifre", sifre);
                        command.Parameters.AddWithValue("@ad", ad);
                        command.Parameters.AddWithValue("@soyad", soyad);
                        command.Parameters.AddWithValue("@sinif", sinif);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Öğrenci başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
