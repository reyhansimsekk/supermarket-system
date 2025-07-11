namespace SupermarketApp.Forms
{
    partial class frmSatis
    {
        private System.ComponentModel.IContainer components = null;
        private GroupBox groupBoxSepet;
        private GroupBox groupBoxOdeme;
        private GroupBox groupBoxUrunEkle;
        private GroupBox groupBoxUrunler;
        
        private DataGridView dataGridView1;
        private FlowLayoutPanel flowLayoutProducts;
        
        private Label lblBarkod;
        private TextBox txtBarkod;
        private Button btnUrunEkle;
        private Button btnUrunCikar;
        
        private RadioButton rdbNakit;
        private RadioButton rdbKart;
        
        private Label lblToplamTutar;
        private Label lblIndirimTutari;
        private Label lblNetTutar;
        private Label lblKasiyer;
        private Label lblSatisZamani;
        
        private Button btnSatisOnayla;
        private Button btnSatisIptal;
        private Button btnKapat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxSepet = new GroupBox();
            this.groupBoxOdeme = new GroupBox();
            this.groupBoxUrunEkle = new GroupBox();
            this.groupBoxUrunler = new GroupBox();
            
            this.dataGridView1 = new DataGridView();
            this.flowLayoutProducts = new FlowLayoutPanel();
            
            this.lblBarkod = new Label();
            this.txtBarkod = new TextBox();
            this.btnUrunEkle = new Button();
            this.btnUrunCikar = new Button();
            
            this.rdbNakit = new RadioButton();
            this.rdbKart = new RadioButton();
            
            this.lblToplamTutar = new Label();
            this.lblIndirimTutari = new Label();
            this.lblNetTutar = new Label();
            this.lblKasiyer = new Label();
            this.lblSatisZamani = new Label();
            
            this.btnSatisOnayla = new Button();
            this.btnSatisIptal = new Button();
            this.btnKapat = new Button();
            
            this.groupBoxSepet.SuspendLayout();
            this.groupBoxOdeme.SuspendLayout();
            this.groupBoxUrunEkle.SuspendLayout();
            this.groupBoxUrunler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            
            // groupBoxUrunEkle
            this.groupBoxUrunEkle.Controls.Add(this.btnUrunCikar);
            this.groupBoxUrunEkle.Controls.Add(this.btnUrunEkle);
            this.groupBoxUrunEkle.Controls.Add(this.txtBarkod);
            this.groupBoxUrunEkle.Controls.Add(this.lblBarkod);
            this.groupBoxUrunEkle.Dock = DockStyle.Top;
            this.groupBoxUrunEkle.Location = new Point(0, 0);
            this.groupBoxUrunEkle.Name = "groupBoxUrunEkle";
            this.groupBoxUrunEkle.Size = new Size(884, 80);
            this.groupBoxUrunEkle.TabIndex = 0;
            this.groupBoxUrunEkle.TabStop = false;
            this.groupBoxUrunEkle.Text = "Ürün Ekle";
            
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Location = new Point(15, 35);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new Size(39, 13);
            this.lblBarkod.TabIndex = 0;
            this.lblBarkod.Text = "Barkod:";
            
            this.txtBarkod.Location = new Point(70, 32);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new Size(300, 20);
            this.txtBarkod.TabIndex = 1;
            this.txtBarkod.KeyPress += new KeyPressEventHandler(this.txtBarkod_KeyPress);
            
            this.btnUrunEkle.BackColor = Color.FromArgb(40, 167, 69);
            this.btnUrunEkle.FlatStyle = FlatStyle.Flat;
            this.btnUrunEkle.ForeColor = Color.White;
            this.btnUrunEkle.Location = new Point(390, 30);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new Size(100, 25);
            this.btnUrunEkle.TabIndex = 2;
            this.btnUrunEkle.Text = "Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = false;
            this.btnUrunEkle.Click += new EventHandler(this.btnUrunEkle_Click);
            
            this.btnUrunCikar.BackColor = Color.FromArgb(220, 53, 69);
            this.btnUrunCikar.FlatStyle = FlatStyle.Flat;
            this.btnUrunCikar.ForeColor = Color.White;
            this.btnUrunCikar.Location = new Point(510, 30);
            this.btnUrunCikar.Name = "btnUrunCikar";
            this.btnUrunCikar.Size = new Size(100, 25);
            this.btnUrunCikar.TabIndex = 3;
            this.btnUrunCikar.Text = "Ürün Çıkar";
            this.btnUrunCikar.UseVisualStyleBackColor = false;
            this.btnUrunCikar.Click += new EventHandler(this.btnUrunCikar_Click);
            
            // groupBoxUrunler  
            this.groupBoxUrunler.Controls.Add(this.flowLayoutProducts);
            this.groupBoxUrunler.Dock = DockStyle.Left;
            this.groupBoxUrunler.Location = new Point(0, 80);
            this.groupBoxUrunler.Name = "groupBoxUrunler";
            this.groupBoxUrunler.Size = new Size(450, 421);
            this.groupBoxUrunler.TabIndex = 1;
            this.groupBoxUrunler.TabStop = false;
            this.groupBoxUrunler.Text = "Ürünler";
            
            // flowLayoutProducts
            this.flowLayoutProducts.AutoScroll = true;
            this.flowLayoutProducts.Dock = DockStyle.Fill;
            this.flowLayoutProducts.Location = new Point(3, 16);
            this.flowLayoutProducts.Name = "flowLayoutProducts";
            this.flowLayoutProducts.Size = new Size(444, 402);
            this.flowLayoutProducts.TabIndex = 0;
            
            // groupBoxSepet
            this.groupBoxSepet.Controls.Add(this.dataGridView1);
            this.groupBoxSepet.Dock = DockStyle.Fill;
            this.groupBoxSepet.Location = new Point(450, 80);
            this.groupBoxSepet.Name = "groupBoxSepet";
            this.groupBoxSepet.Size = new Size(434, 421);
            this.groupBoxSepet.TabIndex = 2;
            this.groupBoxSepet.TabStop = false;
            this.groupBoxSepet.Text = "Alışveriş Sepeti";
            
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.Location = new Point(3, 16);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(428, 402);
            this.dataGridView1.TabIndex = 0;
            
            // groupBoxOdeme
            this.groupBoxOdeme.Controls.Add(this.btnKapat);
            this.groupBoxOdeme.Controls.Add(this.btnSatisIptal);
            this.groupBoxOdeme.Controls.Add(this.btnSatisOnayla);
            this.groupBoxOdeme.Controls.Add(this.lblSatisZamani);
            this.groupBoxOdeme.Controls.Add(this.lblKasiyer);
            this.groupBoxOdeme.Controls.Add(this.lblNetTutar);
            this.groupBoxOdeme.Controls.Add(this.lblIndirimTutari);
            this.groupBoxOdeme.Controls.Add(this.lblToplamTutar);
            this.groupBoxOdeme.Controls.Add(this.rdbKart);
            this.groupBoxOdeme.Controls.Add(this.rdbNakit);
            this.groupBoxOdeme.Dock = DockStyle.Bottom;
            this.groupBoxOdeme.Location = new Point(0, 501);
            this.groupBoxOdeme.Name = "groupBoxOdeme";
            this.groupBoxOdeme.Size = new Size(884, 150);
            this.groupBoxOdeme.TabIndex = 3;
            this.groupBoxOdeme.TabStop = false;
            this.groupBoxOdeme.Text = "Ödeme";
            
            this.rdbNakit.AutoSize = true;
            this.rdbNakit.Location = new Point(15, 35);
            this.rdbNakit.Name = "rdbNakit";
            this.rdbNakit.Size = new Size(53, 17);
            this.rdbNakit.TabIndex = 0;
            this.rdbNakit.TabStop = true;
            this.rdbNakit.Text = "Nakit";
            this.rdbNakit.UseVisualStyleBackColor = true;
            
            this.rdbKart.AutoSize = true;
            this.rdbKart.Location = new Point(80, 35);
            this.rdbKart.Name = "rdbKart";
            this.rdbKart.Size = new Size(45, 17);
            this.rdbKart.TabIndex = 1;
            this.rdbKart.TabStop = true;
            this.rdbKart.Text = "Kart";
            this.rdbKart.UseVisualStyleBackColor = true;
            
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblToplamTutar.Location = new Point(300, 35);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new Size(110, 21);
            this.lblToplamTutar.TabIndex = 2;
            this.lblToplamTutar.Text = "Toplam: 0,00 ₺";
            
            this.lblIndirimTutari.AutoSize = true;
            this.lblIndirimTutari.Font = new Font("Segoe UI", 10F);
            this.lblIndirimTutari.Location = new Point(300, 60);
            this.lblIndirimTutari.Name = "lblIndirimTutari";
            this.lblIndirimTutari.Size = new Size(80, 19);
            this.lblIndirimTutari.TabIndex = 3;
            this.lblIndirimTutari.Text = "İndirim: 0,00 ₺";
            
            this.lblNetTutar.AutoSize = true;
            this.lblNetTutar.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblNetTutar.ForeColor = Color.Green;
            this.lblNetTutar.Location = new Point(300, 85);
            this.lblNetTutar.Name = "lblNetTutar";
            this.lblNetTutar.Size = new Size(134, 25);
            this.lblNetTutar.TabIndex = 4;
            this.lblNetTutar.Text = "Net Tutar: 0,00 ₺";
            
            this.lblKasiyer.AutoSize = true;
            this.lblKasiyer.Location = new Point(15, 70);
            this.lblKasiyer.Name = "lblKasiyer";
            this.lblKasiyer.Size = new Size(49, 13);
            this.lblKasiyer.TabIndex = 5;
            this.lblKasiyer.Text = "Kasiyer: -";
            
            this.lblSatisZamani.AutoSize = true;
            this.lblSatisZamani.Location = new Point(15, 90);
            this.lblSatisZamani.Name = "lblSatisZamani";
            this.lblSatisZamani.Size = new Size(72, 13);
            this.lblSatisZamani.TabIndex = 6;
            this.lblSatisZamani.Text = "Satış Zamanı: -";
            
            this.btnSatisOnayla.BackColor = Color.Green;
            this.btnSatisOnayla.FlatStyle = FlatStyle.Flat;
            this.btnSatisOnayla.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSatisOnayla.ForeColor = Color.White;
            this.btnSatisOnayla.Location = new Point(550, 35);
            this.btnSatisOnayla.Name = "btnSatisOnayla";
            this.btnSatisOnayla.Size = new Size(120, 40);
            this.btnSatisOnayla.TabIndex = 7;
            this.btnSatisOnayla.Text = "Satışı Onayla";
            this.btnSatisOnayla.UseVisualStyleBackColor = false;
            this.btnSatisOnayla.Click += new EventHandler(this.btnSatisOnayla_Click);
            
            this.btnSatisIptal.BackColor = Color.Orange;
            this.btnSatisIptal.FlatStyle = FlatStyle.Flat;
            this.btnSatisIptal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnSatisIptal.ForeColor = Color.White;
            this.btnSatisIptal.Location = new Point(680, 35);
            this.btnSatisIptal.Name = "btnSatisIptal";
            this.btnSatisIptal.Size = new Size(80, 40);
            this.btnSatisIptal.TabIndex = 8;
            this.btnSatisIptal.Text = "İptal";
            this.btnSatisIptal.UseVisualStyleBackColor = false;
            this.btnSatisIptal.Click += new EventHandler(this.btnSatisIptal_Click);
            
            this.btnKapat.BackColor = Color.FromArgb(108, 117, 125);
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(770, 35);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(70, 40);
            this.btnKapat.TabIndex = 9;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new EventHandler(this.btnKapat_Click);
            
            // frmSatis
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(884, 651);
            this.Controls.Add(this.groupBoxSepet);
            this.Controls.Add(this.groupBoxUrunler);
            this.Controls.Add(this.groupBoxOdeme);
            this.Controls.Add(this.groupBoxUrunEkle);
            this.MaximizeBox = false;
            this.Name = "frmSatis";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Satış İşlemleri";
            
            this.groupBoxSepet.ResumeLayout(false);
            this.groupBoxUrunler.ResumeLayout(false);
            this.groupBoxOdeme.ResumeLayout(false);
            this.groupBoxOdeme.PerformLayout();
            this.groupBoxUrunEkle.ResumeLayout(false);
            this.groupBoxUrunEkle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}