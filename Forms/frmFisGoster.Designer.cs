namespace SupermarketApp.Forms
{
    partial class frmFisGoster
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtReceipt;
        private Button btnPrint;
        private Button btnSave;
        private Button btnClose;

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
            this.txtReceipt = new TextBox();
            this.btnPrint = new Button();
            this.btnSave = new Button();
            this.btnClose = new Button();
            this.SuspendLayout();
            
            // txtReceipt
            this.txtReceipt.Font = new Font("Courier New", 9F, FontStyle.Regular);
            this.txtReceipt.Location = new Point(20, 20);
            this.txtReceipt.Multiline = true;
            this.txtReceipt.Name = "txtReceipt";
            this.txtReceipt.ReadOnly = true;
            this.txtReceipt.ScrollBars = ScrollBars.Vertical;
            this.txtReceipt.Size = new Size(360, 450);
            this.txtReceipt.TabIndex = 0;
            
            // btnPrint
            this.btnPrint.BackColor = Color.FromArgb(40, 167, 69);
            this.btnPrint.FlatStyle = FlatStyle.Flat;
            this.btnPrint.ForeColor = Color.White;
            this.btnPrint.Location = new Point(20, 490);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size(80, 35);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Yazdır";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
            
            // btnSave
            this.btnSave.BackColor = Color.FromArgb(0, 123, 255);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(120, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(80, 35);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            
            // btnClose
            this.btnClose.BackColor = Color.FromArgb(108, 117, 125);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(300, 490);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(80, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Kapat";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            
            // frmFisGoster
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 550);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtReceipt);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFisGoster";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Satış Fişi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}