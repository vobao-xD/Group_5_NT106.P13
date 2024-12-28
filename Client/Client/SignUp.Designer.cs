namespace Client
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtLoginName = new TextBox();
            label2 = new Label();
            txtFullName = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtPassword = new TextBox();
            label5 = new Label();
            txtConfirmPassword = new TextBox();
            label6 = new Label();
            btnSignUp = new Button();
            checkBoxRevealPass = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(882, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.Chocolate;
            label1.Location = new Point(140, 176);
            label1.Name = "label1";
            label1.Size = new Size(128, 23);
            label1.TabIndex = 2;
            label1.Text = "Tên đăng nhập:";
            // 
            // txtLoginName
            // 
            txtLoginName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtLoginName.ForeColor = Color.Chocolate;
            txtLoginName.Location = new Point(310, 173);
            txtLoginName.Name = "txtLoginName";
            txtLoginName.Size = new Size(356, 30);
            txtLoginName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkOrange;
            label2.Location = new Point(354, 91);
            label2.Name = "label2";
            label2.Size = new Size(179, 54);
            label2.TabIndex = 4;
            label2.Text = "Đăng ký";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtFullName.ForeColor = Color.Chocolate;
            txtFullName.Location = new Point(310, 236);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(356, 30);
            txtFullName.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.Chocolate;
            label3.Location = new Point(140, 239);
            label3.Name = "label3";
            label3.Size = new Size(135, 23);
            label3.TabIndex = 5;
            label3.Text = "Tên người dùng:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtEmail.ForeColor = Color.Chocolate;
            txtEmail.Location = new Point(310, 301);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(356, 30);
            txtEmail.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label4.ForeColor = Color.Chocolate;
            label4.Location = new Point(140, 304);
            label4.Name = "label4";
            label4.Size = new Size(55, 23);
            label4.TabIndex = 7;
            label4.Text = "Email:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtPassword.ForeColor = Color.Chocolate;
            txtPassword.Location = new Point(310, 360);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(356, 30);
            txtPassword.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label5.ForeColor = Color.Chocolate;
            label5.Location = new Point(140, 363);
            label5.Name = "label5";
            label5.Size = new Size(88, 23);
            label5.TabIndex = 9;
            label5.Text = "Mật khẩu:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtConfirmPassword.ForeColor = Color.Chocolate;
            txtConfirmPassword.Location = new Point(310, 426);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(356, 30);
            txtConfirmPassword.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label6.ForeColor = Color.Chocolate;
            label6.Location = new Point(140, 429);
            label6.Name = "label6";
            label6.Size = new Size(164, 23);
            label6.TabIndex = 11;
            label6.Text = "Xác nhận mật khấu:";
            // 
            // btnSignUp
            // 
            btnSignUp.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignUp.ForeColor = Color.Chocolate;
            btnSignUp.Location = new Point(354, 486);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(179, 43);
            btnSignUp.TabIndex = 13;
            btnSignUp.Text = "Đăng ký";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // checkBoxRevealPass
            // 
            checkBoxRevealPass.AutoSize = true;
            checkBoxRevealPass.Location = new Point(691, 397);
            checkBoxRevealPass.Name = "checkBoxRevealPass";
            checkBoxRevealPass.Size = new Size(127, 24);
            checkBoxRevealPass.TabIndex = 14;
            checkBoxRevealPass.Text = "Hiện mật khẩu";
            checkBoxRevealPass.UseVisualStyleBackColor = true;
            checkBoxRevealPass.CheckedChanged += checkBoxRevealPass_CheckedChanged;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(882, 553);
            Controls.Add(checkBoxRevealPass);
            Controls.Add(btnSignUp);
            Controls.Add(txtConfirmPassword);
            Controls.Add(label6);
            Controls.Add(txtPassword);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(txtFullName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtLoginName);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SignUp";
            Text = "SignUp";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtLoginName;
        private Label label2;
        private TextBox txtFullName;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtPassword;
        private Label label5;
        private TextBox txtConfirmPassword;
        private Label label6;
        private Button btnSignUp;
        private CheckBox checkBoxRevealPass;
    }
}