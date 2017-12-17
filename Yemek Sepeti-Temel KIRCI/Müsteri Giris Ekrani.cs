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
    public partial class MusteriGirisEkrani : Form
    {       
        public static string musteriid;
        public MusteriGirisEkrani()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e) // müsteri kullanıcı adı
        {

        }

        private void MusteriGirisEkrani_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) // müsteri sifre
        {

        }

        private void button1_Click(object sender, EventArgs e) // giriş yap butonu
        {
      
            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            SqlDataAdapter komut = new SqlDataAdapter("Select Count(*) From Müsteri where MüsteriKullanıcıAdı='" + textBox1.Text + "' and MüsteriŞifre='" + textBox2.Text + "'", temel);
            DataTable dt = new System.Data.DataTable();
            komut.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1") // başarılı giriş yapıldıysa
            {
                temel.Open();
                Musteri.welcome = textBox1.Text;
                SqlCommand komutt = new SqlCommand("Select MüsteriID From Müsteri where MüsteriKullanıcıAdı='" + textBox1.Text + "' and MüsteriŞifre='" + textBox2.Text + "'", temel);
                SqlDataReader dr = komutt.ExecuteReader();
                
                while (dr.Read())
                {
                    musteriid = dr["MüsteriID"].ToString();
                }

                this.Close();

                Musteri mstr = new Musteri();
                mstr.ShowDialog();

            }
            else // hatalı giriş
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre ..!");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e) // musteri id
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) // müsteri ad
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e) // müsteri soyad
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e) // kullanıcı adı
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e) // şifre
        {

        }

        private void button2_Click(object sender, EventArgs e) // üye ol
        {
            Random r = new Random();
            int sayi;
            sayi = r.Next(10000);

            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            temel.Open();
            string komut = "insert into Müsteri(MüsteriID , MüsteriAd , MüsteriSoyad , MüsteriKullanıcıAdı , MüsteriŞifre) values('" + sayi + "' , '" + textBox4.Text + "' , '" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";

            SqlCommand komutsatiri = new SqlCommand(komut, temel);
            komutsatiri.ExecuteNonQuery();
            temel.Close();
            MessageBox.Show("Başarılı bir şekilde kayıt oldunuz.");
        }
    }
}
