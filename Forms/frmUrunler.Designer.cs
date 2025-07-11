namespace SupermarketApp.Forms
{
    partial class frmUrunler
    {
        private System.ComponentModel.IContainer components = null;
        private GroupBox groupBoxProductList;
        private GroupBox groupBoxProductDetails;
        private DataGridView dataGridView1;
        
        private Label lblProductCode;
        private Label lblProductName;
        private Label lblKategori;
        private Label lblMarka;
        private Label lblCostPrice;
        private Label lblUnitPrice;
        private Label lblStockQuantity;
        private Label lblMinStockLevel;
        
        private TextBox txtProductCode;
        private TextBox txtProductName;
        private ComboBox cmbKategori;
        private ComboBox cmbMarka;
        private NumericUpDown numCostPrice;
        private NumericUpDown numUnitPrice;
        private NumericUpDown numStockQuantity;
        private NumericUpDown numMinStockLevel;
        private CheckBox chkIsActive;
        
        private Button btnSave;
        private Button btnCancel;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnLowStock;
        private Button btnClose;
        
        private TextBox txtSearch;
        private Label lblSearch;
        private Label lblTotalProducts;
        private Label lblLowStockCount;

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
            this.groupBoxProductList = new GroupBox();
            this.groupBoxProductDetails = new GroupBox();
            this.dataGridView1 = new DataGridView();
            
            this.lblProductCode = new Label();
            this.lblProductName = new Label();
            this.lblKategori = new Label();
            this.lblMarka = new Label();
            this.lblUnitPrice = new Label();
            this.lblStockQuantity = new Label();
            this.lblMinStockLevel = new Label();
            
            this.txtProductCode = new TextBox();
            this.txtProductName = new TextBox();
            this.cmbKategori = new ComboBox();
            this.cmbMarka = new ComboBox();
            this.numUnitPrice = new NumericUpDown();
            this.numStockQuantity = new NumericUpDown();
            this.numMinStockLevel = new NumericUpDown();
            this.chkIsActive = new CheckBox();
            
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.btnDelete = new Button();
            this.btnRefresh = new Button();
            this.btnLowStock = new Button();
            this.btnClose = new Button();
            
            this.txtSearch = new TextBox();
            this.lblSearch = new Label();
            this.lblTotalProducts = new Label();
            this.lblLowStockCount = new Label();
            
            this.groupBoxProductList.SuspendLayout();
            this.groupBoxProductDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStockQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStockLevel)).BeginInit();
            this.SuspendLayout();
            
            // groupBoxProductList
            this.groupBoxProductList.Controls.Add(this.lblLowStockCount);
            this.groupBoxProductList.Controls.Add(this.lblTotalProducts);
            this.groupBoxProductList.Controls.Add(this.btnLowStock);
            this.groupBoxProductList.Controls.Add(this.btnRefresh);
            this.groupBoxProductList.Controls.Add(this.txtSearch);
            this.groupBoxProductList.Controls.Add(this.lblSearch);
            this.groupBoxProductList.Controls.Add(this.dataGridView1);
            this.groupBoxProductList.Location = new Point(12, 12);
            this.groupBoxProductList.Name = "groupBoxProductList";
            this.groupBoxProductList.Size = new Size(800, 500);
            this.groupBoxProductList.TabIndex = 0;
            this.groupBoxProductList.TabStop = false;
            this.groupBoxProductList.Text = "Ürün Listesi";
            
            // dataGridView1
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(15, 80);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(770, 360);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            
            // Search controls
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new Point(15, 35);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new Size(26, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Ara:";
            
            this.txtSearch.Location = new Point(50, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new Size(200, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
            
            // Buttons
            this.btnRefresh.Location = new Point(270, 30);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            
            this.btnLowStock.Location = new Point(360, 30);
            this.btnLowStock.Name = "btnLowStock";
            this.btnLowStock.Size = new Size(100, 23);
            this.btnLowStock.TabIndex = 4;
            this.btnLowStock.Text = "Düşük Stok";
            this.btnLowStock.UseVisualStyleBackColor = true;
            this.btnLowStock.Click += new EventHandler(this.btnLowStock_Click);
            
            // Status labels
            this.lblTotalProducts.AutoSize = true;
            this.lblTotalProducts.Location = new Point(500, 35);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new Size(80, 13);
            this.lblTotalProducts.TabIndex = 5;
            this.lblTotalProducts.Text = "Toplam Ürün: 0";
            
            this.lblLowStockCount.AutoSize = true;
            this.lblLowStockCount.Location = new Point(620, 35);
            this.lblLowStockCount.Name = "lblLowStockCount";
            this.lblLowStockCount.Size = new Size(70, 13);
            this.lblLowStockCount.TabIndex = 6;
            this.lblLowStockCount.Text = "Düşük Stok: 0";
            
            // Footer buttons
            this.btnClose.Location = new Point(710, 450);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(75, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Kapat";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            
            // groupBoxProductDetails
            this.groupBoxProductDetails.Controls.Add(this.btnDelete);
            this.groupBoxProductDetails.Controls.Add(this.btnCancel);
            this.groupBoxProductDetails.Controls.Add(this.btnSave);
            this.groupBoxProductDetails.Controls.Add(this.chkIsActive);
            this.groupBoxProductDetails.Controls.Add(this.numMinStockLevel);
            this.groupBoxProductDetails.Controls.Add(this.numStockQuantity);
            this.groupBoxProductDetails.Controls.Add(this.numUnitPrice);
            this.groupBoxProductDetails.Controls.Add(this.cmbMarka);
            this.groupBoxProductDetails.Controls.Add(this.cmbKategori);
            this.groupBoxProductDetails.Controls.Add(this.txtProductName);
            this.groupBoxProductDetails.Controls.Add(this.txtProductCode);
            this.groupBoxProductDetails.Controls.Add(this.lblMinStockLevel);
            this.groupBoxProductDetails.Controls.Add(this.lblStockQuantity);
            this.groupBoxProductDetails.Controls.Add(this.lblUnitPrice);
            this.groupBoxProductDetails.Controls.Add(this.lblMarka);
            this.groupBoxProductDetails.Controls.Add(this.lblKategori);
            this.groupBoxProductDetails.Controls.Add(this.lblProductName);
            this.groupBoxProductDetails.Controls.Add(this.lblProductCode);
            this.groupBoxProductDetails.Location = new Point(830, 12);
            this.groupBoxProductDetails.Name = "groupBoxProductDetails";
            this.groupBoxProductDetails.Size = new Size(350, 500);
            this.groupBoxProductDetails.TabIndex = 1;
            this.groupBoxProductDetails.TabStop = false;
            this.groupBoxProductDetails.Text = "Ürün Detayları";
            
            // Labels
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Location = new Point(15, 40);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new Size(60, 13);
            this.lblProductCode.TabIndex = 0;
            this.lblProductCode.Text = "Ürün Kodu:";
            
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new Point(15, 80);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new Size(48, 13);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Ürün Adı:";
            
            this.lblKategori.AutoSize = true;
            this.lblKategori.Location = new Point(15, 120);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Size = new Size(45, 13);
            this.lblKategori.TabIndex = 2;
            this.lblKategori.Text = "Kategori:";
            
            this.lblMarka.AutoSize = true;
            this.lblMarka.Location = new Point(15, 160);
            this.lblMarka.Name = "lblMarka";
            this.lblMarka.Size = new Size(33, 13);
            this.lblMarka.TabIndex = 3;
            this.lblMarka.Text = "Marka:";
            
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new Point(15, 200);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new Size(56, 13);
            this.lblUnitPrice.TabIndex = 4;
            this.lblUnitPrice.Text = "Birim Fiyat:";
            
            this.lblStockQuantity.AutoSize = true;
            this.lblStockQuantity.Location = new Point(15, 240);
            this.lblStockQuantity.Name = "lblStockQuantity";
            this.lblStockQuantity.Size = new Size(67, 13);
            this.lblStockQuantity.TabIndex = 5;
            this.lblStockQuantity.Text = "Stok Miktarı:";
            
            this.lblMinStockLevel.AutoSize = true;
            this.lblMinStockLevel.Location = new Point(15, 280);
            this.lblMinStockLevel.Name = "lblMinStockLevel";
            this.lblMinStockLevel.Size = new Size(80, 13);
            this.lblMinStockLevel.TabIndex = 6;
            this.lblMinStockLevel.Text = "Min. Stok Seviye:";
            
            // Text Boxes
            this.txtProductCode.Location = new Point(120, 37);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new Size(200, 20);
            this.txtProductCode.TabIndex = 7;
            
            this.txtProductName.Location = new Point(120, 77);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new Size(200, 20);
            this.txtProductName.TabIndex = 8;
            
            // ComboBoxes
            this.cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new Point(120, 117);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new Size(200, 21);
            this.cmbKategori.TabIndex = 9;
            
            this.cmbMarka.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMarka.FormattingEnabled = true;
            this.cmbMarka.Location = new Point(120, 157);
            this.cmbMarka.Name = "cmbMarka";
            this.cmbMarka.Size = new Size(200, 21);
            this.cmbMarka.TabIndex = 10;
            
            // Numeric UpDowns
            this.numUnitPrice.DecimalPlaces = 2;
            this.numUnitPrice.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numUnitPrice.Location = new Point(120, 197);
            this.numUnitPrice.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numUnitPrice.Name = "numUnitPrice";
            this.numUnitPrice.Size = new Size(200, 20);
            this.numUnitPrice.TabIndex = 11;
            
            this.numStockQuantity.Location = new Point(120, 237);
            this.numStockQuantity.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numStockQuantity.Name = "numStockQuantity";
            this.numStockQuantity.Size = new Size(200, 20);
            this.numStockQuantity.TabIndex = 12;
            
            this.numMinStockLevel.Location = new Point(120, 277);
            this.numMinStockLevel.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.numMinStockLevel.Name = "numMinStockLevel";
            this.numMinStockLevel.Size = new Size(200, 20);
            this.numMinStockLevel.TabIndex = 13;
            this.numMinStockLevel.Value = new decimal(new int[] { 10, 0, 0, 0 });
            
            // CheckBox
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = CheckState.Checked;
            this.chkIsActive.Location = new Point(120, 317);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new Size(50, 17);
            this.chkIsActive.TabIndex = 14;
            this.chkIsActive.Text = "Aktif";
            this.chkIsActive.UseVisualStyleBackColor = true;
            
            // Buttons
            this.btnSave.BackColor = Color.FromArgb(40, 167, 69);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(15, 360);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(100, 30);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Ekle";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            
            this.btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(125, 360);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(100, 30);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Temizle";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            
            this.btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(235, 360);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(100, 30);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            
            // frmUrunler
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 530);
            this.Controls.Add(this.groupBoxProductDetails);
            this.Controls.Add(this.groupBoxProductList);
            this.MaximizeBox = false;
            this.Name = "frmUrunler";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Ürün Yönetimi";
            
            this.groupBoxProductList.ResumeLayout(false);
            this.groupBoxProductList.PerformLayout();
            this.groupBoxProductDetails.ResumeLayout(false);
            this.groupBoxProductDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStockQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStockLevel)).EndInit();
            this.ResumeLayout(false);
        }
    }
}