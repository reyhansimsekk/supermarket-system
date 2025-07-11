using SupermarketApp.BusinessLogic;
using SupermarketApp.Models;

namespace SupermarketApp.Forms
{
    public partial class frmSatisDetayi : Form
    {
        private int saleId;

        public frmSatisDetayi(int saleId)
        {
            this.saleId = saleId;
            InitializeComponent();
            this.Load += FrmSatisDetayi_Load;
        }

        private void FrmSatisDetayi_Load(object sender, EventArgs e)
        {
            LoadSaleDetails();
        }

        private void LoadSaleDetails()
        {
            try
            {
                var details = SalesManager.GetSaleDetails(saleId);
                dataGridView1.DataSource = details;
                
                decimal totalAmount = details.Sum(d => d.TotalPrice);
                lblSaleId.Text = $"Satış No: {saleId}";
                lblTotalAmount.Text = $"Toplam: {totalAmount:C2}";
                lblItemCount.Text = $"Ürün Sayısı: {details.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış detayları yüklenirken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            PrintReceipt();
        }

        private void PrintReceipt()
        {
            try
            {
                var details = SalesManager.GetSaleDetails(saleId);
                string receipt = GenerateReceiptText(details);
                
                // Fiş yazdırma simülasyonu
                var receiptForm = new frmFisGoster(receipt);
                receiptForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fiş oluşturulurken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateReceiptText(List<SaleDetail> details)
        {
            var receipt = new System.Text.StringBuilder();
            receipt.AppendLine("========================================");
            receipt.AppendLine("         SÜPERMARKET SİSTEMİ");
            receipt.AppendLine("========================================");
            receipt.AppendLine($"Satış No: {saleId}");
            receipt.AppendLine($"Tarih: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
            receipt.AppendLine($"Kasiyer: {frmLogin.CurrentUser?.FullName}");
            receipt.AppendLine("========================================");
            receipt.AppendLine("ÜRÜN ADI                  ADET   TUTAR");
            receipt.AppendLine("========================================");

            decimal total = 0;
            foreach (var detail in details)
            {
                string productName = detail.ProductName.Length > 20 
                    ? detail.ProductName.Substring(0, 20) 
                    : detail.ProductName.PadRight(20);
                
                receipt.AppendLine($"{productName} {detail.Quantity,4} {detail.TotalPrice,8:F2}₺");
                total += detail.TotalPrice;
            }

            receipt.AppendLine("========================================");
            receipt.AppendLine($"TOPLAM:                     {total,8:F2}₺");
            receipt.AppendLine("========================================");
            receipt.AppendLine("         TEŞEKKÜR EDERİZ!");
            receipt.AppendLine("========================================");

            return receipt.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}