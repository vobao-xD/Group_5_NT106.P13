namespace Client
{
    partial class Admin_Send_Email
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Send_Email));
            pictureBox1 = new PictureBox();
            progressBarEmail = new ProgressBar();
            btnSend = new Button();
            txtContent = new TextBox();
            txtSubject = new TextBox();
            pictureBox4 = new PictureBox();
            txtMailDestAddress = new TextBox();
            btnBrowse = new Button();
            txtPicturePath = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-4, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(927, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // progressBarEmail
            // 
            progressBarEmail.Location = new Point(63, 563);
            progressBarEmail.Name = "progressBarEmail";
            progressBarEmail.Size = new Size(786, 29);
            progressBarEmail.TabIndex = 43;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.Chocolate;
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(404, 517);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 42;
            btnSend.Text = "Gửi";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // txtContent
            // 
            txtContent.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContent.ForeColor = Color.Black;
            txtContent.Location = new Point(142, 281);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.PlaceholderText = "Nhập nội dung";
            txtContent.Size = new Size(622, 177);
            txtContent.TabIndex = 41;
            // 
            // txtSubject
            // 
            txtSubject.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSubject.ForeColor = Color.Black;
            txtSubject.Location = new Point(142, 221);
            txtSubject.Name = "txtSubject";
            txtSubject.PlaceholderText = "Nhập tiêu đề";
            txtSubject.Size = new Size(622, 34);
            txtSubject.TabIndex = 40;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(63, 128);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(786, 429);
            pictureBox4.TabIndex = 39;
            pictureBox4.TabStop = false;
            // 
            // txtMailDestAddress
            // 
            txtMailDestAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMailDestAddress.ForeColor = Color.Black;
            txtMailDestAddress.Location = new Point(142, 156);
            txtMailDestAddress.Name = "txtMailDestAddress";
            txtMailDestAddress.PlaceholderText = "Mail người nhận";
            txtMailDestAddress.Size = new Size(622, 34);
            txtMailDestAddress.TabIndex = 44;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(653, 473);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(111, 29);
            btnBrowse.TabIndex = 47;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtPicturePath
            // 
            txtPicturePath.Location = new Point(250, 474);
            txtPicturePath.Name = "txtPicturePath";
            txtPicturePath.Size = new Size(397, 27);
            txtPicturePath.TabIndex = 46;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(142, 477);
            label5.Name = "label5";
            label5.Size = new Size(102, 20);
            label5.TabIndex = 45;
            label5.Text = "Tệp đính kèm:";
            // 
            // Admin_Send_Email
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(919, 614);
            Controls.Add(btnBrowse);
            Controls.Add(txtPicturePath);
            Controls.Add(label5);
            Controls.Add(txtMailDestAddress);
            Controls.Add(progressBarEmail);
            Controls.Add(btnSend);
            Controls.Add(txtContent);
            Controls.Add(txtSubject);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox1);
            Name = "Admin_Send_Email";
            Text = "Admin_Send_Email";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ProgressBar progressBarEmail;
        private Button btnSend;
        private TextBox txtContent;
        private TextBox txtSubject;
        private PictureBox pictureBox4;
        private TextBox txtMailDestAddress;
        private Button btnBrowse;
        private TextBox txtPicturePath;
        private Label label5;
    }
}