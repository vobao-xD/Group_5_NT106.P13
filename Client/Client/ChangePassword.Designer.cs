namespace Client
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            pictureBox1 = new PictureBox();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            lblNewPassword = new Label();
            lblConfirmPassword = new Label();
            btnChangePassword = new Button();
            chkRevealPassword = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-34, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(862, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(349, 90);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(316, 27);
            txtNewPassword.TabIndex = 3;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(349, 151);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(316, 27);
            txtConfirmPassword.TabIndex = 4;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(189, 97);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(140, 20);
            lblNewPassword.TabIndex = 5;
            lblNewPassword.Text = "Nhập mật khẩu mới";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(189, 158);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(154, 20);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "Xác nhận lại mật khẩu";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(510, 184);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(155, 61);
            btnChangePassword.TabIndex = 7;
            btnChangePassword.Text = "Đổi mật khẩu";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // chkRevealPassword
            // 
            chkRevealPassword.AutoSize = true;
            chkRevealPassword.Location = new Point(674, 124);
            chkRevealPassword.Name = "chkRevealPassword";
            chkRevealPassword.Size = new Size(148, 24);
            chkRevealPassword.TabIndex = 8;
            chkRevealPassword.Text = "Hiển thị mật khẩu";
            chkRevealPassword.UseVisualStyleBackColor = true;
            chkRevealPassword.CheckedChanged += chkRevealPassword_CheckedChanged;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 257);
            Controls.Add(chkRevealPassword);
            Controls.Add(btnChangePassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(pictureBox1);
            Name = "ChangePassword";
            Text = "ChangePassword";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Label lblNewPassword;
        private Label lblConfirmPassword;
        private Button btnChangePassword;
        private CheckBox chkRevealPassword;
    }
}