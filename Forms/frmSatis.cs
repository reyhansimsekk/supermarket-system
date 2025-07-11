using SupermarketApp.BusinessLogic;
using SupermarketApp.Models;
using System.Data;

namespace SupermarketApp.Forms
{
    public partial class frmSatis : Form
    {
        private List<SaleDetail> saleDetails = new List<SaleDetail>();
        private decimal totalAmount = 0;
        private decimal discountAmount = 0;
        private decimal netAmount = 0;

        public frmSatis()
        {
            InitializeComponent();
            this.Load += FrmSatis_Load;
        }

        private void FrmSatis_Load(object sender, EventArgs e)
        {
            ClearSale();
            LoadProductsToFlowPanel();
            txtBarkod.Focus();
            
            rdbNakit.Checked = true;
            lblKasiyer.Text = $"Kasiyer: {frmLogin.CurrentUser?.FullName}";
            lblSatisZamani.Text = $"Satış Zamanı: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";
        }

        private void ClearSale()
        {
            saleDetails.Clear();
            totalAmount = 0;
            discountAmount = 0;
            netAmount = 0;
            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = saleDetails;
            
            UpdateTotals();
            txtBarkod.Text = "";
            txtBarkod.Focus();
        }

        private void UpdateTotals()
        {
            totalAmount = saleDetails.Sum(s => s.TotalPrice);
            netAmount = totalAmount - discountAmount;
            
            lblToplamTutar.Text = $"Toplam: {totalAmount:C2}";
            lblIndirimTutari.Text = $"İndirim: {discountAmount:C2}";
            lblNetTutar.Text = $"Net Tutar: {netAmount:C2}";
        }

