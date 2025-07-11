using SupermarketApp.BusinessLogic;
using SupermarketApp.Models;

namespace SupermarketApp.Forms
{
    public partial class frmSatisRaporlari : Form
    {
        public frmSatisRaporlari()
        {
            InitializeComponent();
            this.Load += FrmSatisRaporlari_Load;
        }

        private void FrmSatisRaporlari_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            LoadSalesReport();
        }

        private void LoadSalesReport()
        {
            try
            {
                var sales = SalesManager.GetSalesByDate(dateTimePicker1.Value);
                dataGridView1.DataSource = sales;
                
                decimal totalAmount = sales.Sum(s => s.NetAmount);
                lblTotalSales.Text = $"Toplam Satış: {sales.Count} adet";
                lblTotalAmount.Text = $"Toplam Tutar: {totalAmount:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rapor yüklenirken hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSalesReport();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadSalesReport();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].DataBoundItem is Sale selectedSale)
            {
                var detailForm = new frmSatisDetayi(selectedSale.SaleID);
                detailForm.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}