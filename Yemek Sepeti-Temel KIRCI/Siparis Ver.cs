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
        public string company_name;
        public string food_name;
        public string birim_fiyat;
        public int firma_idd = 0;
        public static int cost;
        public int musteriBakiye = 0;

        SqlConnection temel;
        SqlCommand komutsatir;
        SqlDataReader dr;

        public Siparis_Ver()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) // siparis adedi
        {

        }
        
        private void müsteriBakiyeBul()
        {
            temel = new SqlConnection();
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            temel.Open();

            string musteriPara = "select MüsteriBakiye from Müsteri where MüsteriID like '" + musteri_id + "'";

            SqlCommand komutsatirr = new SqlCommand(musteriPara, temel);
            SqlDataReader dr = komutsatirr.ExecuteReader();

            if (dr.Read())
            {
                musteriBakiye = dr.GetInt32(0);
            }

            temel.Close();
        }

        private void button1_Click(object sender, EventArgs e) // sipariş ver butonu
        {
            if ((comboBox1.SelectedItem != null) && (comboBox2.SelectedItem != null) && (textBox2.Text != ""))
            {
                birim_fiyat_al();

                // sipariş tutarını hesapla
                tutarHesapla();

                // müsteri bakiyesini öğren
                müsteriBakiyeBul();

                if (musteriBakiye >= cost)
                {
                    Random r = new Random();
                    int sayi;
                    sayi = r.Next(10000);

                    // firma id bul
                    firma_idd = firma_id_bul();

                    // müsterinin yeni bakiyesini güncelle
                    temel = new SqlConnection();
                    temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
                    temel.Open();
         
                    int Bakiye = musteriBakiye - cost;
                    string bakiyeGüncelle = "update Müsteri set MüsteriBakiye = '" + Bakiye + "' where Müsteri.MüsteriID = '" + musteri_id + "' ";

                    komutsatir = new SqlCommand(bakiyeGüncelle, temel);
                    komutsatir.ExecuteNonQuery();
                    temel.Close();

                    
                    // siparişi ekle
                    temel = new SqlConnection();
                    temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
                    temel.Open();
                    string durum = "Hazırlanıyor";

                    string komut = "insert into Siparis(SiparisID , MüsteriID , FirmaID , SiparisAdi , SiparisAdet , SiparisTutar , SiparisDurum) values('" + sayi + "','" + musteri_id + "','" + firma_idd + "','" + comboBox2.SelectedItem.ToString() + "','" + textBox2.Text + "' , '" + cost + "' ,'" + durum + "')";

                    komutsatir = new SqlCommand(komut, temel);
                    komutsatir.ExecuteNonQuery();

                    MessageBox.Show("Siparişiniz başarılı bir şekilde verildi.");

                    temel.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Yeterli bakiyeniz yok");
                }
                
            }
            else
            {
                MessageBox.Show("Lütfen bütün boş alanları doldurun.");
            }
           
        }

        private void Siparis_Ver_Load(object sender, EventArgs e) // sipariş ver formu
        {
            timer1.Enabled = true;
            timer1.Interval = 1000; // her 10 mili saniye yemekler kısmını firma adına göre yenile

            company_name = "";
            food_name = "";

            comboboxfirma();         
        }

        private void comboboxfirma()
        {
            comboBox1.Items.Clear();
            temel = new SqlConnection();
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            temel.Open();
            komutsatir = new SqlCommand("select *from Firma ", temel);

            dr = komutsatir.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["FirmaAd"].ToString());
            }           

            temel.Close();

        }

        private void comboboxürün()  // seçili firmanın ürünlerini getir
        {           
            if (comboBox1.SelectedItem != null)
            {
                comboBox2.Items.Clear();
                temel = new SqlConnection();
                temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
                temel.Open();
               
                if (firma_idd != 0)
                {

                        komutsatir = new SqlCommand("select *from Yemekler where Yemekler.FirmaID = '" + firma_idd + "'", temel);

                        dr = komutsatir.ExecuteReader();

                        while (dr.Read())
                        {
                            comboBox2.Items.Add(dr["YemekAdi"].ToString());
                        }
                }
                temel.Close();
            }         
        }

        private int firma_id_bul()
        {
            temel = new SqlConnection();
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            temel.Open();

            string firmaIDD = "select FirmaID from Firma where FirmaAd like '" + comboBox1.SelectedItem.ToString() + "'";

            komutsatir = new SqlCommand(firmaIDD, temel);
            komutsatir.ExecuteNonQuery();
            dr = komutsatir.ExecuteReader();

            if (dr.Read())
            {
                firma_idd = dr.GetInt32(0);                
            }
           
            temel.Close();      
            return firma_idd;
        }

        private void resim_al()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (comboBox2.Text == "Köfte")
            {
                pictureBox1.Image = Image.FromFile("C:/Users/TEMEL/Desktop/Yemek Sepeti/Food Pictures/köfte.jpg");
            }

            else if (comboBox2.Text == "Dondurma")
            {
                pictureBox1.Image = Image.FromFile("C:/Users/TEMEL/Desktop/Yemek Sepeti/Food Pictures/dondurma.jpg");
            }

            else if (comboBox2.Text == "Lahmacun")
            {
                pictureBox1.Image = Image.FromFile("C:/Users/TEMEL/Desktop/Yemek Sepeti/Food Pictures/lahmacun.png");
            }

            else if (comboBox2.Text == "Döner")
            {
                pictureBox1.Image = Image.FromFile("C:/Users/TEMEL/Desktop/Yemek Sepeti/Food Pictures/et_döner.jpg");
            }

            else
            {
                MessageBox.Show(comboBox2.Text);
            }
        }

        private void label5_Click(object sender, EventArgs e) // ücret
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // combobox firma adı
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) // combobox ürün adı
        {

        }

        private void tutarHesapla()
        {
            if (textBox2.Text != "")
            {              
                cost = Convert.ToInt32(label7.Text) * Convert.ToInt32(textBox2.Text);
                label5.Text = cost.ToString() + " TL";
            }
            else
            {            
                label5.Text = "0 TL";
            }
        }

        private void birim_fiyat_al()
        {
            temel = new SqlConnection();
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            temel.Open();

            string birim_fiyatt = "select YemekFiyat from Yemekler where Yemekler.FirmaID = '" + firma_idd + "'";
            
            komutsatir = new SqlCommand(birim_fiyatt, temel);
            komutsatir.ExecuteNonQuery();
            dr = komutsatir.ExecuteReader();

            if (dr.Read())
            {
                label7.Text = dr["YemekFiyat"].ToString() ;
            }
            temel.Close();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedItem != null )
            {
                if (company_name != comboBox1.Text)
                {
                    company_name = comboBox1.Text;
                    firma_id_bul();
                    comboboxürün();                   
                }
                else
                {
                    firma_id_bul();               
                }
            }

            if (comboBox2.SelectedItem != null)
            {
                if (food_name != comboBox2.Text)
                {
                    food_name = comboBox2.Text;
                    resim_al();
                    birim_fiyat_al();                    
                }            
            }


            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null )
            {
                tutarHesapla();
            }
          
        }

        private void pictureBox1_Click(object sender, EventArgs e) // yemek resmi
        {

        }
       
    }
}
