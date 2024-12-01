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
            label3 = new Label();
            btnSignUp = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(862, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // txtLoginName
            // 
            txtLoginName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLoginName.Location = new Point(310, 166);
            txtLoginName.Multiline = true;
            txtLoginName.Name = "txtLoginName";
            txtLoginName.Size = new Size(350, 41);
            txtLoginName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(120, 169);
            label1.Name = "label1";
            label1.Size = new Size(171, 31);
            label1.TabIndex = 2;
            label1.Text = "Tên đăng nhập:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(120, 240);
            label2.Name = "label2";
            label2.Size = new Size(115, 31);
            label2.TabIndex = 4;
            label2.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(310, 237);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(350, 41);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(416, 318);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(310, 400);
            label3.Name = "label3";
            label3.Size = new Size(135, 20);
            label3.TabIndex = 6;
            label3.Text = "Chưa có tài khoản?";
            // 
            // btnSignUp
            // 
            btnSignUp.ForeColor = Color.Black;
            btnSignUp.Location = new Point(469, 396);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(94, 29);
            btnSignUp.TabIndex = 7;
            btnSignUp.Text = "Đăng kí";
            btnSignUp.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(862, 482);
            Controls.Add(btnSignUp);
            Controls.Add(label3);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Controls.Add(txtLoginName);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ButtonHighlight;
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
        private Label label3;
        private Button btnSignUp;
    }
}