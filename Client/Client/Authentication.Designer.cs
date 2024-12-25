namespace Client
{
    partial class Authentication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authentication));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtOTP = new TextBox();
            btnAuthen = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-365, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1441, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(129, 79);
            label1.Name = "label1";
            label1.Size = new Size(476, 28);
            label1.TabIndex = 3;
            label1.Text = "Nhập mã xác thực OTP đã gửi đến Email của bạn";
            // 
            // txtOTP
            // 
            txtOTP.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOTP.Location = new Point(210, 110);
            txtOTP.Multiline = true;
            txtOTP.Name = "txtOTP";
            txtOTP.Size = new Size(312, 83);
            txtOTP.TabIndex = 4;
            // 
            // btnAuthen
            // 
            btnAuthen.Location = new Point(269, 205);
            btnAuthen.Name = "btnAuthen";
            btnAuthen.Size = new Size(203, 27);
            btnAuthen.TabIndex = 5;
            btnAuthen.Text = "Xác thực";
            btnAuthen.UseVisualStyleBackColor = true;
            btnAuthen.Click += btnAuthen_Click;
            // 
            // Authentication
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(741, 244);
            Controls.Add(btnAuthen);
            Controls.Add(txtOTP);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Authentication";
            Text = "Authentication";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtOTP;
        private Button btnAuthen;
    }
}