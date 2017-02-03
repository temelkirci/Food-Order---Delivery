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
    public partial class Musteri : Form
    {
        public static string siparis_id;
        public Musteri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // sipariş kontrol et
        {
            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = JOKER ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            temel.Open();
            SqlCommand komut = new SqlCommand("select SiparisDurum from Siparis where SiparisID = '" + siparis_id + "' ", temel);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                MessageBox.Show(dr["SiparisDurum"].ToString());
            }
        }

        private void Musteri_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // sipariş ver
        {

            Siparis_Ver mstr = new Siparis_Ver();
            mstr.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // SİPARİS ID
        {
            siparis_id = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e) // sipariş bilgileri
        {

            Siparis_Bilgileri mstr = new Siparis_Bilgileri();
            mstr.ShowDialog();
        }
    }
}
