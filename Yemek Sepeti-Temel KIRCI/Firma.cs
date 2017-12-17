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
    public partial class Firma : Form
    {
        int a = 0;
        int b = 0;
        bool refresh = false;
        public int firma_id = Convert.ToInt32(FirmaGirisEkrani.firmaid);

        public Firma()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) // ürün güncelle
        {
            Ürün_Güncelle güncelle = new Ürün_Güncelle();
            güncelle.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e) // ürün ekle
        {
            Ürün_Ekle ekle = new Ürün_Ekle();
            ekle.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) // ürün sil
        {
            Ürün_Sil sil = new Ürün_Sil();
            sil.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // combobox
        {

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void RefreshSiparisBilgileri()
        {
            listView1.Items.Clear();

            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            temel.Open();
            SqlCommand komutt = new SqlCommand("select SiparisID , SiparisAdi , SiparisAdet , SiparisDurum from Siparis where FirmaID='" + firma_id + "' ", temel);
            
            listView1.View = View.Details;

            if (!refresh)
            {
                listView1.Columns.Add("Sipariş ID", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Ürün Adı", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Ürün Adedi", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Ürün Durumu", 100, HorizontalAlignment.Left);
            }
            

            SqlDataReader drr = komutt.ExecuteReader();
            
            ListViewItem li = new ListViewItem();
            

            while (drr.Read())
            {
                listView1.Items.Add(drr["SiparisID"].ToString());
                listView1.Items[a].SubItems.Add(drr["SiparisAdi"].ToString());
                listView1.Items[a].SubItems.Add(drr["SiparisAdet"].ToString());
                listView1.Items[a].SubItems.Add(drr["SiparisDurum"].ToString());
                
                a++;
            }
            a = 0;
            temel.Close();
        }
        
        private void Firma_Load(object sender, EventArgs e)
        {
            RefreshYemekBilgileri();
            RefreshSiparisBilgileri();
            //MessageBox.Show(firma_id.ToString());
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e) // siparişleri görüntüle
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        public void RefreshYemekBilgileri() // Yemek bilgileri listview
        {
            listView2.Items.Clear();
            b = 0;
            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            temel.Open();
            SqlCommand komut = new SqlCommand("select DISTINCT YemekID , YemekAdi , YemekAdedi , YemekFiyat from Yemekler,Firma where Yemekler.FirmaID = Firma.FirmaID and Yemekler.FirmaID = '" + firma_id + "' ", temel);
           
            listView2.View = View.Details;

            if (!refresh)
            {
                listView2.Columns.Add("Yemek ID", 100, HorizontalAlignment.Left);
                listView2.Columns.Add("Yemek Adı", 100, HorizontalAlignment.Left);
                listView2.Columns.Add("Yemek Adedi", 100, HorizontalAlignment.Left);
                listView2.Columns.Add("Yemek Fiyatı", 100, HorizontalAlignment.Left);
            }

            SqlDataReader drr = komut.ExecuteReader();

            ListViewItem li = new ListViewItem();


            while (drr.Read())
            {
                listView2.Items.Add(drr["YemekID"].ToString());
                listView2.Items[b].SubItems.Add(drr["YemekAdi"].ToString());
                listView2.Items[b].SubItems.Add(drr["YemekAdedi"].ToString());
                listView2.Items[b].SubItems.Add(drr["YemekFiyat"].ToString());
                b++;
            }
           
            temel.Close();
        }

        private void button4_Click(object sender, EventArgs e) // yenile butonu
        {
            refresh = true;
            RefreshYemekBilgileri();
            RefreshSiparisBilgileri();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e) // Yemek bilgileri listview
        {
           
        }

        private int firmaKasaBul()
        {
            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            temel.Open();

            string firmaKasa = "select FirmaKasa from Firma where FirmaID like '" + firma_id + "'";

            SqlCommand komutsatirrr = new SqlCommand(firmaKasa, temel);
            SqlDataReader dr = komutsatirrr.ExecuteReader();

            int Kasa = 0;

            if (dr.Read())
            {
                Kasa = dr.GetInt32(0);
            }

            temel.Close();
            return Kasa;
        }

        private int siparisTutar()
        {
            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            temel.Open();

            string durum = "Hazırlanıyor";
            string SiparisTutarı = "select SUM(SiparisTutar) from Siparis where Siparis.FirmaID = '" + firma_id + "' and Siparis.SiparisDurum = '" + durum + "'";       

            SqlCommand komutsatirrr = new SqlCommand(SiparisTutarı, temel);
            SqlDataReader dr = komutsatirrr.ExecuteReader();

            int toplamTutar = 0;

            while (dr.Read())
            {
                toplamTutar = dr.GetInt32(0);
            }

            temel.Close();
            MessageBox.Show("Firma Kasası :" + toplamTutar);

            return toplamTutar;
        }

        private void button5_Click(object sender, EventArgs e) // siparişi teslim et
        {
            if (listView1 != null || siparisTutar() == 0)
            {
                try
                {

                    // firma kasa miktarını bul
                    int yeniKasa = firmaKasaBul() + siparisTutar();

                    SqlConnection temel = new SqlConnection();
                    temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
                    temel.Open();
                    string teslim = "Teslim Edildi";
                    string ürünDurum = "update Siparis set SiparisDurum = '" + teslim + "' where Siparis.FirmaID = '" + firma_id + "' ";

                    SqlCommand komutsatir = new SqlCommand(ürünDurum, temel);
                    komutsatir.ExecuteNonQuery();
                    // bakiye güncelle

                    string firmaBakiyeGüncelle = "update Firma set FirmaKasa = '" + yeniKasa + "' where Firma.FirmaID = '" + firma_id + "' ";

                    komutsatir = new SqlCommand(firmaBakiyeGüncelle, temel);
                    komutsatir.ExecuteNonQuery();

                    temel.Close();
                    refresh = true;
                    RefreshSiparisBilgileri();

                    MessageBox.Show("Firma Kasası :" + yeniKasa);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Server Bağlantı Hatası :" + error);
                }
            }
            else
            {
                MessageBox.Show("Teslim edilecek ürün bulunmamaktadır");
            }
        }
    }
}
