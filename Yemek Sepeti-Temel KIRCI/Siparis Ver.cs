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
    public partial class Siparis_Ver : Form
    {
        string musteri_id = MusteriGirisEkrani.musteriid;
        string firma_id = FirmaGirisEkrani.firmaid;

        public Siparis_Ver()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // ürün adı
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) // siparis adedi
        {

        }
      
        private void button1_Click(object sender, EventArgs e) // sipariş ver buton
        {
            Random r = new Random();
            int sayi;
            sayi = r.Next(10000);
            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = JOKER ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            string durum = "hazırlanıyor";
            string komut = "insert into Siparis(SiparisID , MüsteriID , FirmaID , SiparisAdi , SiparisAdet , SiparisDurum) values('" + sayi + "','" + musteri_id + "','" + firma_id + "','" + textBox1.Text + "','" + textBox2.Text + "' , '" + durum + "')";
            temel.Open();

            SqlCommand komutsatiri = new SqlCommand(komut, temel);
            komutsatiri.ExecuteNonQuery();
            temel.Close();
            MessageBox.Show("Sipariş başarılı bir şekilde verildi.");
        }

        private void textBox3_TextChanged(object sender, EventArgs e) // siparis ıd
        {

        }

        private void Siparis_Ver_Load(object sender, EventArgs e)
        {

        }

       
    }
}
