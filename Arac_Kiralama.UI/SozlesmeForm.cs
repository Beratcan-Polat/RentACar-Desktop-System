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
    public partial class SozlesmeForm : Form
    {
        private List<Arac> bosAraclar = new List<Arac>();

        public SozlesmeForm()
        {
            InitializeComponent();
            txtTC.TextChanged += txtTC_TextChanged;
            this.Load += SozlesmeForm_Load;
            cmbxAraclar.SelectedIndexChanged += cmbxAraclar_SelectedIndexChanged;
            btnEkle.Click += btnEkle_Click;
            btnGuncelle.Click += btnGuncelle_Click;
            btnTeslim.Click += btnTeslim_Click;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                try {
                    txtTC.Text = row.Cells["Tc"].Value?.ToString();
                    txtAdSoyad.Text = row.Cells["Adsoyad"].Value?.ToString();
                    txtTelefon.Text = row.Cells["Telefon"].Value?.ToString();
                    txtENo.Text = row.Cells["Ehliyetno"].Value?.ToString();
                    txtETarih.Text = row.Cells["ETarih"].Value?.ToString();
                    cmbxAraclar.Text = row.Cells["Plaka"].Value?.ToString();
                    txtMarka.Text = row.Cells["Marka"].Value?.ToString();
                    txtModelAdi.Text = row.Cells["Modeladi"].Value?.ToString();
                    txtModelYili.Text = row.Cells["Modelyili"].Value?.ToString();
                    txtRenk.Text = row.Cells["Renk"].Value?.ToString();
                    cmbxKiraSekli.Text = row.Cells["Kirasekli"].Value?.ToString();
                    txtKiraUcreti.Text = row.Cells["Kiraucreti"].Value?.ToString();
                    txtGun.Text = row.Cells["Gun"].Value?.ToString();
                    txtTutar.Text = row.Cells["Tutar"].Value?.ToString();
                    
                    if(row.Cells["Ctarih"].Value != null)
                        dateCikis.Value = DateTime.Parse(row.Cells["Ctarih"].Value.ToString());
                    
                    if(row.Cells["Dtarih"].Value != null)
                        dateDonus.Value = DateTime.Parse(row.Cells["Dtarih"].Value.ToString());
                } catch { }
            }
        }

        private async void txtTC_TextChanged(object sender, EventArgs e)
        {
            if (txtTC.Text.Length == 11)
            {
                await MusteriGetir(txtTC.Text);
            }
            else
            {
                txtAdSoyad.Clear();
                txtTelefon.Clear();
            }
        }

        private async Task MusteriGetir(string tc)
        {
            string url = "https://localhost:7283/api/musteriler/" + tc;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        Musteri musteri = serializer.Deserialize<Musteri>(json);
                        
                        txtAdSoyad.Text = musteri.AdSoyad;
                        txtTelefon.Text = musteri.Telefon;
                    }
                    else
                    {
                        MessageBox.Show("Bu TC kimlik numarasına ait kayıtlı müşteri bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAdSoyad.Clear();
                        txtTelefon.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri bilgileri getirilirken hata oluştu: " + ex.Message);
            }
        }

        private void cmbxAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxAraclar.SelectedIndex == -1) return;

            string secilenPlaka = cmbxAraclar.SelectedItem.ToString();
            var secilenArac = bosAraclar.FirstOrDefault(x => x.Plaka == secilenPlaka);

            if (secilenArac != null)
            {
                txtMarka.Text = secilenArac.Marka;
                txtModelAdi.Text = secilenArac.ModelAdi;
                txtModelYili.Text = secilenArac.ModelYili;
                txtRenk.Text = secilenArac.Renk;
                txtKiraUcreti.Text = secilenArac.KiraUcreti.ToString();
            }
        }

        private async void SozlesmeForm_Load(object sender, EventArgs e)
        {
            await BosAraclariGetir();
            await SozlesmeleriGetir();
        }

        private async Task BosAraclariGetir()
        {
            string url = "https://localhost:7283/api/araclar";

            try
            {
                var tumAraclar = await Task.Run(async () =>
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.GetStringAsync(url);
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        return serializer.Deserialize<List<Arac>>(response);
                    }
                });

                bosAraclar = tumAraclar.Where(x => x.Durumu == "Boş").ToList();
                cmbxAraclar.Items.Clear();
                foreach (var arac in bosAraclar)
                {
                    cmbxAraclar.Items.Add(arac.Plaka);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Araç listesi alınırken hata oluştu: " + ex.Message);
            }
        }

        private async Task SozlesmeleriGetir()
        {
            string url = "https://localhost:7283/api/sozlesmeler";
            try
            {
                var sozlesmeler = await Task.Run(async () =>
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.GetStringAsync(url);
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        return serializer.Deserialize<List<Sozlesme>>(response);
                    }
                });

                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke(new Action(() => dataGridView1.DataSource = sozlesmeler));
                }
                else
                {
                    dataGridView1.DataSource = sozlesmeler;
                }
            }
            catch (Exception ex) { }
        }

        private async void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Sozlesme sozlesme = new Sozlesme
                {
                    Tc = txtTC.Text,
                    Adsoyad = txtAdSoyad.Text,
                    Telefon = txtTelefon.Text,
                    Ehliyetno = txtENo.Text,
                    ETarih = txtETarih.Text,
                    Plaka = cmbxAraclar.Text,
                    Marka = txtMarka.Text,
                    Modeladi = txtModelAdi.Text,
                    Modelyili = txtModelYili.Text,
                    Renk = txtRenk.Text,
                    Kirasekli = cmbxKiraSekli.Text,
                    Kiraucreti = int.Parse(txtKiraUcreti.Text),
                    Gun = int.Parse(txtGun.Text),
                    Tutar = int.Parse(txtTutar.Text),
                    Ctarih = dateCikis.Value.ToString("yyyy-MM-dd"),
                    Dtarih = dateDonus.Value.ToString("yyyy-MM-dd")
                };

                string url = "https://localhost:7283/api/sozlesmeler";
                using (HttpClient client = new HttpClient())
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string json = serializer.Serialize(sozlesme);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Sözleşme başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        await AracDurumuGuncelle(sozlesme.Plaka, "Dolu");

                        await SozlesmeleriGetir();
                        await BosAraclariGetir();
                        Temizle();
                    }
                    else
                    {
                        string hataDetayi = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Sözleşme eklenemedi. Sunucu Hatası: " + hataDetayi, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private async Task AracDurumuGuncelle(string plaka, string durum)
        {
            try
            {
                string url = "https://localhost:7283/api/araclar/" + plaka;
                using (HttpClient client = new HttpClient())
                {
                    var responseGet = await client.GetAsync(url);
                    if (!responseGet.IsSuccessStatusCode) return;

                    string jsonGet = await responseGet.Content.ReadAsStringAsync();
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    Arac arac = serializer.Deserialize<Arac>(jsonGet);

                    arac.Durumu = durum;

                    string urlPut = "https://localhost:7283/api/araclar";
                    string jsonPut = serializer.Serialize(arac);
                    StringContent content = new StringContent(jsonPut, Encoding.UTF8, "application/json");

                    var responsePut = await client.PutAsync(urlPut, content);
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show("Araç durumu güncellenirken hata: " + ex.Message);
            }
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
             try
            {
                Sozlesme sozlesme = new Sozlesme
                {
                    Tc = txtTC.Text,
                    Adsoyad = txtAdSoyad.Text,
                    Telefon = txtTelefon.Text,
                    Ehliyetno = txtENo.Text,
                    ETarih = txtETarih.Text,
                    Plaka = cmbxAraclar.Text,
                    Marka = txtMarka.Text,
                    Modeladi = txtModelAdi.Text,
                    Modelyili = txtModelYili.Text,
                    Renk = txtRenk.Text,
                    Kirasekli = cmbxKiraSekli.Text,
                    Kiraucreti = int.Parse(txtKiraUcreti.Text),
                    Gun = int.Parse(txtGun.Text),
                    Tutar = int.Parse(txtTutar.Text),
                    Ctarih = dateCikis.Value.ToString("yyyy-MM-dd"),
                    Dtarih = dateDonus.Value.ToString("yyyy-MM-dd")
                };
                
                if(dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells["Id"].Value != null)
                {
                     sozlesme.Id = int.Parse(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
                }

                string url = "https://localhost:7283/api/sozlesmeler";
                using (HttpClient client = new HttpClient())
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string json = serializer.Serialize(sozlesme);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Sözleşme güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await SozlesmeleriGetir();
                        Temizle();
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
        
        private void Temizle()
        {
            txtTC.Clear();
            txtAdSoyad.Clear();
            txtTelefon.Clear();
            txtENo.Clear();
            txtETarih.Clear();
            txtMarka.Clear();
            txtModelAdi.Clear();
            txtModelYili.Clear();
            txtRenk.Clear();
            txtGun.Clear();
            txtTutar.Clear();
            cmbxAraclar.Text = "";
            cmbxKiraSekli.Text = "";
        }

        private async void btnTeslim_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Cells["Id"].Value == null)
                {
                    MessageBox.Show("Lütfen teslim edilecek sözleşmeyi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int sozlesmeId = int.Parse(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
                string plaka = dataGridView1.CurrentRow.Cells["Plaka"].Value?.ToString();

                DialogResult onay = MessageBox.Show("Bu sözleşmeyi sonlandırıp aracı teslim almak istediğinize emin misiniz?", 
                    "Araç Teslim Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (onay == DialogResult.No) return;

                Satis satis = new Satis();
                DataGridViewRow row = dataGridView1.CurrentRow;
                
                try {
                satis.Tc = row.Cells["Tc"].Value?.ToString();
                satis.Adsoyad = row.Cells["Adsoyad"].Value?.ToString();
                satis.Telefon = row.Cells["Telefon"].Value?.ToString();
                satis.Ehliyetno = row.Cells["Ehliyetno"].Value?.ToString();
                satis.ETarih = row.Cells["ETarih"].Value?.ToString();
                satis.Plaka = row.Cells["Plaka"].Value?.ToString();
                satis.Marka = row.Cells["Marka"].Value?.ToString();
                satis.Modeladi = row.Cells["Modeladi"].Value?.ToString();
                satis.Modelyili = row.Cells["Modelyili"].Value?.ToString();
                satis.Renk = row.Cells["Renk"].Value?.ToString();
                satis.Kirasekli = row.Cells["Kirasekli"].Value?.ToString();
                satis.Kiraucreti = Convert.ToInt32(row.Cells["Kiraucreti"].Value);
                satis.Gun = Convert.ToInt32(row.Cells["Gun"].Value);
                satis.Tutar = Convert.ToInt32(row.Cells["Tutar"].Value);
                satis.Ctarih = row.Cells["Ctarih"].Value?.ToString();
                satis.Dtarih = row.Cells["Dtarih"].Value?.ToString();
                } catch { }

                using (HttpClient client = new HttpClient())
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string jsonSatis = serializer.Serialize(satis);
                    StringContent contentSatis = new StringContent(jsonSatis, Encoding.UTF8, "application/json");

                    string urlSatis = "https://localhost:7283/api/satislar";
                    var responseSatis = await client.PostAsync(urlSatis, contentSatis);

                    if (!responseSatis.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Satış geçmişine kaydedilemedi, işlem iptal edildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; 
                    }

                    string urlDelete = "https://localhost:7283/api/sozlesmeler/" + sozlesmeId;
                    var responseSil = await client.DeleteAsync(urlDelete);
                    
                    if (responseSil.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Sözleşme sonlandırıldı, geçmişe kaydedildi ve araç teslim alındı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        if (!string.IsNullOrEmpty(plaka))
                        {
                            await AracDurumuGuncelle(plaka, "Boş");
                        }
                        
                        await SozlesmeleriGetir();
                        await BosAraclariGetir();
                        Temizle();
                    }
                    else
                    {
                        string hata = await responseSil.Content.ReadAsStringAsync();
                        MessageBox.Show("Sözleşme silinirken hata oluştu: " + hata, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan gun = dateDonus.Value - dateCikis.Value;
                int gun2 = gun.Days;

                if(gun2 <= 0) gun2 = 1; 

                txtGun.Text = gun2.ToString();
                
                if(!string.IsNullOrEmpty(txtKiraUcreti.Text))
                {
                     txtTutar.Text = (gun2 * int.Parse(txtKiraUcreti.Text)).ToString();
                }
            }
            catch(Exception ex)
            {
                 MessageBox.Show("Hesaplama hatası: " + ex.Message);
            }
        }
    }
}
