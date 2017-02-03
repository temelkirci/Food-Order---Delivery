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
    public partial class Ürün_Sil : Form
    {
        public Ürün_Sil()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // ürün adı
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection temell = new SqlConnection();
            temell.ConnectionString = "Data Source = JOKER ; database = YemekSepetiTemelKırcı ; integrated security=true ";

            temell.Open();
            string komut = "delete from Yemekler where YemekAdi='" + textBox1.Text + "' ";

            SqlCommand komutsatiri = new SqlCommand(komut, temell);
            komutsatiri.ExecuteNonQuery();
            temell.Close();
            MessageBox.Show("Yemek başarılı bir şekilde silindi.");
        }

        private void Ürün_Sil_Load(object sender, EventArgs e)
        {

        }
    }
}
