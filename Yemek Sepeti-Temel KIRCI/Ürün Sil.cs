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
        Firma firm = new Firma();

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
            temell.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";

            temell.Open();

            string komut1 = "select YemekAdi from Yemekler where YemekAdi ='" + textBox1.Text + "' ";
            SqlCommand komutsatirii = new SqlCommand(komut1, temell);
            komutsatirii.ExecuteNonQuery();

            SqlDataReader drr = komutsatirii.ExecuteReader();

            if (drr.Read()) // yemek bulundu sil
            {
                yemeksil();
                MessageBox.Show("Yemek Silindi.");
                firm.RefreshYemekBilgileri();
                this.Close();
            }
            else // böyle bir yemek bulunamadı
            {
                MessageBox.Show("Böyle bir yemek bulunamadı.");
            }

        }

        private void yemeksil()
        {
            SqlConnection temell = new SqlConnection();
            temell.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            temell.Open();
            string komut = "delete from Yemekler where YemekAdi ='" + textBox1.Text + "' ";

            SqlCommand komutsatiri = new SqlCommand(komut, temell);
            komutsatiri.ExecuteNonQuery();
            temell.Close();
        }

        private void Ürün_Sil_Load(object sender, EventArgs e)
        {

        }
    }
}
