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
    public partial class kularacgiris : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\otoparkveri.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;

        MesajKutusu mesajimbu = new MesajKutusu();
        public kularacgiris()
        {
            InitializeComponent();
        }

        private void AracBilgiGetir()
        {
            textBox1.Text = KayitliKulAnaMenu.girilen_plaka;

            baglanti.Open();
            OleDbCommand komutum1 = new OleDbCommand("select * from parkyeri where durum like (0)", baglanti);
            OleDbDataReader okuyucum1 = komutum1.ExecuteReader();
            while (okuyucum1.Read())
            {
                comboBox1.Items.Add(okuyucum1["parkyeri"].ToString());
            }
            baglanti.Close();


            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=otoparkveri.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM musteri where plaka='" + textBox1.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                baglanti.Open();
                OleDbCommand komutum = new OleDbCommand("select * from musteri where durum='1' and plaka LIKE'" + textBox1.Text + "'", baglanti);
                OleDbDataReader okuyucum = komutum.ExecuteReader();
                while (okuyucum.Read())
                {
                    textBox2.Text = okuyucum["marka"].ToString();
                    textBox3.Text = okuyucum["model"].ToString();
                    textBox4.Text = okuyucum["ad"].ToString();
                    textBox5.Text = okuyucum["soyad"].ToString();
                    textBox7.Text = okuyucum["telno"].ToString();
                }
                baglanti.Close();
            }
            else
            {
                mesajimbu.mesajlabeli = "Bilgileriniz Sistemde Mevcut Değil.";
                mesajimbu.ShowDialog();
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox7.Enabled = true;
            }
        }
        private void kularacgiris_Load(object sender, EventArgs e)
        {
            AracBilgiGetir();
        }
        private void GirisTamamla()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from musteri where durum='0' and plaka LIKE'" + textBox1.Text + "'", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            if (dr.Read() || comboBox1.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "")
            {
                if(textBox1.Text=="")
                {
                    mesajimbu.mesajlabeli = "Araç Zaten Otoparka Giriş Yapmış.";
                    mesajimbu.ShowDialog();
                    baglanti.Close();
                }
                if (comboBox1.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "")
                {
                    mesajimbu.mesajlabeli = "Gerekli Alanlar Boş Bırakılamaz.";
                    mesajimbu.ShowDialog();
                    baglanti.Close();
                }
                else
                {
                    mesajimbu.mesajlabeli = "Araç Zaten Otoparka Giriş Yapmış.";
                    mesajimbu.ShowDialog();
                    baglanti.Close();
                }
            }
            else
            {
                DateTime tarih = DateTime.Now;

                OleDbCommand komutum2 = new OleDbCommand("insert into musteri ( park, plaka, marka, model, ad, soyad, telno, gsaat, durum) values ('" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + tarih.ToString() + "','0')", baglanti);
                komutum2.ExecuteNonQuery();
                baglanti.Close();
                baglanti.Open();
                OleDbCommand komutum3 = new OleDbCommand("update parkyeri set  durum='1' where parkyeri like '" + comboBox1.Text + "'", baglanti);
                komutum3.ExecuteNonQuery();
                baglanti.Close();
                baglanti.Open();
                OleDbCommand komutum4 = new OleDbCommand("insert into gecmis ( plaka, ad, soyad, marka, model, park, gsaat) values ('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + tarih.ToString() + "')", baglanti);
                komutum4.ExecuteNonQuery();
                baglanti.Close();
                mesajimbu.mesajlabeli = "Araç Giriş Kaydı Başarıyla Oluşturuldu.";
                mesajimbu.ShowDialog();
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                AracBilgiGetir();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            GirisTamamla();
        }
    }
}
