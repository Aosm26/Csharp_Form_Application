using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Policy;

namespace _1
{
    public class OgrenciNumara
    {
        private string ogrNo;

        public string GetOgrNo()
        {
            return this.ogrNo;
        }

        public void SetOgrNo(string ogrNo)
        {
            this.ogrNo = ogrNo;
        }
    }
    public partial class anasyf : Form
    {

        public anasyf()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            obs obs = new obs();
            string connectionString = "Data Source=AOSM\\MSSQLSERVER01;Initial Catalog=GaziU;Integrated Security=True";
            string query = "SELECT numara , sifre FROM obs";
            //string query = "SELECT numara FROM obs";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i += 2)
                            {
                                if (numara.Text.ToString() == "" + reader[i] & sifre.Text.ToString() == "" + reader[i + 1])
                                {
                                    OgrNoKayit ogre = new OgrNoKayit();
                                    ogre.SetOgrNo("" + reader[i].ToString());
                                    Ogrenci ogrenci1 = new Ogrenci();

                                    obs.ShowDialog();
                                    //ogrenci.SetOgrNo(numara.Text.ToString());
                                }
                            }
                        }
                        if (obs.ActiveForm.Text == "Gazi Üniversitesi")
                        {
                            MessageBox.Show("Giriş başarısız");
                        }
                    }
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            kayit kayit = new kayit();
            kayit.ShowDialog();
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class OgrNoKayit
    {

        private string ogrNo;
        private string dosyaAdi = "ogr.txt";
        public string GetOgrNo()
        {
            Oku();
            return ogrNo;
        }

        public void SetOgrNo(string ogrNoGelen)
        {
            this.ogrNo = ogrNoGelen;
            Kaydet(ogrNo);
            MessageBox.Show("ogrNo");
        }
        public void Kaydet(string ogrNo)
        {
            try
            {
                using (StreamWriter dosya = new StreamWriter(dosyaAdi))
                {
                    dosya.Write(ogrNo);
                    MessageBox.Show(ogrNo);
                }

                Console.WriteLine("Değişken başarıyla dosyaya kaydedildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu: " + ex.Message);
            }
        }
        public string Oku()
        {
            string okunanVeri = string.Empty;

            try
            {
                if (File.Exists(dosyaAdi))
                {
                    using (StreamReader dosya = new StreamReader(dosyaAdi))
                    {
                        okunanVeri = dosya.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Dosya bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu: " + ex.Message);
            }

            ogrNo = okunanVeri;
            return okunanVeri;
        }
    }
}
