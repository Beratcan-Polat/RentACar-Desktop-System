using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace Arac_Kiralama.UI
{
    public partial class AracEkleForm : Form
    {
        public AracEkleForm()
        {
            InitializeComponent();
            btnAracKaydet.Click += btnAracKaydet_Click;
        }

        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private async void btnAracKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Arac yeniArac = new Arac
                {
                    Plaka = txtPlaka.Text,
                    Marka = txtMarka.Text,
                    ModelAdi = txtModelAdi.Text,
                    ModelYili = txtModelYili.Text,
                    Renk = txtRenk.Text,
                    Km = txtKm.Text,
                    Yakit = cmbxYakit.Text,
                    Vites = cmbxVites.Text,
                    KiraUcreti = int.Parse(txtKiraUcreti.Text),
                    Resim = pictureBox1.ImageLocation,
                    Durumu = "Boş",
                    Tarih = DateTime.Now.ToString("dd.MM.yyyy")
                };

                if (string.IsNullOrEmpty(yeniArac.Plaka))
                {
                    MessageBox.Show("Plaka alanı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await AracEkle(yeniArac);
            }
            catch (FormatException)
            {
                MessageBox.Show("Kira ücreti sayısal bir değer olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task AracEkle(Arac arac)
        {
            string url = "https://localhost:7283/api/araclar";

            using (HttpClient client = new HttpClient())
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string jsonVeri = serializer.Serialize(arac);
                StringContent content = new StringContent(jsonVeri, Encoding.UTF8, "application/json");

                var cevap = await client.PostAsync(url, content);

                if (cevap.IsSuccessStatusCode)
                {
                    MessageBox.Show("Araç başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    string hata = await cevap.Content.ReadAsStringAsync();
                    MessageBox.Show("Araç kaydedilemedi: " + hata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
