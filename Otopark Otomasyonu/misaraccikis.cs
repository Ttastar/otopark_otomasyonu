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
    public partial class misaraccikis : Form
    {
        DateTime tarih;
        string parkyeri = "";

        MesajKutusu mesaj = new MesajKutusu();

        public misaraccikis()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\otoparkveri.accdb");
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;

        private List<int> TarifeOku()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("SELECT sifirbir,biruc,ucalti,altioniki,onikiyirmidort,yirmidortkirksekiz,kirksekizyetmisiki,yuz FROM tarifeler WHERE musteritur = 'misafir' ", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            List<int> veriList = new List<int>();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    veriList.Add(dr.GetInt32(i));
                }
            }
            baglanti.Close();
            return veriList;
        }
        private List<int> KulTarifeOku()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("SELECT sifirbir,biruc,ucalti,altioniki,onikiyirmidort,yirmidortkirksekiz,kirksekizyetmisiki,yuz FROM tarifeler WHERE musteritur = 'kayitli' ", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            List<int> kulveriList = new List<int>();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    kulveriList.Add(dr.GetInt32(i));
                }
            }
            baglanti.Close();
            return kulveriList;
        }

        private void AracBilgiGetir()
        {
            comboBox1.Text = MisafirKulAnaMenu.misplaka;
            boslabelucret.Visible = false;
            baglanti.Open();
            OleDbCommand komut2 = new OleDbCommand("select * from musteri where durum='0' and plaka LIKE'" + comboBox1.Text + "'", baglanti);
            OleDbDataReader okuyucu2 = komut2.ExecuteReader();
            if (okuyucu2.Read())
            {
                boslabelmarka.Text = okuyucu2["marka"].ToString();
                boslabelmodel.Text = okuyucu2["model"].ToString();
                boslabelad.Text = okuyucu2["ad"].ToString();
                boslabelsoyad.Text = okuyucu2["soyad"].ToString();
                tarih = Convert.ToDateTime(okuyucu2["gsaat"].ToString());
                parkyeri = okuyucu2["park"].ToString();
            }
            baglanti.Close();
            System.TimeSpan zaman;
            DateTime sondeger = DateTime.Now;
            zaman = sondeger.Subtract(tarih);
            double saat = Convert.ToDouble(zaman.TotalHours);

            List<int> tarife = TarifeOku();

            if (saat < 1)
            {
                boslabelucret.Text = (tarife[0]).ToString() + "₺";
                boslabelucret.Visible = true;
            }
            else if (saat > 1 && saat < 3)
            {
                boslabelucret.Text = (tarife[1]).ToString() + "₺";
                boslabelucret.Visible = true;
            }
            else if (saat > 3 && saat < 6)
            {
                boslabelucret.Text = (tarife[2]).ToString() + "₺";
                boslabelucret.Visible = true;
            }
            else if (saat > 6 && saat < 12)
            {
                boslabelucret.Text = (tarife[3]).ToString() + "₺";
                boslabelucret.Visible = true;
            }
            else if (saat > 12 && saat < 24)
            {
                boslabelucret.Text = (tarife[4]).ToString() + "₺";
                boslabelucret.Visible = true;
            }
            else if (saat > 24 && saat < 48)
            {
                boslabelucret.Text = (tarife[5]).ToString() + "₺";
                boslabelucret.Visible = true;
            }
            else if (saat > 48 && saat < 72)
            {
                boslabelucret.Text = (tarife[6]).ToString() + "₺";
                boslabelucret.Visible = true;
            }
            else
            {
                boslabelucret.Text = (tarife[7]).ToString() + "₺";
            }

        }
        private void CikisTamamla()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=otoparkveri.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM musteri where plaka='" + comboBox1.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                baglanti.Open();
                OleDbCommand komut9 = new OleDbCommand("select * from musteri where durum='0' and plaka='" + comboBox1.Text + "'", baglanti);
                OleDbDataReader dr1 = komut9.ExecuteReader();


                if (dr1.Read())
                {

                    OleDbCommand komut4 = new OleDbCommand("update parkyeri set durum='0' where parkyeri='" + parkyeri + "'", baglanti);
                    komut4.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    OleDbCommand komut5 = new OleDbCommand("update musteri set durum='1' where plaka='" + comboBox1.Text + "'", baglanti);
                    komut5.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    OleDbCommand komut6 = new OleDbCommand("update gecmis set csaat='" + DateTime.Now + "', fiyat='" + boslabelucret.Text + "'where plaka='" + comboBox1.Text + "'", baglanti);
                    komut6.ExecuteNonQuery();
                    baglanti.Close();
                    mesaj.mesajlabeli = "Araç Çıkışı Başarıyla Tamamlandı.";
                    mesaj.ShowDialog();
                    parkyeri = "";
                    ppdDialog2.ShowDialog();
                    boslabelucret.Text = "";
                }
                else
                {
                    mesaj.mesajlabeli = "Arac Otoparkta Mevcut Değil.";
                    mesaj.ShowDialog();
                    baglanti.Close();
                }

            }
            else
            {
                mesaj.mesajlabeli = "Arac Otoparkta Mevcut Değil.";
                mesaj.ShowDialog();
                baglanti.Close();
            }
        }

        private void misaraccikis_Load(object sender, EventArgs e)
        {
            AracBilgiGetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CikisTamamla();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ppdDialog1.ShowDialog();
        }

        Font baslik1 = new Font("Arial Black", 20, FontStyle.Bold);
        Font baslik2 = new Font("Arial Black", 15, FontStyle.Bold);
        Font baslik = new Font("Verdana", 12, FontStyle.Bold);
        Font govde = new Font("Verdana", 12);
        SolidBrush sb = new SolidBrush(Color.Black);

        private void pdYazici2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat Sformat = new StringFormat();
            Sformat.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("FATURA", baslik1, sb, 349, 75);
            e.Graphics.DrawString("----------------------------------------------------------------------------", baslik, sb, 100, 100);
            e.Graphics.DrawString("ARAÇ MARKA ", baslik, sb, 100, 150);
            e.Graphics.DrawString("ARAÇ MODEL", baslik, sb, 100, 200);
            e.Graphics.DrawString("AD", baslik, sb, 100, 250);
            e.Graphics.DrawString("SOYAD", baslik, sb, 100, 300);
            e.Graphics.DrawString("ÜCRET", baslik, sb, 100, 350);

            for (int i = 0; i < 5; i++)
            {
                e.Graphics.DrawString(boslabelmarka.Text, govde, sb, 350, 150);
                e.Graphics.DrawString(boslabelmodel.Text, govde, sb, 350, 200);
                e.Graphics.DrawString(boslabelad.Text, govde, sb, 350, 250);
                e.Graphics.DrawString(boslabelsoyad.Text, govde, sb, 350, 300);
                e.Graphics.DrawString(boslabelucret.Text, govde, sb, 350, 350);
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------", baslik, sb, 100, 400);

        }

        private void pdYazici1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            List<int> tarife = TarifeOku();
            List<int> kultarife = KulTarifeOku();
            StringFormat Sformat = new StringFormat();
            Sformat.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("TARİFE ÜCRETLERİ", baslik1, sb, 250, 75);
            e.Graphics.DrawString("----------------------------------------------------------------------------", baslik, sb, 100, 100);
            e.Graphics.DrawString("MİSAFİR KULLANICI TARİFE ", baslik2, sb, 100, 135);
            e.Graphics.DrawString("0-1 Saat Aralığı ", baslik, sb, 100, 200);
            e.Graphics.DrawString("1-3 Saat Aralığı", baslik, sb, 100, 250);
            e.Graphics.DrawString("3-6 Saat Aralığı", baslik, sb, 100, 300);
            e.Graphics.DrawString("6-12 Saat Aralığı", baslik, sb, 100, 350);
            e.Graphics.DrawString("12-24 Saat Aralığı", baslik, sb, 100, 400);
            e.Graphics.DrawString("24-48 Saat Aralığı", baslik, sb, 100, 450);
            e.Graphics.DrawString("48-72 Saat Aralığı", baslik, sb, 100, 500);
            e.Graphics.DrawString("Diğer Saat Aralıkları", baslik, sb, 100, 550);

            for (int i = 0; i < 8; i++)
            {
                e.Graphics.DrawString((tarife[0]).ToString(), govde, sb, 350, 200);
                e.Graphics.DrawString((tarife[1]).ToString(), govde, sb, 350, 250);
                e.Graphics.DrawString((tarife[2]).ToString(), govde, sb, 350, 300);
                e.Graphics.DrawString((tarife[3]).ToString(), govde, sb, 350, 350);
                e.Graphics.DrawString((tarife[4]).ToString(), govde, sb, 350, 400);
                e.Graphics.DrawString((tarife[5]).ToString(), govde, sb, 350, 450);
                e.Graphics.DrawString((tarife[6]).ToString(), govde, sb, 350, 500);
                e.Graphics.DrawString((tarife[7]).ToString(), govde, sb, 350, 550);
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------", baslik, sb, 100, 590);


            e.Graphics.DrawString("KAYITLI KULLANICI TARİFE ", baslik2, sb, 100, 640);
            e.Graphics.DrawString("0-1 Saat Aralığı ", baslik, sb, 100, 700);
            e.Graphics.DrawString("1-3 Saat Aralığı", baslik, sb, 100, 750);
            e.Graphics.DrawString("3-6 Saat Aralığı", baslik, sb, 100, 800);
            e.Graphics.DrawString("6-12 Saat Aralığı", baslik, sb, 100, 850);
            e.Graphics.DrawString("12-24 Saat Aralığı", baslik, sb, 100, 900);
            e.Graphics.DrawString("24-48 Saat Aralığı", baslik, sb, 100, 950);
            e.Graphics.DrawString("48-72 Saat Aralığı", baslik, sb, 100, 1000);
            e.Graphics.DrawString("Diğer Saat Aralıkları", baslik, sb, 100, 1050);

            for (int i = 0; i < 8; i++)
            {
                e.Graphics.DrawString((kultarife[0]).ToString(), govde, sb, 350, 700);
                e.Graphics.DrawString((kultarife[1]).ToString(), govde, sb, 350, 750);
                e.Graphics.DrawString((kultarife[2]).ToString(), govde, sb, 350, 800);
                e.Graphics.DrawString((kultarife[3]).ToString(), govde, sb, 350, 850);
                e.Graphics.DrawString((kultarife[4]).ToString(), govde, sb, 350, 900);
                e.Graphics.DrawString((kultarife[5]).ToString(), govde, sb, 350, 950);
                e.Graphics.DrawString((kultarife[6]).ToString(), govde, sb, 350, 1000);
                e.Graphics.DrawString((kultarife[7]).ToString(), govde, sb, 350, 1050);
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------", baslik, sb, 100, 1100);
        }
    }
}
