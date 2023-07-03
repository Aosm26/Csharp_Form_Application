using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class obs : Form
    {
        public obs()
        {
            string connectionString = "Data Source=AOSM\\MSSQLSERVER01;Initial Catalog=GaziU;Integrated Security=True";
            OgrNoKayit ogrKyt = new OgrNoKayit();
            string numara = ogrKyt.GetOgrNo();
            numara = "";
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string sinif = txtSinif.Text;
            string posta = txtPosta.Text;
            string bolum = txtBolum.Text;

            numara = "21181617016";
            string ad = "";
            string soyad = "";
            string sinif = "";
            string posta = ".";
            string bolum = ".";

            if (string.IsNullOrEmpty(numara) || string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(sinif) || string.IsNullOrEmpty(posta) || string.IsNullOrEmpty(bolum))
            {
                MessageBox.Show("Tüm alanları doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT ad, soyad, sinif, eposta, bolum FROM obs WHERE numara = @Numara";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Numara", numara);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtAd.Text = reader.GetString(0);
                        txtSoyad.Text = reader.GetString(1);
                        txtSinif.Text = reader.GetString(2);
                        txtPosta.Text = reader.GetString(3);
                        txtBolum.Text = reader.GetString(4);

                        //MessageBox.Show("Ad: " + ad);
                        //MessageBox.Show("Soyad: " + soyad);
                        //MessageBox.Show("Sınıf: " + sinif);
                        //MessageBox.Show("E-posta: " + posta);
                        //MessageBox.Show("Bölüm: " + bolum);
                    }
                    else
                    {
                        MessageBox.Show("Numara bulunamadı.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=AOSM\\MSSQLSERVER01;Initial Catalog=GaziU;Integrated Security=True";
            string numara = txtNumara.Text;
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string sinif = txtSinif.Text;
            string posta = txtPosta.Text;
            string bolum = txtBolum.Text;

            if (string.IsNullOrEmpty(numara) || string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(sinif) || string.IsNullOrEmpty(posta) || string.IsNullOrEmpty(bolum))
            {
                MessageBox.Show("Tüm alanları doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE obs SET ad = @Ad, soyad = @Soyad, sinif = @Sinif, eposta = @Eposta, bolum = @Bolum WHERE numara = @Numara";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Ad", ad);
                    command.Parameters.AddWithValue("@Soyad", soyad);
                    command.Parameters.AddWithValue("@Sinif", sinif);
                    command.Parameters.AddWithValue("@Eposta", posta);
                    command.Parameters.AddWithValue("@Bolum", bolum);
                    command.Parameters.AddWithValue("@Numara", numara);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Bilgiler güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Numara bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        private void sifredeg_Click(object sender, EventArgs e)
        {
            Sifredegis sifredegis = new Sifredegis();
            sifredegis.ShowDialog();
        }
    }
}
