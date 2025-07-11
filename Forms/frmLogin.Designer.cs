namespace SupermarketApp.Forms
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelMain;
        private Label lblTitle;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private PictureBox pictureBox1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new Panel();
            this.lblTitle = new Label();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnExit = new Button();
            this.pictureBox1 = new PictureBox();
            
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            
            // panelMain
            this.panelMain.BackColor = Color.White;
            this.panelMain.Controls.Add(this.pictureBox1);
            this.panelMain.Controls.Add(this.btnExit);
            this.panelMain.Controls.Add(this.btnLogin);
            this.panelMain.Controls.Add(this.txtPassword);
            this.panelMain.Controls.Add(this.txtUsername);
            this.panelMain.Controls.Add(this.lblPassword);
            this.panelMain.Controls.Add(this.lblUsername);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new Size(400, 300);
            this.panelMain.TabIndex = 0;
            
            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(32, 146, 204);
            this.lblTitle.Location = new Point(50, 100);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(300, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SÜPERMARKET SİSTEMİ";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            
            // pictureBox1
            this.pictureBox1.BackColor = Color.LightBlue;
            this.pictureBox1.Location = new Point(175, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(50, 50);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            
            // lblUsername
            this.lblUsername.Font = new Font("Segoe UI", 9F);
            this.lblUsername.Location = new Point(80, 150);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(68, 14);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Kullanıcı Adı:";
            
            // txtUsername
            this.txtUsername.Font = new Font("Segoe UI", 10F);
            this.txtUsername.Location = new Point(80, 170);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(240, 25);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.KeyPress += new KeyPressEventHandler(this.txtUsername_KeyPress);
            
            // lblPassword
            this.lblPassword.Font = new Font("Segoe UI", 9F);
            this.lblPassword.Location = new Point(80, 200);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(30, 14);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Şifre:";
            
            // txtPassword
            this.txtPassword.Font = new Font("Segoe UI", 10F);
            this.txtPassword.Location = new Point(80, 220);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(240, 25);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.KeyPress += new KeyPressEventHandler(this.txtPassword_KeyPress);
            
            // btnLogin
            this.btnLogin.BackColor = Color.FromArgb(32, 146, 204);
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.Location = new Point(80, 260);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new Size(115, 30);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Giriş Yap";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);
            
            // btnExit
            this.btnExit.BackColor = Color.FromArgb(220, 53, 69);
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnExit.ForeColor = Color.White;
            this.btnExit.Location = new Point(205, 260);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(115, 30);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Çıkış";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);
            
            // frmLogin
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 300);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}