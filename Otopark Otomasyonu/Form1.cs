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
    public partial class Form1 : Form
    {

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\otoparkveri.accdb");

        
        YoneticiAnamenu yonanamenu = new YoneticiAnamenu();
        KayitliKulAnaMenu kayitanamenu = new KayitliKulAnaMenu();
        MisafirKulAnaMenu misafanamenu = new MisafirKulAnaMenu();
        KayitliKulKayitOl kayitol = new KayitliKulKayitOl();
        MesajKutusu mesaj = new MesajKutusu();

        int mov;
        int movX;
        int movY;


        public Form1()
        {
            InitializeComponent();
            tiklapanel1.Height = yongirisbuton.Height;
            tiklapanel1.Top = yongirisbuton.Top;
        }
        private void YoneticiGiris()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from yoneticikullanici where kullaniciadi='" + yontextBox1.Text.ToString() + "'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            if (okuyucu.Read() == true)
            {
                if (yontextBox1.Text.ToString() == okuyucu["kullaniciadi"].ToString() && yontextBox2.Text.ToString() == okuyucu["sifre"].ToString())
                {
                    yonanamenu.Show();
                    this.Hide();
                }
                else
                {
                    mesaj.mesajlabeli = "Kullanıcı Adı veya Şifre Hatalı.";
                    mesaj.ShowDialog();
                    yontextBox1.Clear();
                    yontextBox2.Clear();
                }
            }
            else
            {
                mesaj.mesajlabeli = "Kullanıcı Adı veya Şifre Hatalı.";
                mesaj.ShowDialog();
                yontextBox1.Clear();
                yontextBox2.Clear();
            }
            baglanti.Close();
        }
        private void KayitKulGiris()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from kullanicilar where tckimlikno='" + kayittextBox1.Text.ToString() + "'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            if (okuyucu.Read() == true)
            {
                if (kayittextBox1.Text.ToString() == okuyucu["tckimlikno"].ToString() && kayittextBox2.Text.ToString() == okuyucu["sifre"].ToString())
                {
                    KayitliKulAnaMenu.girilen_plaka = kayittextBox1.Text;
                    kayitanamenu.Show();
                    this.Hide();
                }
                else
                {
                    mesaj.mesajlabeli = "Kullanıcı Adı veya Şifre Hatalı.";
                    mesaj.ShowDialog();
                    kayittextBox1.Clear();
                    kayittextBox2.Clear();
                }
            }
            else
            {
                mesaj.mesajlabeli = "Kullanıcı Adı veya Şifre Hatalı.";
                mesaj.ShowDialog();
                kayittextBox1.Clear();
                kayittextBox2.Clear();
            }
            baglanti.Close();
        }
        private void MisafirGiris()
        {
            if(misafirtextBox1.Text=="")
            {
                mesaj.mesajlabeli = "Lütfen Plaka No Giriniz.";
                mesaj.ShowDialog();
            }
            else
            {
                MisafirKulAnaMenu.misplaka = misafirtextBox1.Text;
                misafanamenu.Show();
                this.Hide();
            }
        }

        private void yongirisbuton_Click(object sender, EventArgs e)
        {
            tiklapanel1.Height = yongirisbuton.Height;
            tiklapanel1.Top = yongirisbuton.Top;
            yonbutton1.Visible = true;
            yonlabel1.Visible = true;
            yonlabel2.Visible = true;
            yonlabel3.Visible = true;
            yonpictureBox.Visible = true;
            yontextBox1.Visible = true;
            yontextBox2.Visible = true;
            yongoz.Visible = true;
            misafirbutton1.Visible = false;
            misafirlabel1.Visible = false;
            misafirlabel2.Visible = false;
            misafirpictureBox1.Visible = false;
            misafirtextBox1.Visible = false;
            kayitbutton1.Visible = false;
            kayitbutton2.Visible = false;
            kayitlabel1.Visible = false;
            kayitlabel2.Visible = false;
            kayitlabel3.Visible = false;
            kayitpictureBox1.Visible = false;
            kayittextBox1.Visible = false;
            kayittextBox2.Visible = false;
            kulgoz.Visible = false;
        }

        private void kayitlikulgirbuton_Click(object sender, EventArgs e)
        {
            tiklapanel1.Height = kayitlikulgirbuton.Height;
            tiklapanel1.Top = kayitlikulgirbuton.Top;
            kayitbutton1.Visible = true;
            kayitbutton2.Visible = true;
            kayitlabel1.Visible = true;
            kayitlabel2.Visible = true;
            kayitlabel3.Visible = true;
            kayitpictureBox1.Visible = true;
            kayittextBox1.Visible = true;
            kayittextBox2.Visible = true;
            kulgoz.Visible = true;
            misafirbutton1.Visible = false;
            misafirlabel1.Visible = false;
            misafirlabel2.Visible = false;
            misafirpictureBox1.Visible = false;
            misafirtextBox1.Visible = false;
            yonbutton1.Visible = false;
            yonlabel1.Visible = false;
            yonlabel2.Visible = false;
            yonlabel3.Visible = false;
            yonpictureBox.Visible = false;
            yontextBox1.Visible = false;
            yontextBox2.Visible = false;
            yongoz.Visible = false;
        }

        private void misafkulgirbuton_Click(object sender, EventArgs e)
        {
            tiklapanel1.Height = misafkulgirbuton.Height;
            tiklapanel1.Top = misafkulgirbuton.Top;
            kayitbutton1.Visible = false;
            kayitbutton2.Visible = false;
            kayitlabel1.Visible = false;
            kayitlabel2.Visible = false;
            kayitlabel3.Visible = false;
            kayitpictureBox1.Visible = false;
            kayittextBox1.Visible = false;
            kayittextBox2.Visible = false;
            kulgoz.Visible = false;
            misafirbutton1.Visible = true;
            misafirlabel1.Visible = true;
            misafirlabel2.Visible = true;
            misafirpictureBox1.Visible = true;
            misafirtextBox1.Visible = true;
            yonbutton1.Visible = false;
            yonlabel1.Visible = false;
            yonlabel2.Visible = false;
            yonlabel3.Visible = false;
            yonpictureBox.Visible = false;
            yontextBox1.Visible = false;
            yontextBox2.Visible = false;
            yongoz.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void yonbutton1_Click(object sender, EventArgs e)
        {
            YoneticiGiris();
        }

        private void kayitbutton2_Click(object sender, EventArgs e)
        {
            KayitKulGiris();
        }

        private void misafirbutton1_Click(object sender, EventArgs e)
        {
            MisafirGiris();
        }

        private void kayitbutton1_Click(object sender, EventArgs e)
        {
            kayitol.ShowDialog();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(mov==1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }

        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void yongoz_MouseDown(object sender, MouseEventArgs e)
        {
            yontextBox2.UseSystemPasswordChar = false;
        }

        private void yongoz_MouseUp(object sender, MouseEventArgs e)
        {
            yontextBox2.UseSystemPasswordChar = true;
        }

        private void kulgoz_MouseDown(object sender, MouseEventArgs e)
        {
            kayittextBox2.UseSystemPasswordChar = false;
        }

        private void kulgoz_MouseUp(object sender, MouseEventArgs e)
        {
            kayittextBox2.UseSystemPasswordChar = true;
        }
    }
}
