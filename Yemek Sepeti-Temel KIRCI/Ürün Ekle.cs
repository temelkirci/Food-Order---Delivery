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
    public partial class Ürün_Ekle : Form
    {
        public Ürün_Ekle()
        {
            InitializeComponent();
        }

        private void Ürün_Ekle_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) // ürün adı
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) // ürün adedi
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) // birim fiyatı
        {

        }

        private void button1_Click(object sender, EventArgs e) // ürün ekle butonu
        {
            Random r = new Random();
            int sayi;
            sayi = r.Next(10000);

            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = JOKER ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            
            string komut = "insert into Yemekler(YemekID , YemekAdi , YemekFiyat , YemekAdedi) values('" + sayi + "','" + textBox1.Text + "' , '" + textBox2.Text + "','" + textBox3.Text + "')";
            temel.Open();

            SqlCommand komutsatiri = new SqlCommand(komut,temel);
            komutsatiri.ExecuteNonQuery();
            temel.Close();
            MessageBox.Show("Yemek başarılı bir şekilde eklendi.");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
