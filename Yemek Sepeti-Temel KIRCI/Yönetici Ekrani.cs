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
    public partial class YöneticiEkrani : Form
    {
        
        public YöneticiEkrani()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e) // yönetici şifre
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e) // yönetici kullanıcı adı
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            SqlDataAdapter komut = new SqlDataAdapter("Select Count(*) From Yönetici where YöneticiKullanıcıAdı='" + textBox5.Text + "' and YöneticiŞifre='" + textBox6.Text + "'", temel);
            DataTable dt = new System.Data.DataTable();
            komut.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1") // başarılı giriş yapıldıysa
            {
              
                Yönetici yntc = new Yönetici();
                yntc.ShowDialog();

            }
            else // hatalı giriş
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre ..!");
            }
                
        }

        private void YöneticiEkrani_Load(object sender, EventArgs e)
        {

        }


    }
}
