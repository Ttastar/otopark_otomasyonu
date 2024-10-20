using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Otopark_Otomasyonu
{
    public partial class kulprofilbilgi : Form
    {
        MesajKutusu mesaj = new MesajKutusu();
        public kulprofilbilgi()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\otoparkveri.accdb");

        private void bilgi()
        {
            baglanti.Open();
            OleDbCommand komutum = new OleDbCommand("select * from kullanicilar where tckimlikno LIKE'" + label7.Text + "'", baglanti);
            OleDbDataReader okuyucum = komutum.ExecuteReader();
            while (okuyucum.Read())
            {
                textBox1.Text = okuyucum["ad"].ToString();
                textBox2.Text = okuyucum["soyad"].ToString();
                textBox4.Text = okuyucum["sifre"].ToString();
                textBox3.Text = okuyucum["sifre"].ToString();
            }
            baglanti.Close();
        }

        private void BilgiGuncelle()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                mesaj.mesajlabeli = "Gerekli Alanlar Boş Bırakılamaz.";
                mesaj.ShowDialog();
            }
            else if (textBox3.Text != textBox4.Text)
            {
                mesaj.mesajlabeli = "Şifreler Uyuşmuyor.";
                mesaj.ShowDialog();
            }
            else if (textBox3.TextLength < 8 && textBox4.TextLength < 8)
            {
                mesaj.mesajlabeli = "Şifreniz 8 Karakterden Kısa Olamaz.";
                mesaj.ShowDialog();
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("update kullanicilar set sifre='" + textBox3.Text + "', ad='" + textBox1.Text + "', soyad='" + textBox2.Text + "'where tckimlikno='" + label7.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                mesaj.mesajlabeli = "Profil Bilgileriniz Güncellendi.";
                mesaj.ShowDialog();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BilgiGuncelle();
        }

        private void kulprofilbilgi_Load(object sender, EventArgs e)
        {
            label7.Text = KayitliKulAnaMenu.girilen_plaka;
            bilgi();
        }
    }
}
