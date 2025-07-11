namespace SupermarketApp.Forms
{
    partial class frmZRaporu
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnZRaporuOlustur;
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
            this.btnZRaporuOlustur = new Button();
            this.btnKapat = new Button();
            this.SuspendLayout();
            
            this.btnZRaporuOlustur.BackColor = Color.FromArgb(220, 53, 69);
            this.btnZRaporuOlustur.FlatStyle = FlatStyle.Flat;
            this.btnZRaporuOlustur.ForeColor = Color.White;
            this.btnZRaporuOlustur.Location = new Point(50, 50);
            this.btnZRaporuOlustur.Name = "btnZRaporuOlustur";
            this.btnZRaporuOlustur.Size = new Size(200, 50);
            this.btnZRaporuOlustur.TabIndex = 0;
            this.btnZRaporuOlustur.Text = "Z Raporu Oluştur";
            this.btnZRaporuOlustur.UseVisualStyleBackColor = false;
            this.btnZRaporuOlustur.Click += new EventHandler(this.btnZRaporuOlustur_Click);
            
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
            this.Controls.Add(this.btnZRaporuOlustur);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmZRaporu";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Z Raporu";
            this.ResumeLayout(false);
        }
    }
}