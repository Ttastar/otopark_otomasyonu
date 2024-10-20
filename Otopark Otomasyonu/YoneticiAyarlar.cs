using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark_Otomasyonu
{
    public partial class YoneticiAyarlar : Form
    {
        public YoneticiAyarlar()
        {
            InitializeComponent();
        }

        private void araccikisbuton_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            kullanicilar kullanici = new kullanicilar();
            kullanici.TopLevel = false;
            panel2.Controls.Add(kullanici);
            kullanici.Show();
            kullanici.Dock = DockStyle.Fill;
            kullanici.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            tarifeguncelle tarife = new tarifeguncelle();
            tarife.TopLevel = false;
            panel2.Controls.Add(tarife);
            tarife.Show();
            tarife.Dock = DockStyle.Fill;
            tarife.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            yonprofilgun profil = new yonprofilgun();
            profil.TopLevel = false;
            panel2.Controls.Add(profil);
            profil.Show();
            profil.Dock = DockStyle.Fill;
            profil.BringToFront();
        }
    }
}
