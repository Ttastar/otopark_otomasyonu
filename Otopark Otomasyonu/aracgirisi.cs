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
    public partial class aracgirisi : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\otoparkveri.accdb");

        MesajKutusu mesaj = new MesajKutusu();

        public aracgirisi()
        {
            InitializeComponent();
        }

        private void AracBilgiGetir()
        {
            baglanti.Open();
            OleDbCommand komutu = new OleDbCommand("select * from parkyeri where durum like (0)", baglanti);
            OleDbDataReader okuyucu = komutu.ExecuteReader();
            while (okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["parkyeri"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            OleDbCommand komut1 = new OleDbCommand("select distinct plaka from musteri", baglanti);
            OleDbDataReader okuyucu1 = komut1.ExecuteReader();
            while (okuyucu1.Read())
            {
                comboBox2.Items.Add(okuyucu1["plaka"].ToString());
            }
            baglanti.Close();
        }
        private void GirisTamamla()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from musteri where durum='0' and plaka LIKE'" + comboBox2.Text + "'", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            if (dr.Read() || comboBox1.Text == "" || comboBox2.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "")
            {
                if (comboBox2.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "")
                {
                    mesaj.mesajlabeli = "Gerekli Alanlar Boş Bırakılamaz.";
                    mesaj.ShowDialog();
                    baglanti.Close();
                }
                else
                {
                    mesaj.mesajlabeli = "Araç Zaten Otoparka Giriş Yapmış.";
                    mesaj.ShowDialog();
                    baglanti.Close();
                }
            }
            else
            {
                DateTime tarih = DateTime.Now;
                OleDbCommand komut2 = new OleDbCommand("insert into musteri ( park, plaka, marka, model, ad, soyad, telno, gsaat, durum) values ('" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + tarih.ToString() + "','0')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
                baglanti.Open();
                OleDbCommand komut3 = new OleDbCommand("update parkyeri set  durum='1' where parkyeri like '" + comboBox1.Text + "'", baglanti);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                baglanti.Open();
                OleDbCommand komut4 = new OleDbCommand("insert into gecmis ( plaka, ad, soyad, marka, model, park, gsaat) values ('" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + tarih.ToString() + "')", baglanti);
                komut4.ExecuteNonQuery();
                baglanti.Close();
                mesaj.mesajlabeli = "Araç Giriş Kaydı Başarıyla Oluşturuldu.";
                mesaj.ShowDialog();
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox2.Items.Clear();
                comboBox2.Text = "";
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox7.Clear();
                AracBilgiGetir();
            }
        }
        private void MevcutBilgiGetir()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from musteri where plaka LIKE'" + comboBox2.Text + "'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                textBox2.Text = okuyucu["marka"].ToString();
                textBox3.Text = okuyucu["model"].ToString();
                textBox4.Text = okuyucu["ad"].ToString();
                textBox5.Text = okuyucu["soyad"].ToString();
                textBox7.Text = okuyucu["telno"].ToString();
            }
            baglanti.Close();
        }

        private void aracgirisi_Load(object sender, EventArgs e)
        {
            AracBilgiGetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GirisTamamla();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MevcutBilgiGetir();
        }
    }
}
