using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace _231116032_Yusuf_Ziya_Kaplan_P2
{
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=ZIYA\\SQLEXPRESS;Initial Catalog=\"Aycicegi Pansiyon\";Integrated Security=True;");


        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            int personel;
            personel = Convert.ToInt16(TxtPersonelSayisi.Text);
            lblPersonelMaas.Text = (personel * 17500).ToString();
            int sonuc;
            sonuc=Convert.ToInt32(lblKasaToplam.Text)-(Convert.ToInt32(lblPersonelMaas.Text)+Convert.ToInt32(lblAlinanUrunler1.Text)+Convert.ToInt32(lblAlinanUrunler2.Text)+ Convert.ToInt32(lblAlinanUrunler3.Text)+ Convert.ToInt32(lblFaturalar1.Text)+ Convert.ToInt32(lblFaturalar2.Text) + Convert.ToInt32(lblFaturalar3.Text));
            lblSonuc.Text = sonuc.ToString();
        }

        private void FrmGelirGider_Load(object sender, EventArgs e)
        {
            // Kasadaki Toplam Tutar
            baglanti.Open();
            SqlCommand komut = new SqlCommand(" Select sum (Ucret) as toplam from MusteriEkle", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblKasaToplam.Text = oku["toplam"].ToString();
            }
            baglanti.Close();

            // Gıda Giderleri

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand(" Select sum (Gida) as toplam1 from Stoklar", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                lblAlinanUrunler1.Text = oku2["toplam1"].ToString();
            }
            baglanti.Close();

            //İçeçekler
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand(" Select sum (İcecek) as toplam2 from Stoklar", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                lblAlinanUrunler2.Text = oku3["toplam2"].ToString();
            }
            baglanti.Close();

            //  Cerezler
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand(" Select sum (Cerezler) as toplam3 from Stoklar", baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                lblAlinanUrunler3.Text = oku4["toplam3"].ToString();
            }
            baglanti.Close();

            //Elektirik

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand(" Select sum (Elektirik) as toplam4 from Faturalar", baglanti);
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                lblFaturalar1.Text = oku5["toplam4"].ToString();
            }
            baglanti.Close();

            //Su

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand(" Select sum (Elektirik) as toplam5 from Faturalar", baglanti);
            SqlDataReader oku6 = komut6.ExecuteReader();
            while (oku6.Read())
            {
                lblFaturalar2.Text = oku6["toplam5"].ToString();
            }
            baglanti.Close();

            //İnternet

            baglanti.Open();
            SqlCommand komut7 = new SqlCommand(" Select sum (Elektirik) as toplam6 from Faturalar", baglanti);
            SqlDataReader oku7 = komut7.ExecuteReader();
            while (oku7.Read())
            {
                lblFaturalar3.Text = oku7["toplam6"].ToString();
            }
            baglanti.Close();




        }

        private void TxtPersonelSayisi_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
