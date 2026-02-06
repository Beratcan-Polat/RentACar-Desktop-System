namespace Arac_Kiralama.UI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCikis = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAracListele = new System.Windows.Forms.Button();
            this.btnKiralama = new System.Windows.Forms.Button();
            this.btnAracKayit = new System.Windows.Forms.Button();
            this.btnSozlesme = new System.Windows.Forms.Button();
            this.btnMusteriListele = new System.Windows.Forms.Button();
            this.btnMusteriEkle = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnCikis);
            this.panel1.Controls.Add(this.btnAracListele);
            this.panel1.Controls.Add(this.btnKiralama);
            this.panel1.Controls.Add(this.btnAracKayit);
            this.panel1.Controls.Add(this.btnSozlesme);
            this.panel1.Controls.Add(this.btnMusteriListele);
            this.panel1.Controls.Add(this.btnMusteriEkle);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 140);
            this.panel1.TabIndex = 0;
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.White;
            this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCikis.ImageIndex = 0;
            this.btnCikis.ImageList = this.ımageList1;
            this.btnCikis.Location = new System.Drawing.Point(822, 12);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(129, 112);
            this.btnCikis.TabIndex = 6;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "ChatGPT Image 25 Ara 2025 20_28_20.png");
            this.ımageList1.Images.SetKeyName(1, "ChatGPT Image 25 Ara 2025 20_26_18.png");
            this.ımageList1.Images.SetKeyName(2, "ChatGPT Image 25 Ara 2025 20_24_54.png");
            this.ımageList1.Images.SetKeyName(3, "ChatGPT Image 25 Ara 2025 20_23_20.png");
            this.ımageList1.Images.SetKeyName(4, "ChatGPT Image 25 Ara 2025 20_20_05.png");
            this.ımageList1.Images.SetKeyName(5, "ChatGPT Image 25 Ara 2025 20_16_23.png");
            this.ımageList1.Images.SetKeyName(6, "ChatGPT Image 25 Ara 2025 20_15_17.png");
            // 
            // btnAracListele
            // 
            this.btnAracListele.BackColor = System.Drawing.Color.White;
            this.btnAracListele.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAracListele.ImageIndex = 3;
            this.btnAracListele.ImageList = this.ımageList1;
            this.btnAracListele.Location = new System.Drawing.Point(417, 12);
            this.btnAracListele.Name = "btnAracListele";
            this.btnAracListele.Size = new System.Drawing.Size(129, 112);
            this.btnAracListele.TabIndex = 3;
            this.btnAracListele.Text = "Araç Lİsteleme";
            this.btnAracListele.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAracListele.UseVisualStyleBackColor = false;
            this.btnAracListele.Click += new System.EventHandler(this.btnAracListele_Click);
            // 
            // btnKiralama
            // 
            this.btnKiralama.BackColor = System.Drawing.Color.White;
            this.btnKiralama.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnKiralama.ImageIndex = 1;
            this.btnKiralama.ImageList = this.ımageList1;
            this.btnKiralama.Location = new System.Drawing.Point(687, 12);
            this.btnKiralama.Name = "btnKiralama";
            this.btnKiralama.Size = new System.Drawing.Size(129, 112);
            this.btnKiralama.TabIndex = 5;
            this.btnKiralama.Text = "Kiralamalar";
            this.btnKiralama.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKiralama.UseVisualStyleBackColor = false;
            this.btnKiralama.Click += new System.EventHandler(this.btnKiralama_Click);
            // 
            // btnAracKayit
            // 
            this.btnAracKayit.BackColor = System.Drawing.Color.White;
            this.btnAracKayit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAracKayit.ImageIndex = 4;
            this.btnAracKayit.ImageList = this.ımageList1;
            this.btnAracKayit.Location = new System.Drawing.Point(282, 12);
            this.btnAracKayit.Name = "btnAracKayit";
            this.btnAracKayit.Size = new System.Drawing.Size(129, 112);
            this.btnAracKayit.TabIndex = 2;
            this.btnAracKayit.Text = "Araç Kayıt";
            this.btnAracKayit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAracKayit.UseVisualStyleBackColor = false;
            this.btnAracKayit.Click += new System.EventHandler(this.btnAracKayit_Click);
            // 
            // btnSozlesme
            // 
            this.btnSozlesme.BackColor = System.Drawing.Color.White;
            this.btnSozlesme.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSozlesme.ImageIndex = 2;
            this.btnSozlesme.ImageList = this.ımageList1;
            this.btnSozlesme.Location = new System.Drawing.Point(552, 12);
            this.btnSozlesme.Name = "btnSozlesme";
            this.btnSozlesme.Size = new System.Drawing.Size(129, 112);
            this.btnSozlesme.TabIndex = 4;
            this.btnSozlesme.Text = "Sözleşme";
            this.btnSozlesme.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSozlesme.UseVisualStyleBackColor = false;
            this.btnSozlesme.Click += new System.EventHandler(this.btnSozlesme_Click);
            // 
            // btnMusteriListele
            // 
            this.btnMusteriListele.BackColor = System.Drawing.Color.White;
            this.btnMusteriListele.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMusteriListele.ImageIndex = 5;
            this.btnMusteriListele.ImageList = this.ımageList1;
            this.btnMusteriListele.Location = new System.Drawing.Point(147, 12);
            this.btnMusteriListele.Name = "btnMusteriListele";
            this.btnMusteriListele.Size = new System.Drawing.Size(129, 112);
            this.btnMusteriListele.TabIndex = 1;
            this.btnMusteriListele.Text = "Müşteri Listeleme";
            this.btnMusteriListele.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMusteriListele.UseVisualStyleBackColor = false;
            this.btnMusteriListele.Click += new System.EventHandler(this.btnMusteriListele_Click);
            // 
            // btnMusteriEkle
            // 
            this.btnMusteriEkle.BackColor = System.Drawing.Color.White;
            this.btnMusteriEkle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMusteriEkle.ImageIndex = 6;
            this.btnMusteriEkle.ImageList = this.ımageList1;
            this.btnMusteriEkle.Location = new System.Drawing.Point(12, 12);
            this.btnMusteriEkle.Name = "btnMusteriEkle";
            this.btnMusteriEkle.Size = new System.Drawing.Size(129, 112);
            this.btnMusteriEkle.TabIndex = 0;
            this.btnMusteriEkle.Text = "Müşteri Ekleme";
            this.btnMusteriEkle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMusteriEkle.UseVisualStyleBackColor = false;
            this.btnMusteriEkle.Click += new System.EventHandler(this.btnMusteriEkle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(971, 525);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnAracListele;
        private System.Windows.Forms.Button btnKiralama;
        private System.Windows.Forms.Button btnAracKayit;
        private System.Windows.Forms.Button btnSozlesme;
        private System.Windows.Forms.Button btnMusteriListele;
        private System.Windows.Forms.Button btnMusteriEkle;
        private System.Windows.Forms.ImageList ımageList1;
    }
}

