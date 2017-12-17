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
    public partial class Siparis_Bilgileri : Form
    {
        int a = 0;

        string mus_id = MusteriGirisEkrani.musteriid;
       
        public Siparis_Bilgileri()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // sipariş adı
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) // sipariş miktarı
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) // sipariş durumu
        {

        }
        public void listview()
        {
            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            temel.Open();
            SqlCommand komutt = new SqlCommand("select SiparisAdi , SiparisAdet , SiparisDurum from Siparis where MüsteriID='" + mus_id + "' ", temel);

            listView1.View = View.Details;

            listView1.Columns.Add("Siparis Adı", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Siparis Adedi", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Siparis Durumu", 100, HorizontalAlignment.Left);



            SqlDataReader drr = komutt.ExecuteReader();

            ListViewItem li = new ListViewItem();


            while (drr.Read())
            {
                listView1.Items.Add(drr["SiparisAdi"].ToString());
                listView1.Items[a].SubItems.Add(drr["SiparisAdet"].ToString());
                listView1.Items[a].SubItems.Add(drr["SiparisDurum"].ToString());

                a++;
            }
            temel.Close();
        }
        private void Siparis_Bilgileri_Load(object sender, EventArgs e)
        {

            listview();    

        }

        private void label6_Click(object sender, EventArgs e) // toplam tutar
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)// listview
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
