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
    public partial class YoneticiAnamenu : Form
    {
        int mov1;
        int mov1X;
        int mov1Y;

        public YoneticiAnamenu()
        {
            InitializeComponent();
        }

        private void aracgirisbuton_Click(object sender, EventArgs e)
        {
            tiklapanel2.Height = aracgirisbuton.Height;
            tiklapanel2.Top = aracgirisbuton.Top;
            islempanel.Controls.Clear();
            aracgirisi arcgrs = new aracgirisi();
            arcgrs.TopLevel = false;
            islempanel.Controls.Add(arcgrs);
            arcgrs.Show();
            arcgrs.Dock = DockStyle.Fill;
            arcgrs.BringToFront();
        }

        private void aracgrsbuton_Click(object sender, EventArgs e)
        {
            tiklapanel2.Height = araccikisbuton.Height;
            tiklapanel2.Top = araccikisbuton.Top;
            islempanel.Controls.Clear();
            araccikis cikis = new araccikis();
            cikis.TopLevel = false;
            islempanel.Controls.Add(cikis);
            cikis.Show();
            cikis.Dock = DockStyle.Fill;
            cikis.BringToFront();
        }

        private void aracgecmsbuton_Click(object sender, EventArgs e)
        {
            tiklapanel2.Height = aracgecmsbuton.Height;
            tiklapanel2.Top = aracgecmsbuton.Top;
            islempanel.Controls.Clear();
            aracgecmis gecmis = new aracgecmis();
            gecmis.TopLevel = false;
            islempanel.Controls.Add(gecmis);
            gecmis.Show();
            gecmis.Dock = DockStyle.Fill;
            gecmis.BringToFront();
        }

        private void arackonmbuton_Click(object sender, EventArgs e)
        {
            tiklapanel2.Height = arackonmbuton.Height;
            tiklapanel2.Top = arackonmbuton.Top;
            islempanel.Controls.Clear();
            arackonumlar konum = new arackonumlar();
            konum.TopLevel = false;
            islempanel.Controls.Add(konum);
            konum.Show();
            konum.Dock = DockStyle.Fill;
            konum.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov1 = 1;
            mov1X = e.X;
            mov1Y = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov1 == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mov1X, MousePosition.Y - mov1Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov1 = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 giris =new Form1();
            giris.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tiklapanel2.Height = button3.Height;
            tiklapanel2.Top = button3.Top;
            islempanel.Controls.Clear();
            YoneticiAyarlar ayar = new YoneticiAyarlar();
            ayar.TopLevel = false;
            islempanel.Controls.Add(ayar);
            ayar.Show();
            ayar.Dock = DockStyle.Fill;
            ayar.BringToFront();
        }
    }
}
