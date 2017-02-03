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
        int firma_id = Convert.ToInt32(FirmaGirisEkrani.firmaid);
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
        
        public void listview()
        {
            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = JOKER ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            temel.Open();
            SqlCommand komutt = new SqlCommand("select SiparisID , SiparisAdi , SiparisDurum from Siparis where FirmaID='" + firma_id + "' ", temel);
            
            listView1.View = View.Details;

            listView1.Columns.Add("Sipariş ID", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Ürün Adı", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Ürün Durumu", 100, HorizontalAlignment.Left);

            

            SqlDataReader drr = komutt.ExecuteReader();
            
            ListViewItem li = new ListViewItem();
            

            while (drr.Read())
            {
                listView1.Items.Add(drr["SiparisID"].ToString());
                listView1.Items[a].SubItems.Add(drr["SiparisAdi"].ToString());
                listView1.Items[a].SubItems.Add(drr["SiparisDurum"].ToString());
                
                a++;
            }
            temel.Close();
        }
        
        private void Firma_Load(object sender, EventArgs e)
        {
            
            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = JOKER ; database = YemekSepetiTemelKırcı ; integrated security=true ";

            SqlCommand komut = new SqlCommand("select DISTINCT YemekAdi from Yemekler,Firma where Yemekler.FirmaID = Firma.FirmaID and Yemekler.FirmaID = '" + firma_id + "' ", temel);
            temel.Open();
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                listBox1.Items.Add(dr["YemekAdi"].ToString());
            }
            

            listview();

            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e) // siparişler
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        
    }
}
