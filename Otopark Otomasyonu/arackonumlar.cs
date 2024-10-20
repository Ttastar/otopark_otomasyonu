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
    public partial class arackonumlar : Form
    {
        public arackonumlar()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\otoparkveri.accdb");

        private void KonumDurumu()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from parkyeri,musteri where parkyeri.parkyeri=musteri.park and musteri.durum='0'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu["park"].ToString() == "A1")
                {
                    pictureBox16.BackColor = Color.Firebrick;
                    labelA1.BackColor = Color.Firebrick;
                    labelA1.ForeColor = Color.White;
                    boslabelA1.Text = okuyucu["plaka"].ToString();
                    boslabelA1.BackColor = Color.Firebrick;
                    boslabelA1.ForeColor = Color.White;
                }
                if (okuyucu["park"].ToString() == "A2")
                {
                    pictureBox1.BackColor = Color.Firebrick;
                    labelA2.BackColor = Color.Firebrick;
                    labelA2.ForeColor = Color.White;
                    boslabelA2.Text = okuyucu["plaka"].ToString();
                    boslabelA2.BackColor = Color.Firebrick;
                    boslabelA2.ForeColor = Color.White;
                }
                if (okuyucu["park"].ToString() == "A3")
                {
                    pictureBox2.BackColor = Color.Firebrick;
                    labelA3.BackColor = Color.Firebrick;
                    labelA3.ForeColor = Color.White;
                    boslabelA3.Text = okuyucu["plaka"].ToString();
                    boslabelA3.BackColor = Color.Firebrick;
                    boslabelA3.ForeColor = Color.White;
                }
                if (okuyucu["park"].ToString() == "A4")
                {
                    pictureBox3.BackColor = Color.Firebrick;
                    labelA4.BackColor = Color.Firebrick;
                    labelA4.ForeColor = Color.White;
                    boslabelA4.Text = okuyucu["plaka"].ToString();
                    boslabelA4.BackColor = Color.Firebrick;
                    boslabelA4.ForeColor = Color.White;
                }
                if (okuyucu["park"].ToString() == "A5")
                {
                    pictureBox4.BackColor = Color.Firebrick;
                    labelA5.BackColor = Color.Firebrick;
                    labelA5.ForeColor = Color.White;
                    boslabelA5.Text = okuyucu["plaka"].ToString();
                    boslabelA5.BackColor = Color.Firebrick;
                    boslabelA5.ForeColor = Color.White;

                }
                if (okuyucu["park"].ToString() == "A6")
                {
                    pictureBox10.BackColor = Color.Firebrick;
                    labelA6.BackColor = Color.Firebrick;
                    labelA6.ForeColor = Color.White;
                    boslabelA6.Text = okuyucu["plaka"].ToString();
                    boslabelA6.BackColor = Color.Firebrick;
                    boslabelA6.ForeColor = Color.White;
                }
                if (okuyucu["park"].ToString() == "A7")
                {
                    pictureBox5.BackColor = Color.Firebrick;
                    labelA7.BackColor = Color.Firebrick;
                    labelA7.ForeColor = Color.White;
                    boslabelA7.Text = okuyucu["plaka"].ToString();
                    boslabelA7.BackColor = Color.Firebrick;
                    boslabelA7.ForeColor = Color.White;
                }
                if (okuyucu["park"].ToString() == "A8")
                {
                    pictureBox6.BackColor = Color.Firebrick;
                    labelA8.BackColor = Color.Firebrick;
                    labelA8.ForeColor = Color.White;
                    boslabelA8.Text = okuyucu["plaka"].ToString();
                    boslabelA8.BackColor = Color.Firebrick;
                    boslabelA8.ForeColor = Color.White;
                }
                if (okuyucu["park"].ToString() == "A9")
                {
                    pictureBox7.BackColor = Color.Firebrick;
                    labelA9.BackColor = Color.Firebrick;
                    labelA9.ForeColor = Color.White;
                    boslabelA9.Text = okuyucu["plaka"].ToString();
                    boslabelA9.BackColor = Color.Firebrick;
                    boslabelA9.ForeColor = Color.White;
                }
                if (okuyucu["park"].ToString() == "A10")
                {
                    pictureBox8.BackColor = Color.Firebrick;
                    labelA10.BackColor = Color.Firebrick;
                    labelA10.ForeColor = Color.White;
                    boslabelA10.Text = okuyucu["plaka"].ToString();
                    boslabelA10.BackColor = Color.Firebrick;
                    boslabelA10.ForeColor = Color.White;
                }
                if (okuyucu["park"].ToString() == "A11")
                {
                    pictureBox15.BackColor = Color.Firebrick;
                    labelA11.BackColor = Color.Firebrick;
                    labelA11.ForeColor = Color.White;
                    boslabelA11.Text = okuyucu["plaka"].ToString();
                    boslabelA11.BackColor = Color.Firebrick;
                    boslabelA11.ForeColor = Color.White;
                }
                if (okuyucu["park"].ToString() == "A12")
                {
                    pictureBox9.BackColor = Color.Firebrick;
                    labelA12.BackColor = Color.Firebrick;
                    labelA12.ForeColor = Color.White;
                    boslabelA12.Text = okuyucu["plaka"].ToString();
                    boslabelA12.BackColor = Color.Firebrick;
                    boslabelA12.ForeColor = Color.White;
                }
                if (okuyucu["park"].ToString() == "A13")
                {
                    pictureBox11.BackColor = Color.Firebrick;
                    labelA13.BackColor = Color.Firebrick;
                    labelA13.ForeColor = Color.White;
                    boslabelA13.Text = okuyucu["plaka"].ToString();
                    boslabelA13.BackColor = Color.Firebrick;
                    boslabelA13.ForeColor = Color.White;
                }
                if (okuyucu["park"].ToString() == "A14")
                {
                    pictureBox12.BackColor = Color.Firebrick;
                    labelA14.BackColor = Color.Firebrick;
                    labelA14.ForeColor = Color.White;
                    boslabelA14.Text = okuyucu["plaka"].ToString();
                    boslabelA14.BackColor = Color.Firebrick;
                    boslabelA14.ForeColor = Color.White;
                }
                if (okuyucu["park"].ToString() == "A15")
                {
                    pictureBox13.BackColor = Color.Firebrick;
                    labelA15.BackColor = Color.Firebrick;
                    labelA15.ForeColor = Color.White;
                    boslabelA15.Text = okuyucu["plaka"].ToString();
                    boslabelA15.BackColor = Color.Firebrick;
                    boslabelA15.ForeColor = Color.White;
                }
            }
            baglanti.Close();

        }
        private void arackonumlar_Load(object sender, EventArgs e)
        {
            KonumDurumu();
        }
    }
}
