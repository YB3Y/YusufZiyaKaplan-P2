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
using System.Data.Common;


namespace _231116032_Yusuf_Ziya_Kaplan_P2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=ZIYA\\SQLEXPRESS;Initial Catalog=\"Aycicegi Pansiyon\";Integrated Security=True;");

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            try 
            { 
                baglanti.Open();
                string sql = "select*from AdminGiris where Kullanici =@Kullaniciadi AND Sifre= @Sifresi";
                SqlParameter prm1 = new SqlParameter("Kullaniciadi", TxtKullaniciAdi.Text);
                SqlParameter prm2 = new SqlParameter("Sifresi", TxtSifre.Text);
                SqlCommand komut =new SqlCommand(sql,baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);

                da.Fill(dt);

                if(dt.Rows.Count > 0) 
                {
                    FrmAnaForm fr = new FrmAnaForm();
                    fr.ShowDialog();
                    this.Hide();
                }
            } 


            catch
            {
                MessageBox.Show("Hatalı Giriş");
            }
        }
    }
}
