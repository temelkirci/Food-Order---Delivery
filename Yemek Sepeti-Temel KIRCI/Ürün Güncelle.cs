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
    public partial class Ürün_Güncelle : Form
    {
        public Ürün_Güncelle()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) // yeni yemek adı
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) // eklenecek aded
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) // yeni fiyat
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection temell = new SqlConnection();
            temell.ConnectionString = "Data Source = JOKER ; database = YemekSepetiTemelKırcı ; integrated security=true ";

            temell.Open();
            string komut = "update Yemekler set YemekAdi='"+textBox1.Text+"' , YemekFiyat='"+textBox3.Text+"' , YemekAdedi='"+textBox2.Text+"' where YemekAdi='"+textBox4.Text+"' ";

            SqlCommand komutsatiri = new SqlCommand(komut, temell);
            komutsatiri.ExecuteNonQuery();
            temell.Close();
            MessageBox.Show("Yemek başarılı bir şekilde güncellendi.");
        }

        private void textBox4_TextChanged(object sender, EventArgs e) // eski yemek adı
        {

        }

        private void Ürün_Güncelle_Load(object sender, EventArgs e)
        {

        }
    }
}
