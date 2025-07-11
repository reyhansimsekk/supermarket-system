namespace SupermarketApp.Forms
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private Panel pnlSidePanel;
        private Panel pnlMainContent;
        private Splitter splitter1;
        
        private Button btnSatis;
        private Button btnUrunler;
        private Button btnRaporlar;
        private Button btnZRaporu;
        private Button btnKullanicilar;
        private Button btnAyarlar;
        private Button btnStokKontrol;
        private Button btnHakkinda;
        private Button btnCikis;
        
        private Label lblMenuTitle;
        private ToolStripStatusLabel lblCurrentUser;
        private ToolStripStatusLabel lblLoginTime;

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
            this.menuStrip1 = new MenuStrip();
            this.statusStrip1 = new StatusStrip();
            this.pnlSidePanel = new Panel();
            this.pnlMainContent = new Panel();
            this.splitter1 = new Splitter();
            
            // Side Panel Buttons
            this.btnSatis = new Button();
            this.btnUrunler = new Button();
            this.btnRaporlar = new Button();
            this.btnZRaporu = new Button();
            this.btnKullanicilar = new Button();
            this.btnAyarlar = new Button();
            this.btnStokKontrol = new Button();
            this.btnHakkinda = new Button();
            this.btnCikis = new Button();
            
            // Labels
            this.lblMenuTitle = new Label();
            
            // Status Bar Items
            this.lblCurrentUser = new ToolStripStatusLabel();
            this.lblLoginTime = new ToolStripStatusLabel();
            
            this.pnlSidePanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            
            // pnlSidePanel
            this.pnlSidePanel.BackColor = Color.FromArgb(45, 45, 48);
            this.pnlSidePanel.Controls.Add(this.lblMenuTitle);
            this.pnlSidePanel.Controls.Add(this.btnSatis);
            this.pnlSidePanel.Controls.Add(this.btnUrunler);
            this.pnlSidePanel.Controls.Add(this.btnStokKontrol);
            this.pnlSidePanel.Controls.Add(this.btnRaporlar);
            this.pnlSidePanel.Controls.Add(this.btnZRaporu);
            this.pnlSidePanel.Controls.Add(this.btnKullanicilar);
            this.pnlSidePanel.Controls.Add(this.btnAyarlar);
            this.pnlSidePanel.Controls.Add(this.btnHakkinda);
            this.pnlSidePanel.Controls.Add(this.btnCikis);
            this.pnlSidePanel.Dock = DockStyle.Left;
            this.pnlSidePanel.Location = new Point(0, 0);
            this.pnlSidePanel.Name = "pnlSidePanel";
            this.pnlSidePanel.Size = new Size(250, 650);
            this.pnlSidePanel.TabIndex = 0;
            
            // lblMenuTitle
            this.lblMenuTitle.AutoSize = false;
            this.lblMenuTitle.BackColor = Color.FromArgb(0, 122, 204);
            this.lblMenuTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblMenuTitle.ForeColor = Color.White;
            this.lblMenuTitle.Location = new Point(0, 0);
            this.lblMenuTitle.Name = "lblMenuTitle";
            this.lblMenuTitle.Size = new Size(250, 50);
            this.lblMenuTitle.TabIndex = 0;
            this.lblMenuTitle.Text = "SÜPERMARKET SİSTEMİ";
            this.lblMenuTitle.TextAlign = ContentAlignment.MiddleCenter;
            
            // Side Panel Buttons
            int buttonTop = 60;
            int buttonHeight = 45;
            int buttonSpacing = 5;
            buttonTop += buttonHeight + buttonSpacing;

            this.btnSatis.BackColor = Color.FromArgb(0, 122, 204);
            this.btnSatis.FlatAppearance.BorderSize = 0;
            this.btnSatis.FlatStyle = FlatStyle.Flat;
            this.btnSatis.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSatis.ForeColor = Color.White;
            this.btnSatis.Location = new Point(10, buttonTop);
            this.btnSatis.Name = "btnSatis";
            this.btnSatis.Size = new Size(230, buttonHeight);
            this.btnSatis.TabIndex = 1;
            this.btnSatis.Text = "🛒 SATIŞ YAP";
            this.btnSatis.UseVisualStyleBackColor = false;
            this.btnSatis.Click += new EventHandler(this.btnSatis_Click);
            buttonTop += buttonHeight + buttonSpacing;

            this.btnUrunler.BackColor = Color.FromArgb(70, 70, 74);
            this.btnUrunler.FlatAppearance.BorderSize = 0;
            this.btnUrunler.FlatStyle = FlatStyle.Flat;
            this.btnUrunler.Font = new Font("Segoe UI", 10F);
            this.btnUrunler.ForeColor = Color.White;
            this.btnUrunler.Location = new Point(10, buttonTop);
            this.btnUrunler.Name = "btnUrunler";
            this.btnUrunler.Size = new Size(230, buttonHeight);
            this.btnUrunler.TabIndex = 2;
            this.btnUrunler.Text = "📦 ÜRÜN YÖNETİMİ";
            this.btnUrunler.UseVisualStyleBackColor = false;
            this.btnUrunler.Click += new EventHandler(this.btnUrunler_Click);
            buttonTop += buttonHeight + buttonSpacing;

            this.btnStokKontrol.BackColor = Color.FromArgb(70, 70, 74);
            this.btnStokKontrol.FlatAppearance.BorderSize = 0;
            this.btnStokKontrol.FlatStyle = FlatStyle.Flat;
            this.btnStokKontrol.Font = new Font("Segoe UI", 10F);
            this.btnStokKontrol.ForeColor = Color.White;
            this.btnStokKontrol.Location = new Point(10, buttonTop);
            this.btnStokKontrol.Name = "btnStokKontrol";
            this.btnStokKontrol.Size = new Size(230, buttonHeight);
            this.btnStokKontrol.TabIndex = 3;
            this.btnStokKontrol.Text = "📊 STOK KONTROLÜ";
            this.btnStokKontrol.UseVisualStyleBackColor = false;
            this.btnStokKontrol.Click += new EventHandler(this.btnStokKontrol_Click);

            buttonTop += buttonHeight + buttonSpacing;

            this.btnRaporlar.BackColor = Color.FromArgb(70, 70, 74);
            this.btnRaporlar.FlatAppearance.BorderSize = 0;
            this.btnRaporlar.FlatStyle = FlatStyle.Flat;
            this.btnRaporlar.Font = new Font("Segoe UI", 10F);
            this.btnRaporlar.ForeColor = Color.White;
            this.btnRaporlar.Location = new Point(10, buttonTop);
            this.btnRaporlar.Name = "btnRaporlar";
            this.btnRaporlar.Size = new Size(230, buttonHeight);
            this.btnRaporlar.TabIndex = 4;
            this.btnRaporlar.Text = "📈 RAPORLAR";
            this.btnRaporlar.UseVisualStyleBackColor = false;
            this.btnRaporlar.Click += new EventHandler(this.btnRaporlar_Click);
            
            buttonTop += buttonHeight + buttonSpacing;
            this.btnZRaporu.BackColor = Color.FromArgb(70, 70, 74);
            this.btnZRaporu.FlatAppearance.BorderSize = 0;
            this.btnZRaporu.FlatStyle = FlatStyle.Flat;
            this.btnZRaporu.Font = new Font("Segoe UI", 10F);
            this.btnZRaporu.ForeColor = Color.White;
            this.btnZRaporu.Location = new Point(10000, buttonTop);
            this.btnZRaporu.Name = "btnZRaporu";
            this.btnZRaporu.Size = new Size(230, buttonHeight);
            this.btnZRaporu.TabIndex = 5;
            this.btnZRaporu.Text = "📋 Z RAPORU";
            this.btnZRaporu.UseVisualStyleBackColor = false;
            this.btnZRaporu.Click += new EventHandler(this.btnZRaporu_Click);
            
            buttonTop += buttonHeight + buttonSpacing;
            this.btnKullanicilar.BackColor = Color.FromArgb(70, 70, 74);
            this.btnKullanicilar.FlatAppearance.BorderSize = 0;
            this.btnKullanicilar.FlatStyle = FlatStyle.Flat;
            this.btnKullanicilar.Font = new Font("Segoe UI", 10F);
            this.btnKullanicilar.ForeColor = Color.White;
            this.btnKullanicilar.Location = new Point(1000, buttonTop);
            this.btnKullanicilar.Name = "btnKullanicilar";
            this.btnKullanicilar.Size = new Size(230, buttonHeight);
            this.btnKullanicilar.TabIndex = 6;
            this.btnKullanicilar.Text = "👥 KULLANICILAR";
            this.btnKullanicilar.UseVisualStyleBackColor = false;
            this.btnKullanicilar.Click += new EventHandler(this.btnKullanicilar_Click);
            
            buttonTop += buttonHeight + buttonSpacing;
            this.btnAyarlar.BackColor = Color.FromArgb(70, 70, 74);
            this.btnAyarlar.FlatAppearance.BorderSize = 0;
            this.btnAyarlar.FlatStyle = FlatStyle.Flat;
            this.btnAyarlar.Font = new Font("Segoe UI", 10F);
            this.btnAyarlar.ForeColor = Color.White;
            this.btnAyarlar.Location = new Point(1000, buttonTop);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new Size(230, buttonHeight);
            this.btnAyarlar.TabIndex = 7;
            this.btnAyarlar.Text = "⚙️ AYARLAR";
            this.btnAyarlar.UseVisualStyleBackColor = false;
            this.btnAyarlar.Click += new EventHandler(this.btnAyarlar_Click);
            
            buttonTop += buttonHeight + buttonSpacing;
            this.btnHakkinda.BackColor = Color.FromArgb(70, 70, 74);
            this.btnHakkinda.FlatAppearance.BorderSize = 0;
            this.btnHakkinda.FlatStyle = FlatStyle.Flat;
            this.btnHakkinda.Font = new Font("Segoe UI", 10F);
            this.btnHakkinda.ForeColor = Color.White;
            this.btnHakkinda.Location = new Point(1000, buttonTop);
            this.btnHakkinda.Name = "btnHakkinda";
            this.btnHakkinda.Size = new Size(230, buttonHeight);
            this.btnHakkinda.TabIndex = 8;
            this.btnHakkinda.Text = "ℹ️ HAKKINDA";
            this.btnHakkinda.UseVisualStyleBackColor = false;
            this.btnHakkinda.Click += new EventHandler(this.btnHakkinda_Click);
            
            this.btnCikis.BackColor = Color.FromArgb(192, 57, 43);
            this.btnCikis.FlatAppearance.BorderSize = 0;
            this.btnCikis.FlatStyle = FlatStyle.Flat;
            this.btnCikis.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCikis.ForeColor = Color.White;
            this.btnCikis.Location = new Point(10, 580);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new Size(230, buttonHeight);
            this.btnCikis.TabIndex = 9;
            this.btnCikis.Text = "🚪 ÇIKIŞ";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new EventHandler(this.btnCikis_Click);
            
            // pnlMainContent
            this.pnlMainContent.BackColor = Color.FromArgb(240, 240, 240);
            this.pnlMainContent.Dock = DockStyle.Fill;
            this.pnlMainContent.Location = new Point(250, 0);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new Size(950, 626);
            this.pnlMainContent.TabIndex = 1;
            
            // splitter1
            this.splitter1.BackColor = Color.FromArgb(62, 62, 66);
            this.splitter1.Location = new Point(250, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new Size(3, 626);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            
            // statusStrip1
            this.statusStrip1.Items.AddRange(new ToolStripItem[] {
                this.lblCurrentUser,
                this.lblLoginTime
            });
            this.statusStrip1.Location = new Point(0, 626);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(1200, 24);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            
            // Status Bar Items
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new Size(68, 19);
            this.lblCurrentUser.Text = "Kullanıcı: -";
            this.lblCurrentUser.Spring = true;
            
            this.lblLoginTime.Name = "lblLoginTime";
            this.lblLoginTime.Size = new Size(88, 19);
            this.lblLoginTime.Text = "Giriş Zamanı: -";
            
            // frmMain
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 650);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlSidePanel);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "Süpermarket Otomasyon Sistemi";
            this.WindowState = FormWindowState.Maximized;
            
            this.pnlSidePanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}