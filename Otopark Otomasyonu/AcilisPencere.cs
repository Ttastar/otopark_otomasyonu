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
    public partial class AcilisPencere : Form
    {
        public int sayac;
        public AcilisPencere()
        {
            InitializeComponent();
        }

        private void AcilisPencere_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 5;
            sayac = sayac + 1;
            if (sayac ==20)
            {               
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
                timer1.Stop();
            }
        }
    }
}
