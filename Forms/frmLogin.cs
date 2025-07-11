using SupermarketApp.BusinessLogic;
using SupermarketApp.Models;
using SupermarketApp.Data;

namespace SupermarketApp.Forms
{
    public partial class frmLogin : Form
    {
        public static User? CurrentUser { get; set; }

        public frmLogin()
        {
            InitializeComponent();
            this.Load += FrmLogin_Load;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "admin123";
            txtUsername.Focus();
            
            if (!DatabaseConnection.TestConnection())
            {
                MessageBox.Show("Veritabanı bağlantısı kurulamadı!\nLütfen bağlantı ayarlarını kontrol edin.",
                    "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Kullanıcı adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Şifre boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                btnLogin.Enabled = false;
                btnLogin.Text = "Giriş yapılıyor...";

                var user = UserManager.AuthenticateUser(txtUsername.Text.Trim(), txtPassword.Text);

                if (user != null)
                {
                    CurrentUser = user;
                    this.Hide();

                    var mainForm = new frmMain();
                    mainForm.FormClosed += (s, args) => Application.Exit();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Giriş Hatası", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = "";
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş sırasında hata oluştu:\n{ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Giriş Yap";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }
    }
}