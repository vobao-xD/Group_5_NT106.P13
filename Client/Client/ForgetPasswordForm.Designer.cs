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
            txtEmail = new TextBox();
            label4 = new Label();
            label2 = new Label();
            btnHelp = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1900, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.Chocolate;
            txtEmail.Location = new Point(641, 582);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(619, 57);
            txtEmail.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkOrange;
            label4.Location = new Point(713, 256);
            label4.Name = "label4";
            label4.Size = new Size(466, 81);
            label4.TabIndex = 9;
            label4.Text = "Quên mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold);
            label2.ForeColor = Color.Chocolate;
            label2.Location = new Point(626, 487);
            label2.Name = "label2";
            label2.Size = new Size(644, 42);
            label2.TabIndex = 10;
            label2.Text = "Nhập email để yêu cầu lại mật khẩu";
            // 
            // btnHelp
            // 
            btnHelp.BackColor = Color.Transparent;
            btnHelp.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold);
            btnHelp.ForeColor = Color.Chocolate;
            btnHelp.Location = new Point(780, 774);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(342, 76);
            btnHelp.TabIndex = 11;
            btnHelp.Text = "Gửi yêu cầu";
            btnHelp.UseVisualStyleBackColor = false;
            btnHelp.Click += btnHelp_Click;
            // 
            // ForgetPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1900, 950);
            Controls.Add(btnHelp);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ForgetPasswordForm";
            Text = "ForgetPasswordForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtEmail;
        private Label label4;
        private Label label2;
        private Button btnHelp;
    }
}