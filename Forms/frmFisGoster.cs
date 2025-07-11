namespace SupermarketApp.Forms
{
    public partial class frmFisGoster : Form
    {
        private string receiptText;

        public frmFisGoster(string receiptText)
        {
            this.receiptText = receiptText;
            InitializeComponent();
            this.Load += FrmFisGoster_Load;
        }

        private void FrmFisGoster_Load(object sender, EventArgs e)
        {
            txtReceipt.Text = receiptText;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // Gerçek yazıcıya yazdırma işlemi burada olacak
                MessageBox.Show("Fiş yazıcıya gönderildi!", "Yazdırma", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yazdırma hatası: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveDialog.DefaultExt = "txt";
                    saveDialog.FileName = $"Fis_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveDialog.FileName, receiptText);
                        MessageBox.Show("Fiş dosyaya kaydedildi!", "Kaydetme", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kaydetme hatası: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}