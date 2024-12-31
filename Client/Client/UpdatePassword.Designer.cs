namespace Client
{
    partial class UpdatePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePassword));
            pictureBox1 = new PictureBox();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            RevealPassword = new CheckBox();
            btnUpdatePassword = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(619, 71);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(151, 76);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(236, 23);
            txtNewPassword.TabIndex = 2;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(151, 114);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(236, 23);
            txtConfirmPassword.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 84);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 4;
            label1.Text = "Nhập mật khẩu mới";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 122);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 5;
            label2.Text = "Xác nhận mật khẩu";
            // 
            // RevealPassword
            // 
            RevealPassword.AutoSize = true;
            RevealPassword.Location = new Point(393, 118);
            RevealPassword.Name = "RevealPassword";
            RevealPassword.Size = new Size(121, 19);
            RevealPassword.TabIndex = 6;
            RevealPassword.Text = "Hiển thị mật khẩu";
            RevealPassword.UseVisualStyleBackColor = true;
            RevealPassword.CheckedChanged += RevealPassword_CheckedChanged;
            // 
            // btnUpdatePassword
            // 
            btnUpdatePassword.Location = new Point(151, 143);
            btnUpdatePassword.Name = "btnUpdatePassword";
            btnUpdatePassword.Size = new Size(134, 23);
            btnUpdatePassword.TabIndex = 7;
            btnUpdatePassword.Text = "Cập nhật mật khẩu";
            btnUpdatePassword.UseVisualStyleBackColor = true;
            btnUpdatePassword.Click += btnUpdatePassword_Click;
            // 
            // UpdatePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 188);
            Controls.Add(btnUpdatePassword);
            Controls.Add(RevealPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(pictureBox1);
            Name = "UpdatePassword";
            Text = "UpdatePassword";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Label label1;
        private Label label2;
        private CheckBox RevealPassword;
        private Button btnUpdatePassword;
    }
}