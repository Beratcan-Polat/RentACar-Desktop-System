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
    public partial class AracListeleForm : Form
    {
        private List<Arac> tumAraclar = new List<Arac>();

        public AracListeleForm()
        {
            InitializeComponent();
            this.Load += AracListeleForm_Load;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            btnGuncelle.Click += btnGuncelle_Click;
            btnSil.Click += btnSil_Click;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private async void AracListeleForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            await AraclariGetir();
        }

        private async Task AraclariGetir()
        {
            string url = "https://localhost:7283/api/araclar";

            try
            {
                tumAraclar = await Task.Run(async () =>
                {
                    using (HttpClient istemci = new HttpClient())
                    {
                        var cevap = await istemci.GetStringAsync(url);
                        JavaScriptSerializer donusturucu = new JavaScriptSerializer();
                        return donusturucu.Deserialize<List<Arac>>(cevap);
                    }
                });

                Filtrele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Veriler çekilirken bir hata oluştu: " + hata.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrele();
        }

        private void Filtrele()
        {
            if (tumAraclar == null) return;

            List<Arac> filtrelenmisListe = new List<Arac>();

            string secim = comboBox1.Text;

            if (secim == "Tüm Araçlar")
            {
                filtrelenmisListe = tumAraclar;
            }
            else if (secim == "Boş Araçlar")
            {
                filtrelenmisListe = tumAraclar.Where(x => x.Durumu == "Boş").ToList();
            }
            else if (secim == "Kiradaki Araçlar")
            {
                filtrelenmisListe = tumAraclar.Where(x => x.Durumu == "Dolu").ToList();
            }

            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.DataSource = filtrelenmisListe;
                }));
            }
            else
            {
                dataGridView1.DataSource = filtrelenmisListe;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtPlaka.Text = row.Cells["Plaka"].Value.ToString();
                txtMarka.Text = row.Cells["Marka"].Value.ToString();
                txtModelAdi.Text = row.Cells["ModelAdi"].Value.ToString();
                txtModelYili.Text = row.Cells["ModelYili"].Value.ToString();
                txtRenk.Text = row.Cells["Renk"].Value.ToString();
                txtKm.Text = row.Cells["Km"].Value.ToString();
                cmbxYakit.Text = row.Cells["Yakit"].Value.ToString();
                cmbxVites.Text = row.Cells["Vites"].Value.ToString();
                txtKiraUcreti.Text = row.Cells["KiraUcreti"].Value.ToString();
                if (row.Cells["Resim"].Value != null)
                {
                    pictureBox1.ImageLocation = row.Cells["Resim"].Value.ToString();
                }
            }
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
             try
            {
                Arac guncellenenArac = new Arac
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

                string url = "https://localhost:7283/api/araclar";

                using (HttpClient client = new HttpClient())
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string jsonVeri = serializer.Serialize(guncellenenArac);
                    StringContent content = new StringContent(jsonVeri, Encoding.UTF8, "application/json");

                    var cevap = await client.PutAsync(url, content);

                    if (cevap.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Araç bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await AraclariGetir();
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
                string plaka = txtPlaka.Text;
                if (string.IsNullOrEmpty(plaka))
                {
                    MessageBox.Show("Lütfen silinecek aracı seçiniz (Plaka boş olamaz).");
                    return;
                }

                DialogResult onay = MessageBox.Show(plaka + " plakalı aracı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (onay == DialogResult.No) return;

                string url = "https://localhost:7283/api/araclar/" + plaka;

                using (HttpClient client = new HttpClient())
                {
                    var cevap = await client.DeleteAsync(url);

                    if (cevap.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Araç silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await AraclariGetir();
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
             txtPlaka.Clear();
             txtMarka.Clear();
             txtModelAdi.Clear();
             txtModelYili.Clear();
             txtRenk.Clear();
             txtKm.Clear();
             txtKiraUcreti.Clear();
             pictureBox1.Image = null;
        }

        private void btnResimDegistir_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }
    }
}
