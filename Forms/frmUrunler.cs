using SupermarketApp.BusinessLogic;
using SupermarketApp.Models;
using System.Data;

namespace SupermarketApp.Forms
{
    public partial class frmUrunler : Form
    {
        private List<Product> products = new List<Product>();
        private List<Category> categories = new List<Category>();
        private List<Brand> brands = new List<Brand>();
        private bool isEditing = false;
        private string editingProductCode = string.Empty;

        public frmUrunler()
        {
            InitializeComponent();
            this.Load += FrmUrunler_Load;
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadProducts();
            ClearForm();
        }

        private void LoadComboBoxes()
        {
            try
            {
                categories = ProductManager.GetAllCategories();
                cmbKategori.DataSource = categories;
                cmbKategori.DisplayMember = "CategoryName";
                cmbKategori.ValueMember = "CategoryID";

                brands = ProductManager.GetAllBrands();
                cmbMarka.DataSource = brands;
                cmbMarka.DisplayMember = "BrandName";
                cmbMarka.ValueMember = "BrandID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategori ve marka listesi yüklenirken hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                products = ProductManager.GetAllProducts();
                dataGridView1.DataSource = products;
                
                lblTotalProducts.Text = $"Toplam Ürün: {products.Count}";
                lblLowStockCount.Text = $"Düşük Stok: {products.Count(p => p.StockQuantity <= p.MinStockLevel)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün listesi yüklenirken hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtProductCode.Text = "";
            txtProductName.Text = "";
            cmbKategori.SelectedIndex = -1;
            cmbMarka.SelectedIndex = -1;
            numUnitPrice.Value = 0;
            numStockQuantity.Value = 0;
            numMinStockLevel.Value = 10;
            chkIsActive.Checked = true;
            
            isEditing = false;
            editingProductCode = string.Empty;
            btnSave.Text = "Ekle";
            btnCancel.Text = "Temizle";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm()) return;

                var product = new Product
                {
                    ProductCode = txtProductCode.Text.Trim(),
                    ProductName = txtProductName.Text.Trim(),
                    CategoryID = Convert.ToInt32(cmbKategori.SelectedValue),
                    BrandID = Convert.ToInt32(cmbMarka.SelectedValue),
                    UnitPrice = numUnitPrice.Value,
                    StockQuantity = Convert.ToInt32(numStockQuantity.Value),
                    MinStockLevel = Convert.ToInt32(numMinStockLevel.Value),
                    IsActive = chkIsActive.Checked
                };

                bool success;
                if (isEditing)
                {
                    success = ProductManager.UpdateProduct(product);
                    if (success)
                        MessageBox.Show("Ürün başarıyla güncellendi!", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    success = ProductManager.AddProduct(product);
                    if (success)
                        MessageBox.Show("Ürün başarıyla eklendi!", "Başarılı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (success)
                {
                    LoadProducts();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün kaydedilirken hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtProductCode.Text))
            {
                MessageBox.Show("Ürün kodu boş olamaz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Ürün adı boş olamaz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return false;
            }

            if (cmbKategori.SelectedValue == null)
            {
                MessageBox.Show("Kategori seçilmelidir!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbKategori.Focus();
                return false;
            }

            if (cmbMarka.SelectedValue == null)
            {
                MessageBox.Show("Marka seçilmelidir!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMarka.Focus();
                return false;
            }

            if (numUnitPrice.Value <= 0)
            {
                MessageBox.Show("Birim fiyat 0'dan büyük olmalıdır!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numUnitPrice.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow?.DataBoundItem is Product selectedProduct)
                {
                    if (MessageBox.Show($"'{selectedProduct.ProductName}' ürününü silmek istediğinizden emin misiniz?",
                        "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (ProductManager.DeleteProduct(selectedProduct.ProductCode))
                        {
                            MessageBox.Show("Ürün başarıyla silindi!", "Başarılı", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadProducts();
                            ClearForm();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Silmek için bir ürün seçin!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün silinirken hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
            ClearForm();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].DataBoundItem is Product selectedProduct)
            {
                LoadProductToForm(selectedProduct);
            }
        }

        private void LoadProductToForm(Product product)
        {
            txtProductCode.Text = product.ProductCode;
            txtProductName.Text = product.ProductName;
            cmbKategori.SelectedValue = product.CategoryID;
            cmbMarka.SelectedValue = product.BrandID;
            numUnitPrice.Value = product.UnitPrice;
            numStockQuantity.Value = product.StockQuantity;
            numMinStockLevel.Value = product.MinStockLevel;
            chkIsActive.Checked = product.IsActive;
            
            isEditing = true;
            editingProductCode = product.ProductCode;
            btnSave.Text = "Güncelle";
            btnCancel.Text = "İptal";
            
            txtProductCode.ReadOnly = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.ToLower();
                
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    dataGridView1.DataSource = products;
                }
                else
                {
                    var filteredProducts = products.Where(p =>
                        p.ProductCode.ToLower().Contains(searchText) ||
                        p.ProductName.ToLower().Contains(searchText) ||
                        p.CategoryName.ToLower().Contains(searchText) ||
                        p.BrandName.ToLower().Contains(searchText)
                    ).ToList();
                    
                    dataGridView1.DataSource = filteredProducts;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Arama yapılırken hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLowStock_Click(object sender, EventArgs e)
        {
            try
            {
                var lowStockProducts = ProductManager.GetLowStockProducts();
                dataGridView1.DataSource = lowStockProducts;
                
                MessageBox.Show($"{lowStockProducts.Count} ürünün stoğu kritik seviyede!", 
                    "Stok Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Düşük stok listesi alınırken hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Product product)
            {
                if (product.StockQuantity <= product.MinStockLevel)
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}