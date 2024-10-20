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
    public partial class tarifeguncelle : Form
    {
        public tarifeguncelle()
        {
            InitializeComponent();
        }


        private void tarifeguncelle_Load(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            islempanelim.Controls.Clear();
            kultarguncel kullan = new kultarguncel();
            kullan.TopLevel = false;
            islempanelim.Controls.Add(kullan);
            kullan.Show();
            kullan.Dock = DockStyle.Fill;
            kullan.BringToFront();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            islempanelim.Controls.Clear();
            mistarguncel misa = new mistarguncel();
            misa.TopLevel = false;
            islempanelim.Controls.Add(misa);
            misa.Show();
            misa.Dock = DockStyle.Fill;
            misa.BringToFront();
        }


    }
}
