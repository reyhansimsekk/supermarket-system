namespace SupermarketApp.Forms
{
    partial class frmSatisDetayi
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private Label lblSaleId;
        private Label lblTotalAmount;
        private Label lblItemCount;
        private Button btnPrintReceipt;
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
            this.dataGridView1 = new DataGridView();
            this.lblSaleId = new Label();
            this.lblTotalAmount = new Label();
            this.lblItemCount = new Label();
            this.btnPrintReceipt = new Button();
            this.btnClose = new Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            
            // lblSaleId
            this.lblSaleId.AutoSize = true;
            this.lblSaleId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblSaleId.Location = new Point(20, 20);
            this.lblSaleId.Name = "lblSaleId";
            this.lblSaleId.Size = new Size(81, 21);
            this.lblSaleId.TabIndex = 0;
            this.lblSaleId.Text = "Satış No: -";
            
            // dataGridView1
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(20, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(560, 300);
            this.dataGridView1.TabIndex = 1;
            
            // lblTotalAmount
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTotalAmount.ForeColor = Color.Green;
            this.lblTotalAmount.Location = new Point(20, 380);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new Size(80, 21);
            this.lblTotalAmount.TabIndex = 2;
            this.lblTotalAmount.Text = "Toplam: -";
            
            // lblItemCount
            this.lblItemCount.AutoSize = true;
            this.lblItemCount.Font = new Font("Segoe UI", 10F);
            this.lblItemCount.Location = new Point(200, 383);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new Size(91, 19);
            this.lblItemCount.TabIndex = 3;
            this.lblItemCount.Text = "Ürün Sayısı: -";
            
            // btnPrintReceipt
            this.btnPrintReceipt.BackColor = Color.FromArgb(40, 167, 69);
            this.btnPrintReceipt.FlatStyle = FlatStyle.Flat;
            this.btnPrintReceipt.ForeColor = Color.White;
            this.btnPrintReceipt.Location = new Point(400, 375);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new Size(90, 35);
            this.btnPrintReceipt.TabIndex = 4;
            this.btnPrintReceipt.Text = "Fiş Yazdır";
            this.btnPrintReceipt.UseVisualStyleBackColor = false;
            this.btnPrintReceipt.Click += new EventHandler(this.btnPrintReceipt_Click);
            
            // btnClose
            this.btnClose.BackColor = Color.FromArgb(108, 117, 125);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(505, 375);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(75, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Kapat";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            
            // frmSatisDetayi
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(600, 430);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrintReceipt);
            this.Controls.Add(this.lblItemCount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblSaleId);
            this.Name = "frmSatisDetayi";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Satış Detayı";
            
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}