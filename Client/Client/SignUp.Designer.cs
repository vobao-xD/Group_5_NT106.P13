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
            txtPhoneNumber = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtPassword = new TextBox();
            label5 = new Label();
            txtConfirmPassword = new TextBox();
            label6 = new Label();
            btnSignUp = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-1, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(862, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(147, 184);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 2;
            label1.Text = "Tên đăng nhập:";
            // 
            // txtLoginName
            // 
            txtLoginName.Location = new Point(304, 181);
            txtLoginName.Name = "txtLoginName";
            txtLoginName.Size = new Size(356, 27);
            txtLoginName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkOrange;
            label2.Location = new Point(349, 101);
            label2.Name = "label2";
            label2.Size = new Size(168, 54);
            label2.TabIndex = 4;
            label2.Text = "Đăng kí";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(304, 244);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(356, 27);
            txtPhoneNumber.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(147, 247);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 5;
            label3.Text = "SĐT:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(304, 309);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(356, 27);
            txtEmail.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(147, 312);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 7;
            label4.Text = "Email:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(304, 368);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(356, 27);
            txtPassword.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(147, 371);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 9;
            label5.Text = "Mật khẩu:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(304, 434);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(356, 27);
            txtConfirmPassword.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(147, 437);
            label6.Name = "label6";
            label6.Size = new Size(137, 20);
            label6.TabIndex = 11;
            label6.Text = "Xác nhận mật khấu:";
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(386, 500);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(94, 29);
            btnSignUp.TabIndex = 13;
            btnSignUp.Text = "Đăng kí";
            btnSignUp.UseVisualStyleBackColor = true;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(849, 541);
            Controls.Add(btnSignUp);
            Controls.Add(txtConfirmPassword);
            Controls.Add(label6);
            Controls.Add(txtPassword);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(txtPhoneNumber);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtLoginName);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
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
        private TextBox txtPhoneNumber;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtPassword;
        private Label label5;
        private TextBox txtConfirmPassword;
        private Label label6;
        private Button btnSignUp;
    }
}