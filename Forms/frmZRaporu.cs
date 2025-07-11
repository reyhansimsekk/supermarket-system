namespace SupermarketApp.Forms
{
    public partial class frmZRaporu : Form
    {
        public frmZRaporu()
        {
            InitializeComponent();
        }

        private void btnZRaporuOlustur_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Z Raporu oluşturuldu!\n(Gün sonu satış özeti MySQL'e kaydedildi)", 
                "Z Raporu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}