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
    public partial class MisafirKulAnaMenu : Form
    {
        public static string misplaka { get; set; }
        public MisafirKulAnaMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void misaracgirisbuton_Click(object sender, EventArgs e)
        {
            tiklapanelmis.Height = misaracgirisbuton.Height;
            tiklapanelmis.Top = misaracgirisbuton.Top;
            misislempanel.Controls.Clear();
            misaracgiris giris = new misaracgiris();
            giris.TopLevel = false;
            misislempanel.Controls.Add(giris);
            giris.Show();
            giris.Dock = DockStyle.Fill;
            giris.BringToFront();
        }

        private void misaraccikisbuton_Click(object sender, EventArgs e)
        {
            tiklapanelmis.Height = misaraccikisbuton.Height;
            tiklapanelmis.Top = misaraccikisbuton.Top;
            misislempanel.Controls.Clear();
            misaraccikis cikma = new misaraccikis();
            cikma.TopLevel = false;
            misislempanel.Controls.Add(cikma);
            cikma.Show();
            cikma.Dock = DockStyle.Fill;
            cikma.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 giris =new Form1();
            giris.Show();
            this.Hide();
        }
    }
}
