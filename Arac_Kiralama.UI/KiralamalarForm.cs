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
    public partial class KiralamalarForm : Form
    {
        public KiralamalarForm()
        {
            InitializeComponent();
            this.Load += KiralamalarForm_Load;
        }

        private async void KiralamalarForm_Load(object sender, EventArgs e)
        {
            await TumKiralamalariGetir();
        }

        private async Task TumKiralamalariGetir()
        {
            string url = "https://localhost:7283/api/satislar";
            try
            {
                var satislar = await Task.Run(async () =>
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.GetStringAsync(url);
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        return serializer.Deserialize<List<Satis>>(response);
                    }
                });

                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke(new Action(() => dataGridView1.DataSource = satislar));
                }
                else
                {
                    dataGridView1.DataSource = satislar;
                }

                decimal toplamKazanc = 0;
                foreach (var item in satislar)
                {
                    toplamKazanc += item.Tutar;
                }

                if (lblKazanc.InvokeRequired)
                {
                    lblKazanc.Invoke(new Action(() => lblKazanc.Text = "Toplam Kazanç: " + toplamKazanc.ToString("C2")));
                }
                else
                {
                   lblKazanc.Text = "Toplam Kazanç: " + toplamKazanc.ToString("C2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiralamalar listelenirken hata oluştu: " + ex.Message);
            }
        }
    }
}
