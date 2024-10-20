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
    public partial class KayitliKulKayitOl : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\otoparkveri.accdb");
        OleDbCommand komut =new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;


        MesajKutusu mesaj = new MesajKutusu();
        public KayitliKulKayitOl()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void KayitTamamla()
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                if (textBox1.Text == "")
                {
                    adtik.Visible = false;
                    adcarpi.Visible = true;
                }
                if (textBox2.Text == "")
                {
                    soyadcarpi.Visible = true;
                    soyadtik.Visible = false;
                }
                if (textBox3.Text == "")
                {
                    kuladicarpi.Visible = true;
                    kuladtik.Visible = false;
                }
                if (textBox4.Text == "")
                {
                    sifrecarpi.Visible = true;
                    sifretik.Visible = false;
                }
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    cinsiyetcarpi.Visible = true;
                    cinsiyettik.Visible = false;
                }
                mesaj.mesajlabeli = "Gerekli Alanları Boş Bırakmayınız.";
                mesaj.ShowDialog();
            }
            else if (textBox4.TextLength < 8)
            {
                sifrecarpi.Visible = true;
                sifretik.Visible = false;
                mesaj.mesajlabeli = "Şifre 8 Karakterden Kısa Olamaz.";
                mesaj.ShowDialog();
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    cinsiyet.Text = radioButton1.Text;
                    cinsiyettik.Visible = true;
                    cinsiyetcarpi.Visible = false;
                }
                if (radioButton2.Checked == true)
                {
                    cinsiyet.Text = radioButton2.Text;
                    cinsiyettik.Visible = true;
                    cinsiyetcarpi.Visible = false;
                }
                string tc = textBox3.Text;
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=otoparkveri.accdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM kullanicilar where tckimlikno='" + textBox3.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    mesaj.mesajlabeli = "BU Plaka ile Kayıt Olunamaz.";
                    mesaj.ShowDialog();
                }
                else
                {
                    komut.Connection = baglanti;
                    komut.CommandText = "Insert Into kullanicilar(tckimlikno,sifre,ad,soyad,cinsiyet)Values('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + cinsiyet.Text + "')";
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglanti.Close();

                    mesaj.mesajlabeli = "Kayıt Başarıyla Oluşturuldu.";
                    mesaj.ShowDialog();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    adcarpi.Visible = false;
                    adtik.Visible = false;
                    soyadcarpi.Visible = false;
                    soyadtik.Visible = false;
                    kuladicarpi.Visible = false;
                    kuladtik.Visible = false;
                    sifrecarpi.Visible = false;
                    sifretik.Visible = false;
                    cinsiyetcarpi.Visible = false;
                    cinsiyettik.Visible = false;
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KayitTamamla();
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                adcarpi.Visible = true;
                adtik.Visible = false;
            }
            else
            {
                adcarpi.Visible = false;
                adtik.Visible = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if(textBox2.Text=="")
            {
                soyadcarpi.Visible = true;
                soyadtik.Visible = false;
            }
            else
            {
                soyadcarpi.Visible = false;
                soyadtik.Visible = true;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                kuladicarpi.Visible = true;
                kuladtik.Visible = false;
            }
            else
            {
                kuladtik.Visible = true;
                kuladicarpi.Visible = false;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if(textBox4.TextLength<8)
            {
                sifrecarpi.Visible = true;
                sifretik.Visible = false;
            }
            else
            {
                sifretik.Visible = true;
                sifrecarpi.Visible = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyettik.Visible = true;
            cinsiyetcarpi.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyettik.Visible = true;
            cinsiyetcarpi.Visible = false;
        }

        private void KayitliKulKayitOl_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox4, "Şifreniz 8 karakterden kısa olamaz.");
        }
    }
}
