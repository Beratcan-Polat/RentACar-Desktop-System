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
    public partial class MusteriEkleForm : Form
    {
        public MusteriEkleForm()
        {
            InitializeComponent();
            btnMusteriKaydet.Click += btnMusteriKaydet_Click;
        }

        private async void btnMusteriKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Musteri yeniMusteri = new Musteri
                {
                    Tc = txtTc.Text,
                    AdSoyad = txtAdSoyad.Text,
                    Telefon = txtTelefon.Text,
                    Adres = txtAdres.Text,
                    Email = txtMail.Text
                };

                if (string.IsNullOrEmpty(yeniMusteri.Tc) || string.IsNullOrEmpty(yeniMusteri.AdSoyad))
                {
                    MessageBox.Show("Lütfen zorunlu alanları doldurunuz (TC ve Ad Soyad).", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await MusteriEkle(yeniMusteri);
            }
            catch (Exception ex)
            {
                 MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private async Task MusteriEkle(Musteri musteri)
        {
            string url = "https://localhost:7283/api/musteriler";

            using (HttpClient client = new HttpClient())
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string jsonVeri = serializer.Serialize(musteri);
                StringContent content = new StringContent(jsonVeri, Encoding.UTF8, "application/json");

                var cevap = await client.PostAsync(url, content);

                if (cevap.IsSuccessStatusCode)
                {
                    MessageBox.Show("Müşteri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    string hataMesaji = await cevap.Content.ReadAsStringAsync();
                    MessageBox.Show("Kayıt başarısız: " + hataMesaji, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
