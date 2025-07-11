using SupermarketApp.BusinessLogic;

namespace SupermarketApp.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (frmLogin.CurrentUser != null)
            {
                lblCurrentUser.Text = $"Kullanıcı: {frmLogin.CurrentUser.FullName} ({frmLogin.CurrentUser.UserType})";
                lblLoginTime.Text = $"Giriş Zamanı: {DateTime.Now:dd.MM.yyyy HH:mm}";
                
                SetUserPermissions();
                CheckLowStock();
            }
            else
            {
                MessageBox.Show("Kullanıcı bilgisi bulunamadı!", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void SetUserPermissions()
        {
            if (frmLogin.CurrentUser?.UserType == "Kasiyer")
            {
                btnUrunler.Enabled = false;
                btnRaporlar.Enabled = false;
                btnZRaporu.Enabled = false;
                btnKullanicilar.Enabled = false;
                btnAyarlar.Enabled = false;
            }
        }

        private void CheckLowStock()
        {
            try
            {
                var lowStockProducts = ProductManager.GetLowStockProducts();
                if (lowStockProducts.Count > 0)
                {
                    string message = $"{lowStockProducts.Count} ürünün stoğu kritik seviyede!\n\n";
                    foreach (var product in lowStockProducts.Take(5))
                    {
                        message += $"• {product.ProductName}: {product.StockQuantity} adet\n";
                    }
                    
                    if (lowStockProducts.Count > 5)
                        message += $"... ve {lowStockProducts.Count - 5} ürün daha";

                    MessageBox.Show(message, "Stok Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stok kontrolü yapılırken hata: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            var frmSatis = new frmSatis();
            ShowFormInPanel(frmSatis, sender);
        }

        private void btnUrunler_Click(object sender, EventArgs e)
        {
            var frmUrunler = new frmUrunler();
            ShowFormInPanel(frmUrunler, sender);
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            var frmRaporlar = new frmRaporlar();
            ShowFormInPanel(frmRaporlar, sender);
        }

        private void btnZRaporu_Click(object sender, EventArgs e)
        {
            var frmZRaporu = new frmZRaporu();
            ShowFormInPanel(frmZRaporu, sender);
        }

        private void btnKullanicilar_Click(object sender, EventArgs e)
        {
            var frmKullanicilar = new frmKullanicilar();
            ShowFormInPanel(frmKullanicilar, sender);
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ayarlar menüsü geliştirme aşamasında.", "Bilgi", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Uygulamadan çıkmak istediğinizden emin misiniz?", 
                "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnStokKontrol_Click(object sender, EventArgs e)
        {
            CheckLowStock();
        }

        private void ShowFormInPanel(Form childForm, object sender = null)
        {
            foreach (Control ctrl in pnlMainContent.Controls)
            {
                if (ctrl is Form)
                {
                    ctrl.Dispose();
                }
            }
            pnlMainContent.Controls.Clear();
            
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(childForm);
            childForm.Show();
            
            ResetButtonColors();
            if (sender is Button btn)
            {
                btn.BackColor = Color.FromArgb(0, 122, 204);
            }
        }
        
        private void ResetButtonColors()
        {
            foreach (Control ctrl in pnlSidePanel.Controls)
            {
                if (ctrl is Button btn && btn != btnCikis)
                {
                    btn.BackColor = Color.FromArgb(70, 70, 74);
                }
            }
        }

        private void btnHakkinda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Süpermarket Otomasyon Sistemi v1.0\n\nGeliştirici: AI Assistant\nTarih: 2024", 
                "Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}