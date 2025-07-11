namespace SupermarketApp.Forms
{
    partial class frmKullanicilar
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnKullaniciEkle;
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
            this.btnKullaniciEkle = new Button();
            this.btnKapat = new Button();
            this.SuspendLayout();
            
            this.btnKullaniciEkle.BackColor = Color.FromArgb(0, 123, 255);
            this.btnKullaniciEkle.FlatStyle = FlatStyle.Flat;
            this.btnKullaniciEkle.ForeColor = Color.White;
            this.btnKullaniciEkle.Location = new Point(50, 50);
            this.btnKullaniciEkle.Name = "btnKullaniciEkle";
            this.btnKullaniciEkle.Size = new Size(200, 50);
            this.btnKullaniciEkle.TabIndex = 0;
            this.btnKullaniciEkle.Text = "Kullanıcı Yönetimi";
            this.btnKullaniciEkle.UseVisualStyleBackColor = false;
            this.btnKullaniciEkle.Click += new EventHandler(this.btnKullaniciEkle_Click);
            
            this.btnKapat.BackColor = Color.FromArgb(108, 117, 125);
            this.btnKapat.FlatStyle = FlatStyle.Flat;
            this.btnKapat.ForeColor = Color.White;
            this.btnKapat.Location = new Point(50, 120);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new Size(200, 30);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new EventHandler(this.btnKapat_Click);
            
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(300, 180);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnKullaniciEkle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKullanicilar";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Yönetimi";
            this.ResumeLayout(false);
        }
    }
}