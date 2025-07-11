namespace SupermarketApp.Forms
{
    partial class frmRaporlar
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnGunlukSatis;
        private Button btnAylikRapor;
        private Button btnStokRaporu;
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
            this.btnGunlukSatis = new Button();
            this.btnAylikRapor = new Button();
            this.btnStokRaporu = new Button();
            this.btnKapat = new Button();
            this.SuspendLayout();
            
            this.btnGunlukSatis.BackColor = Color.FromArgb(40, 167, 69);
            this.btnGunlukSatis.FlatStyle = FlatStyle.Flat;
            this.btnGunlukSatis.ForeColor = Color.White;
            this.btnGunlukSatis.Location = new Point(50, 50);
            this.btnGunlukSatis.Name = "btnGunlukSatis";
            this.btnGunlukSatis.Size = new Size(200, 50);
            this.btnGunlukSatis.TabIndex = 0;
            this.btnGunlukSatis.Text = "Günlük Satış Raporu";
            this.btnGunlukSatis.UseVisualStyleBackColor = false;
            this.btnGunlukSatis.Click += new EventHandler(this.btnGunlukSatis_Click);
            
            this.btnAylikRapor.BackColor = Color.FromArgb(0, 123, 255);
            this.btnAylikRapor.FlatStyle = FlatStyle.Flat;
            this.btnAylikRapor.ForeColor = Color.White;
            this.btnAylikRapor.Location = new Point(5000, 120);
            this.btnAylikRapor.Name = "btnAylikRapor";
            this.btnAylikRapor.Size = new Size(200, 50);
            this.btnAylikRapor.TabIndex = 1;
            this.btnAylikRapor.Text = "Aylık Rapor";
            this.btnAylikRapor.UseVisualStyleBackColor = false;
            this.btnAylikRapor.Click += new EventHandler(this.btnAylikRapor_Click);
            
            this.btnStokRaporu.BackColor = Color.FromArgb(255, 193, 7);
            this.btnStokRaporu.FlatStyle = FlatStyle.Flat;
            this.btnStokRaporu.ForeColor = Color.Black;
            this.btnStokRaporu.Location = new Point(500, 190);
            this.btnStokRaporu.Name = "btnStokRaporu";
            this.btnStokRaporu.Size = new Size(200, 50);
            this.btnStokRaporu.TabIndex = 2;
            this.btnStokRaporu.Text = "Stok Raporu";
            this.btnStokRaporu.UseVisualStyleBackColor = false;
            this.btnStokRaporu.Click += new EventHandler(this.btnStokRaporu_Click);
            
            this.btnKapat.BackColor = Color.FromArgb(108, 117, 125);
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(50, 260);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(200, 30);
            this.btnKapat.TabIndex = 3;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new EventHandler(this.btnKapat_Click);
            
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(300, 320);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnStokRaporu);
            this.Controls.Add(this.btnAylikRapor);
            this.Controls.Add(this.btnGunlukSatis);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRaporlar";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Raporlar";
            this.ResumeLayout(false);
        }
    }
}