namespace SupermarketApp.Forms
{
    public partial class frmKullanicilar : Form
    {
        public frmKullanicilar()
        {
            InitializeComponent();
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kullanıcı ekleme özelliği aktif!\n(UserManager sınıfı kullanılacak)", 
                "Kullanıcı Yönetimi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}