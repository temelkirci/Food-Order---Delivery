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
    public partial class Form1 : Form
    {
        SqlConnection temel = new SqlConnection();
        
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // yönetici girişi
        {
            temel.ConnectionString = "Data Source = DESKTOP-QE5C51S ; database = YemekSepetiTemelKırcı ; integrated security=true ";

            Form1 menü = new Form1();
            menü.Close();

            YöneticiEkrani yönetici = new YöneticiEkrani();
            yönetici.Show();

            
        }

        private void button2_Click(object sender, EventArgs e) // firma girişi
        {
            Form1 menü = new Form1();
            menü.Close();

            FirmaGirisEkrani yönetici = new FirmaGirisEkrani();
            yönetici.ShowDialog();

            
        }

        private void button3_Click(object sender, EventArgs e) // müsteri girişi
        {
            Form1 menü = new Form1();
            menü.Close();

            MusteriGirisEkrani yönetici = new MusteriGirisEkrani();
            yönetici.ShowDialog();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
