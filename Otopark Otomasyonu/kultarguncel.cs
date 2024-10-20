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
    public partial class kultarguncel : Form
    {
        public kultarguncel()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\otoparkveri.accdb");
        MesajKutusu mesaj = new MesajKutusu();
        public void UcretGuncelle()
        {
            if (kul01.Text == "" || kul1224.Text == "" || kul13.Text == ""|| kul2448.Text==""|| kul36.Text=="" ||kul4872.Text==""|| kul612.Text==""|| kuldiger.Text=="")
            {
                mesaj.mesajlabeli = "Gerekli Alanlar Boş Bırakılamaz.";
                mesaj.ShowDialog();
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("update tarifeler set sifirbir='" + kul01.Text + "', biruc='" + kul13.Text +"',ucalti='"+kul36.Text+"',altioniki='"+kul612.Text+"',onikiyirmidort='"+kul1224.Text+"',yirmidortkirksekiz='"+kul2448.Text+"',kirksekizyetmisiki='"+kul4872.Text+"',yuz='"+kuldiger.Text+"' where musteritur='kayitli' ", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                mesaj.mesajlabeli = "Tarife Ücretleri Güncellendi.";
                mesaj.ShowDialog();
                kul01.Clear();
                kul1224.Clear();
                kul13.Clear();
                kul2448.Clear();
                kul36.Clear();
                kul4872.Clear();
                kul612.Clear();
                kuldiger.Clear();
            }
        }

        private void kulbutton_Click(object sender, EventArgs e)
        {
            UcretGuncelle();
        }

        private void kul01_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kul13_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kul36_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kul612_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kul1224_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kul2448_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kul4872_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kuldiger_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
