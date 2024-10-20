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
    public partial class kullanicilar : Form
    {
        public kullanicilar()
        {
            InitializeComponent();
        }
        DataTable tablo = new DataTable();
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\otoparkveri.accdb");
        OleDbCommand cmd;
        OleDbDataReader dr;
        MesajKutusu mesaj = new MesajKutusu();

        private void KullaniciListe()
        {
            baglanti.Open();
            tablo.Clear();
            OleDbDataAdapter adap = new OleDbDataAdapter("select * from kullanicilar", baglanti);
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void KullaniciSil()
        {
            cmd = new OleDbCommand();
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "SELECT * FROM kullanicilar where tckimlikno='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (textBox2.Text == "")
            {
                mesaj.mesajlabeli = "Lütfen Plaka No Girin.";
                mesaj.ShowDialog();
                baglanti.Close();
            }
            else if (!dr.Read())
            {
                mesaj.mesajlabeli = "Bu Plakaya Sahip Kullanıcı Bulunmuyor.";
                mesaj.ShowDialog();
                baglanti.Close();
            }
            else
            {
                OleDbCommand komut = new OleDbCommand(); ;
                komut.Connection = baglanti;
                komut.CommandText = "Delete from kullanicilar where tckimlikno='" + textBox2.Text + "'";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                mesaj.mesajlabeli = "Kullanıcı Silindi.";
                mesaj.ShowDialog();
                KullaniciListe();
            }
        }

        private void kullanicilar_Load(object sender, EventArgs e)
        {
            KullaniciListe();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KullaniciSil();
        }

    }
}
