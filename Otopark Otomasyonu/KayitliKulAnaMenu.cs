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
    public partial class KayitliKulAnaMenu : Form
    {
        int mov2;
        int mov2X;
        int mov2Y;
        public static string girilen_plaka { get; set; }

        public KayitliKulAnaMenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov2 = 1;
            mov2X = e.X;
            mov2Y = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(mov2==1)
            {
                this.SetDesktopLocation(MousePosition.X - mov2X, MousePosition.Y - mov2Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov2 = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tiklapanel3.Height = button3.Height;
            tiklapanel3.Top = button3.Top;
            kulislempanel.Controls.Clear();
            kularacgiris giris = new kularacgiris();
            giris.TopLevel = false;
            kulislempanel.Controls.Add(giris);
            giris.Show();
            giris.Dock = DockStyle.Fill;
            giris.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tiklapanel3.Height = button5.Height;
            tiklapanel3.Top = button5.Top;
            kulislempanel.Controls.Clear();
            kularaccikis cikis = new kularaccikis();
            cikis.TopLevel = false;
            kulislempanel.Controls.Add(cikis);
            cikis.Show();
            cikis.Dock = DockStyle.Fill;
            cikis.BringToFront();
        }

        private void kaykularcgcmsbuton_Click_1(object sender, EventArgs e)
        {
            tiklapanel3.Height = kaykularcgcmsbuton.Height;
            tiklapanel3.Top = kaykularcgcmsbuton.Top;
            kulislempanel.Controls.Clear();
            kularacgecmis gecmis = new kularacgecmis();
            gecmis.TopLevel = false;
            kulislempanel.Controls.Add(gecmis);
            gecmis.Show();
            gecmis.Dock = DockStyle.Fill;
            gecmis.BringToFront();
        }

        private void kaykulprflbuton_Click_1(object sender, EventArgs e)
        {
            tiklapanel3.Height = kaykulprflbuton.Height;
            tiklapanel3.Top = kaykulprflbuton.Top;
            kulislempanel.Controls.Clear();
            kulprofilbilgi profil = new kulprofilbilgi();
            profil.TopLevel = false;
            kulislempanel.Controls.Add(profil);
            profil.Show();
            profil.Dock = DockStyle.Fill;
            profil.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 giris =new Form1();
            giris.Show();
            this.Hide();
        }
    }
}
