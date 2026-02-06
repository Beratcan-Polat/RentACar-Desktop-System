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
    public partial class MusteriListeleForm : Form
    {
        public MusteriListeleForm()
        {
            InitializeComponent();
            this.Load += MusteriListeleForm_Load;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            btnMusteriGuncelle.Click += btnMusteriGuncelle_Click;
            btnSil.Click += btnSil_Click;
        }

        private async void MusteriListeleForm_Load(object sender, EventArgs e)
        {
            await MusterileriGetir();
        }

        private async Task MusterileriGetir()
        {
            string url = "https://localhost:7283/api/musteriler";

            try
            {
                var musteriListesi = await Task.Run(async () =>
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.GetStringAsync(url);
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        return serializer.Deserialize<List<Musteri>>(response);
                    }
                });

                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke(new Action(() =>
                    {
                        dataGridView1.DataSource = musteriListesi;
                    }));
                }
                else
                {
                    dataGridView1.DataSource = musteriListesi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteriler listelenirken hata oluştu: " + ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtTc.Text = row.Cells["Tc"].Value.ToString();
                txtAdSoyad.Text = row.Cells["AdSoyad"].Value.ToString();
                txtTelefon.Text = row.Cells["Telefon"].Value.ToString();
                txtAdres.Text = row.Cells["Adres"].Value.ToString();
                txtMail.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private async void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Musteri guncellenenMusteri = new Musteri
                {
                    Tc = txtTc.Text,
                    AdSoyad = txtAdSoyad.Text,
                    Telefon = txtTelefon.Text,
                    Adres = txtAdres.Text,
                    Email = txtMail.Text
                };

                string url = "https://localhost:7283/api/musteriler";

                using (HttpClient client = new HttpClient())
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string jsonVeri = serializer.Serialize(guncellenenMusteri);
                    StringContent content = new StringContent(jsonVeri, Encoding.UTF8, "application/json");

                    var cevap = await client.PutAsync(url, content);

                    if (cevap.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Müşteri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await MusterileriGetir();
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme başarısız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                string tc = txtTc.Text;
                if (string.IsNullOrEmpty(tc))
                {
                    MessageBox.Show("Lütfen silinecek müşteriyi listeden seçiniz (TC boş olamaz).");
                    return;
                }

                DialogResult onay = MessageBox.Show(tc + " kimlik numaralı müşteriyi silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (onay == DialogResult.No) return;

                string url = "https://localhost:7283/api/musteriler/" + tc;

                using (HttpClient client = new HttpClient())
                {
                    var cevap = await client.DeleteAsync(url);

                    if (cevap.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Müşteri silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await MusterileriGetir();
                        Temizle();
                    }
                    else
                    {
                        MessageBox.Show("Silme işlemi başarısız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void Temizle()
        {
            txtTc.Clear();
            txtAdSoyad.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
            txtMail.Clear();
        }
    }
}
