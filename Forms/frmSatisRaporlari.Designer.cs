namespace SupermarketApp.Forms
{
    partial class frmSatisRaporlari
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private DateTimePicker dateTimePicker1;
        private Label lblDate;
        private Label lblTotalSales;
        private Label lblTotalAmount;
        private Button btnRefresh;
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
            this.dateTimePicker1 = new DateTimePicker();
            this.lblDate = new Label();
            this.lblTotalSales = new Label();
            this.lblTotalAmount = new Label();
            this.btnRefresh = new Button();
            this.btnClose = new Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            
            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new Point(20, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new Size(34, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Tarih:";
            
            // dateTimePicker1
            this.dateTimePicker1.Format = DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new Point(60, 17);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(120, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new EventHandler(this.dateTimePicker1_ValueChanged);
            
            // btnRefresh
            this.btnRefresh.BackColor = Color.FromArgb(0, 123, 255);
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(200, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(75, 25);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            
            // dataGridView1
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(20, 60);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(760, 400);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            
            // lblTotalSales
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTotalSales.Location = new Point(20, 480);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new Size(100, 19);
            this.lblTotalSales.TabIndex = 4;
            this.lblTotalSales.Text = "Toplam Satış: 0";
            
            // lblTotalAmount
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTotalAmount.ForeColor = Color.Green;
            this.lblTotalAmount.Location = new Point(200, 480);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new Size(112, 19);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "Toplam Tutar: 0₺";
            
            // btnClose
            this.btnClose.BackColor = Color.FromArgb(108, 117, 125);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(705, 476);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(75, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Kapat";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            
            // frmSatisRaporlari
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 520);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblTotalSales);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblDate);
            this.Name = "frmSatisRaporlari";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Satış Raporları";
            
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}