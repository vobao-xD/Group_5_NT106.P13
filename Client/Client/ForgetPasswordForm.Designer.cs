namespace Client
{
    partial class ForgetPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgetPasswordForm));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtEmail = new TextBox();
            btnSend = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-119, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(862, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 97);
            label1.Name = "label1";
            label1.Size = new Size(246, 20);
            label1.TabIndex = 2;
            label1.Text = "Nhập email để yêu cầu lại mật khẩu";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(264, 90);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(251, 27);
            txtEmail.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(12, 129);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(147, 29);
            btnSend.TabIndex = 4;
            btnSend.Text = "Gửi yêu cầu";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // ForgetPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(637, 170);
            Controls.Add(btnSend);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "ForgetPasswordForm";
            Text = "ForgetPasswordForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtEmail;
        private Button btnSend;
    }
}