using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arac_Kiralama.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            MusteriEkleForm ekle = new MusteriEkleForm();
            ekle.ShowDialog();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnMusteriListele_Click(object sender, EventArgs e)
        {
            MusteriListeleForm listele = new MusteriListeleForm();
            listele.ShowDialog();
        }

        private void btnAracKayit_Click(object sender, EventArgs e)
        {
            AracEkleForm ekle = new AracEkleForm();
            ekle.ShowDialog();
        }

        private void btnAracListele_Click(object sender, EventArgs e)
        {
            AracListeleForm listele = new AracListeleForm();
            listele.ShowDialog();
        }

        private void btnSozlesme_Click(object sender, EventArgs e)
        {
            SozlesmeForm sozlesme = new SozlesmeForm();
            sozlesme.ShowDialog();
        }

        private void btnKiralama_Click(object sender, EventArgs e)
        {
            KiralamalarForm kiralama = new KiralamalarForm();
            kiralama.ShowDialog();
        }
    }
}
