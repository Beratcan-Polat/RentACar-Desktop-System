using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Arac_Kiralama.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\KiralamaYonetimi");

                if (key != null)
                {
                    object kayitliKullanici = key.GetValue("SonKullanici");
                    if (kayitliKullanici != null)
                    {
                        txtKullanici.Text = kayitliKullanici.ToString();
                        chkHatirla.Checked = true;
                    }
                }
            }
            catch
            {

            }
        }


        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kAdi = txtKullanici.Text;
            string sifre = txtSifre.Text;

            if (kAdi == "admin" && sifre == "1234")
            {
                if(chkHatirla.Checked)
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\KiralamaYonetimi");
                    key.SetValue("SonKullanici", kAdi);
                }
                else
                {
                    try
                    {
                        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\KiralamaYonetimi", true);
                        if (key != null)
                            key.DeleteValue("SonKullanici");
                    }
                    catch
                    { }
                }

                Form1 anaEkran = new Form1();
                anaEkran.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
    }
}
