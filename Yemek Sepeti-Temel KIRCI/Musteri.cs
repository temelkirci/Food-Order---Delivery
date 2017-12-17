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
        public static string welcome;
        public Musteri()
        {
            InitializeComponent();
        }

        private void bakiyeBul()
        {
            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            temel.Open();

            string müsteriBakiye = "select MüsteriBakiye from Müsteri where MüsteriKullanıcıAdı like '" + welcome + "'";

            SqlCommand komutsatirrr = new SqlCommand(müsteriBakiye, temel);
            SqlDataReader dr = komutsatirrr.ExecuteReader();

            int Bakiye = 0;

            if (dr.Read())
            {
                Bakiye = dr.GetInt32(0);
            }

            label3.Text = Convert.ToString(Bakiye) + " TL";
        }

        private void Musteri_Load(object sender, EventArgs e)
        {
            label1.Text = "Hoşgeldin " + welcome;

            timer1.Enabled = true;
            timer1.Interval = 1000; // her 10 mili saniye yemekler kısmını firma adına göre yenile

            bakiyeBul();
        }

        private void button2_Click(object sender, EventArgs e) // sipariş ver
        {
            Siparis_Ver mstr = new Siparis_Ver();
            mstr.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) // sipariş bilgileri
        {
            Siparis_Bilgileri mstr = new Siparis_Bilgileri();
            mstr.ShowDialog();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bakiyeBul();
        }
    }
}
