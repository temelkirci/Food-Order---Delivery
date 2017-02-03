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
    
    public partial class FirmaGirisEkrani : Form
    {
        public static string firmaid;
        public FirmaGirisEkrani()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) // firma giriş butonu
        {
            SqlConnection temel = new SqlConnection();
            temel.ConnectionString = "Data Source = JOKER ; database = YemekSepetiTemelKırcı ; integrated security=true ";
            SqlDataAdapter komut = new SqlDataAdapter("Select Count(*) From Firma where FirmaKullanıcıAdı='" + textBox3.Text + "' and FirmaŞifre='" + textBox4.Text + "'", temel);
            
            DataTable dt = new System.Data.DataTable();
            komut.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1") // başarılı giriş yapıldıysa
            {
                temel.Open();
                
                SqlCommand komutt = new SqlCommand("select FirmaID from Firma where FirmaKullanıcıAdı ='" + textBox3.Text + "' and FirmaŞifre='" + textBox4.Text + "'", temel);
                SqlDataReader dr = komutt.ExecuteReader();
                
                while(dr.Read())
                {
                    firmaid = dr["FirmaID"].ToString();
                }

                this.Hide();

                Firma frm = new Firma();
                frm.ShowDialog();
            }
            else // hatalı giriş
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre ..!");
            }
        }

        private void FirmaGirisEkrani_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) // firma kullanıcı adı
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) // firma şifre
        {

        }
    }
}
