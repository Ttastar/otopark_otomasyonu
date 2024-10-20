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
    public partial class MesajKutusu : Form
    {
        public string mesajlabeli { get; set; }

        public MesajKutusu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MesajKutusu_Load(object sender, EventArgs e)
        {
            Mesajkutulabel1.Text = mesajlabeli;
        }
    }
}
