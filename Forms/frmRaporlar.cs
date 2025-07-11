namespace SupermarketApp.Forms
{
    public partial class frmRaporlar : Form
    {
        public frmRaporlar()
        {
            InitializeComponent();
        }

        private void btnGunlukSatis_Click(object sender, EventArgs e)
        {
            ShowDailySummary();
        }
        
        private void ShowDailySummary()
        {
            try
            {
                var today = DateTime.Today;
                var (revenue, cost, profit) = SupermarketApp.BusinessLogic.SalesManager.GetDailySummary(today);
                
                decimal profitMargin = revenue > 0 ? (profit / revenue) * 100 : 0;
                
                string report = $"📅 GÜNLÜK RAPOR - {today:dd.MM.yyyy}\n\n";
                report += $"💰 CİRO: {revenue:C2}\n";
                report += $"📦 MALİYET: {cost:C2}\n";
                report += $"📈 KAR: {profit:C2}\n";
                report += $"📊 KAR MARJI: %{profitMargin:F2}\n\n";
                
                if (profit > 0)
                    report += "✅ Günlük hedef kar elde edildi!";
                else if (profit == 0)
                    report += "⚠️ Günlük kar sıfır";
                else
                    report += "❌ Günlük zarar var!";
                
                MessageBox.Show(report, "Günlük Özet Raporu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rapor alınırken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAylikRapor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aylık Rapor\n(MySQL sorguları ve grafikler)", 
                "Rapor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStokRaporu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stok Raporu\n(Stok seviyeleri ve uyarılar)", 
                "Rapor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}