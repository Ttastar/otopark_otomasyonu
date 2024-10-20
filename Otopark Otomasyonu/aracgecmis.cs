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
    public partial class aracgecmis : Form
    {
        public aracgecmis()
        {
            InitializeComponent();
        }

        DataTable tablo = new DataTable();
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\otoparkveri.accdb");

        private void GecmisGetir()
        {
            baglanti.Open();
            tablo.Clear();
            OleDbDataAdapter adap = new OleDbDataAdapter("select * from gecmis", baglanti);
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void PlakaGecmis()
        {
            baglanti.Open();
            tablo.Clear();
            OleDbDataAdapter adap = new OleDbDataAdapter("select * from gecmis where plaka='" + textBox2.Text + "'", baglanti);
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void aracgecmis_Load(object sender, EventArgs e)
        {
            GecmisGetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlakaGecmis();
        }
    }
}
