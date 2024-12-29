namespace Client
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            txtLoginName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            label4 = new Label();
            checkBoxPassword = new CheckBox();
            lblForgetPassword = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1920, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtLoginName
            // 
            txtLoginName.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            txtLoginName.ForeColor = Color.Chocolate;
            txtLoginName.Location = new Point(648, 437);
            txtLoginName.Multiline = true;
            txtLoginName.Name = "txtLoginName";
            txtLoginName.Size = new Size(625, 60);
            txtLoginName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold);
            label1.ForeColor = Color.Chocolate;
            label1.Location = new Point(347, 441);
            label1.Name = "label1";
            label1.Size = new Size(295, 42);
            label1.TabIndex = 2;
            label1.Text = "Tên đăng nhập:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold);
            label2.ForeColor = Color.Chocolate;
            label2.Location = new Point(451, 595);
            label2.Name = "label2";
            label2.Size = new Size(191, 42);
            label2.TabIndex = 4;
            label2.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            txtPassword.ForeColor = Color.Chocolate;
            txtPassword.Location = new Point(648, 592);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(625, 60);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Transparent;
            btnLogin.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold);
            btnLogin.ForeColor = Color.Chocolate;
            btnLogin.Location = new Point(800, 802);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(342, 76);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkOrange;
            label4.Location = new Point(800, 240);
            label4.Name = "label4";
            label4.Size = new Size(342, 81);
            label4.TabIndex = 8;
            label4.Text = "Đăng nhập";
            // 
            // checkBoxPassword
            // 
            checkBoxPassword.AutoSize = true;
            checkBoxPassword.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBoxPassword.ForeColor = Color.Chocolate;
            checkBoxPassword.Location = new Point(1047, 664);
            checkBoxPassword.Name = "checkBoxPassword";
            checkBoxPassword.Size = new Size(226, 42);
            checkBoxPassword.TabIndex = 9;
            checkBoxPassword.Text = "Hiện mật khẩu";
            checkBoxPassword.UseVisualStyleBackColor = true;
            checkBoxPassword.CheckedChanged += checkBoxPassword_CheckedChanged;
            // 
            // lblForgetPassword
            // 
            lblForgetPassword.AutoSize = true;
            lblForgetPassword.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblForgetPassword.ForeColor = SystemColors.MenuHighlight;
            lblForgetPassword.Location = new Point(648, 668);
            lblForgetPassword.Name = "lblForgetPassword";
            lblForgetPassword.Size = new Size(225, 38);
            lblForgetPassword.TabIndex = 10;
            lblForgetPassword.Text = "Quên mật khẩu?";
            lblForgetPassword.Click += lblForgetPassword_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1920, 950);
            Controls.Add(lblForgetPassword);
            Controls.Add(checkBoxPassword);
            Controls.Add(label4);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Controls.Add(txtLoginName);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtLoginName;
        private Label label1;
        private Label label2;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label label4;
        private CheckBox checkBoxPassword;
        private Label lblForgetPassword;
    }
}