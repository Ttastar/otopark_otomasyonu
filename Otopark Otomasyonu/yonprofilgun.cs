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
    public partial class yonprofilgun : Form
    {
        public yonprofilgun()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\otoparkveri.accdb");

        MesajKutusu mesaj = new MesajKutusu();

        private void BilgiGuncelle()
        {
            if (textBox1.Text == "" || textBox4.Text == "" || textBox3.Text == "")
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
                OleDbCommand komut = new OleDbCommand("update yoneticikullanici set kullaniciadi='" + textBox1.Text + "', sifre='" + textBox4.Text +  "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                mesaj.mesajlabeli = "Profil Bilgileriniz Güncellendi.";
                mesaj.ShowDialog();
                textBox1.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BilgiGuncelle();
        }
    }
}
