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

namespace Yemek_Sepeti_Temel_KIRCI
{
    public partial class Yönetici : Form
    {
        public Yönetici()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // firma ekle
        {
            Random r = new Random();
            int sayi;
            sayi = r.Next(10000);
            
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz bir şekilde tamamlayınız ...!");
            }
            else
            {
                SqlConnection temel = new SqlConnection();
                temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";

                string komut = "insert into Firma(FirmaID , FirmaAd , FirmaKullanıcıAdı , FirmaŞifre , İl , İlçe) values('" + sayi + "','" + textBox1.Text + "' , '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                temel.Open();

                SqlCommand komutsatiri = new SqlCommand(komut, temel);
                komutsatiri.ExecuteNonQuery();
                temel.Close();
                MessageBox.Show("Firma başarılı bir şekilde eklendi.");
            }
        }

        private void button2_Click(object sender, EventArgs e) // firma güncelle
        {
            SqlConnection temel = new SqlConnection(); // C# ta veritabanına bağlanma
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            if (textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz ...!");
            }
            else
            {
                string komut1 = "update Firma set FirmaAd='" + textBox7.Text + "', İl='" + textBox8.Text + "' , İlçe='" + textBox9.Text + "' where FirmaAd='" + textBox6.Text + "'  ";
                temel.Open();
                SqlCommand komutsatiri = new SqlCommand(komut1, temel);
                komutsatiri.ExecuteNonQuery();
                temel.Close();
                MessageBox.Show("Firma başarılı bir şekilde güncellendi.");
            }

        }

        private void Yönetici_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e) // firma adı
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e) // kullanıcı adı
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e) // şifre
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e) // il
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e) // ilçe
        {

        }

        // firma güncelle

        private void textBox6_TextChanged_1(object sender, EventArgs e) // eski adı
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e) // yeni adı
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e) // il
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e) // ilçe
        {

        }
    }
}