        private void txtBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddProductToSale();
            }
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            AddProductToSale();
        }

        private void AddProductToSale()
        {
            try
            {
                string barkod = txtBarkod.Text.Trim();
                if (string.IsNullOrEmpty(barkod))
                {
                    MessageBox.Show("Barkod giriniz!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var product = ProductManager.GetProductByCode(barkod);
                if (product == null)
                {
                    MessageBox.Show("Ürün bulunamadı!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBarkod.Focus();
                    return;
                }

                if (product.StockQuantity <= 0)
                {
                    MessageBox.Show("Ürün stokta yok!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBarkod.Text = "";
                    txtBarkod.Focus();
                    return;
                }

                var existingItem = saleDetails.FirstOrDefault(s => s.ProductCode == barkod);
                if (existingItem != null)
                {
                    if (existingItem.Quantity >= product.StockQuantity)
                    {
                        MessageBox.Show("Stok yetersiz!", "Uyarı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    existingItem.Quantity++;
                    existingItem.TotalPrice = existingItem.Quantity * existingItem.UnitPrice;
                }
                else
                {
                    var saleDetail = new SaleDetail
                    {
                        ProductCode = product.ProductCode,
                        ProductName = product.ProductName,
                        Quantity = 1,
                        UnitPrice = product.UnitPrice,
                        TotalPrice = product.UnitPrice,
                        DiscountAmount = 0
                    };
                    
                    saleDetails.Add(saleDetail);
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = saleDetails;
                
                UpdateTotals();
                txtBarkod.Text = "";
                txtBarkod.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün eklenirken hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUrunCikar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow?.DataBoundItem is SaleDetail selectedItem)
                {
                    saleDetails.Remove(selectedItem);
                    
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = saleDetails;
                    
                    UpdateTotals();
                }
                else
                {
                    MessageBox.Show("Çıkarılacak ürünü seçin!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün çıkarılırken hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSatisIptal_Click(object sender, EventArgs e)
        {
            if (saleDetails.Count > 0)
            {
                if (MessageBox.Show("Satışı iptal etmek istediğinizden emin misiniz?",
                    "Satış İptali", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ClearSale();
                }
            }
        }

        private void btnSatisOnayla_Click(object sender, EventArgs e)
        {
            try
            {
                if (saleDetails.Count == 0)
                {
                    MessageBox.Show("Satış sepeti boş!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string paymentType = rdbNakit.Checked ? "Nakit" : "Kart";
                
                var sale = new Sale
                {
                    SaleDate = DateTime.Now,
                    UserID = frmLogin.CurrentUser!.UserID,
                    TotalAmount = totalAmount,
                    PaymentType = paymentType,
                    DiscountAmount = discountAmount,
                    NetAmount = netAmount,
                    SaleDetails = saleDetails
                };

                if (SaveSale(sale))
                {
                    MessageBox.Show("Satış başarıyla tamamlandı!", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    PrintReceipt(sale);
                    ClearSale();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış kaydedilirken hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SaveSale(Sale sale)
        {
            try
            {
                return SalesManager.SaveSale(sale);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış kaydedilemedi: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void PrintReceipt(Sale sale)
        {
            try
            {
                // Fiş metnini oluştur
                var receipt = new System.Text.StringBuilder();
                receipt.AppendLine("========================================");
                receipt.AppendLine("         SÜPERMARKET SİSTEMİ");
                receipt.AppendLine("========================================");
                receipt.AppendLine($"Tarih: {sale.SaleDate:dd.MM.yyyy HH:mm:ss}");
                receipt.AppendLine($"Kasiyer: {frmLogin.CurrentUser?.FullName}");
                receipt.AppendLine($"Ödeme: {sale.PaymentType}");
                receipt.AppendLine("========================================");
                receipt.AppendLine("ÜRÜN ADI                  ADET   TUTAR");
                receipt.AppendLine("========================================");

                foreach (var detail in sale.SaleDetails)
                {
                    string productName = detail.ProductName.Length > 20 
                        ? detail.ProductName.Substring(0, 20) 
                        : detail.ProductName.PadRight(20);
                    
                    receipt.AppendLine($"{productName} {detail.Quantity,4} {detail.TotalPrice,8:F2}₺");
                }

                receipt.AppendLine("========================================");
                receipt.AppendLine($"TOPLAM:                     {sale.TotalAmount,8:F2}₺");
                if (sale.DiscountAmount > 0)
                    receipt.AppendLine($"İNDİRİM:                   -{sale.DiscountAmount,8:F2}₺");
                receipt.AppendLine($"NET TUTAR:                  {sale.NetAmount,8:F2}₺");
                receipt.AppendLine("========================================");
                receipt.AppendLine("         TEŞEKKÜR EDERİZ!");
                receipt.AppendLine("========================================");

                // Fiş gösterme formunu aç
                var fisForm = new frmFisGoster(receipt.ToString());
                fisForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fiş oluşturulurken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductsToFlowPanel()
        {
            try
            {
                flowLayoutProducts.Controls.Clear();
                var products = ProductManager.GetAllProducts();
                
                foreach (var product in products)
                {
                    var productPanel = CreateProductTile(product);
                    flowLayoutProducts.Controls.Add(productPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler yüklenirken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private Panel CreateProductTile(Product product)
        {
            var panel = new Panel()
            {
                Size = new Size(120, 100),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(3),
                Cursor = Cursors.Hand
            };
            
            var lblName = new Label()
            {
                Text = product.ProductName.Length > 12 
                    ? product.ProductName.Substring(0, 12) + "..." 
                    : product.ProductName,
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                Location = new Point(2, 2),
                Size = new Size(116, 25),
                TextAlign = ContentAlignment.TopCenter,
                ForeColor = Color.FromArgb(51, 51, 51)
            };
            
            var lblPrice = new Label()
            {
                Text = $"{product.UnitPrice:C2}",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(2, 30),
                Size = new Size(116, 18),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(40, 167, 69)
            };
            
            var lblStock = new Label()
            {
                Text = $"Stok: {product.StockQuantity}",
                Font = new Font("Segoe UI", 7F),
                Location = new Point(2, 50),
                Size = new Size(116, 12),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = product.StockQuantity > 10 ? Color.Green : Color.Orange
            };
            
            var btnAdd = new Button()
            {
                Text = "Ekle",
                Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                Location = new Point(8, 68),
                Size = new Size(104, 25),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Tag = product
            };
            
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Click += (s, e) =>
            {
                AddProductToSaleByProduct(product);
            };
            
            panel.Controls.Add(lblName);
            panel.Controls.Add(lblPrice);
            panel.Controls.Add(lblStock);
            panel.Controls.Add(btnAdd);
            
            panel.Click += (s, e) =>
            {
                AddProductToSaleByProduct(product);
            };
            
            return panel;
        }
        
        private void AddProductToSaleByProduct(Product product)
        {
            try
            {
                if (product.StockQuantity <= 0)
                {
                    MessageBox.Show("Ürün stokta yok!", "Uyarı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingItem = saleDetails.FirstOrDefault(s => s.ProductCode == product.ProductCode);
                if (existingItem != null)
                {
                    if (existingItem.Quantity >= product.StockQuantity)
                    {
                        MessageBox.Show("Stok yetersiz!", "Uyarı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    existingItem.Quantity++;
                    existingItem.TotalPrice = existingItem.Quantity * existingItem.UnitPrice;
                }
                else
                {
                    var saleDetail = new SaleDetail
                    {
                        ProductCode = product.ProductCode,
                        ProductName = product.ProductName,
                        Quantity = 1,
                        UnitPrice = product.UnitPrice,
                        TotalPrice = product.UnitPrice,
                        DiscountAmount = 0
                    };
                    
                    saleDetails.Add(saleDetail);
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = saleDetails;
                
                UpdateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün eklenirken hata: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnKapat_Click(object sender, EventArgs e)
        {
            if (saleDetails.Count > 0)
            {
                if (MessageBox.Show("Tamamlanmamış satış var. Çıkmak istediğinizden emin misiniz?",
                    "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}