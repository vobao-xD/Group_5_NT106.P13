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
            progressBarEmail = new ProgressBar();
            btnSend = new Button();
            txtContent = new TextBox();
            txtSubject = new TextBox();
            pictureBox4 = new PictureBox();
            txtMailDestAddress = new TextBox();
            btnBrowse = new Button();
            txtPicturePath = new TextBox();
            label5 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // progressBarEmail
            // 
            progressBarEmail.Location = new Point(420, 746);
            progressBarEmail.Name = "progressBarEmail";
            progressBarEmail.Size = new Size(786, 29);
            progressBarEmail.TabIndex = 43;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.Chocolate;
            btnSend.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(672, 796);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(248, 63);
            btnSend.TabIndex = 42;
            btnSend.Text = "Gửi";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // txtContent
            // 
            txtContent.Font = new Font("Segoe UI", 13.8F);
            txtContent.ForeColor = Color.Black;
            txtContent.Location = new Point(440, 375);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.PlaceholderText = "Nhập nội dung";
            txtContent.Size = new Size(739, 217);
            txtContent.TabIndex = 41;
            // 
            // txtSubject
            // 
            txtSubject.Font = new Font("Segoe UI", 13.8F);
            txtSubject.ForeColor = Color.Black;
            txtSubject.Location = new Point(440, 285);
            txtSubject.Name = "txtSubject";
            txtSubject.PlaceholderText = "Nhập tiêu đề";
            txtSubject.Size = new Size(739, 38);
            txtSubject.TabIndex = 40;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(420, 171);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(786, 559);
            pictureBox4.TabIndex = 39;
            pictureBox4.TabStop = false;
            // 
            // txtMailDestAddress
            // 
            txtMailDestAddress.Font = new Font("Segoe UI", 13.8F);
            txtMailDestAddress.ForeColor = Color.Black;
            txtMailDestAddress.Location = new Point(440, 194);
            txtMailDestAddress.Name = "txtMailDestAddress";
            txtMailDestAddress.PlaceholderText = "Mail người nhận";
            txtMailDestAddress.Size = new Size(739, 38);
            txtMailDestAddress.TabIndex = 44;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(1031, 625);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(148, 35);
            btnBrowse.TabIndex = 47;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtPicturePath
            // 
            txtPicturePath.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPicturePath.Location = new Point(609, 625);
            txtPicturePath.Name = "txtPicturePath";
            txtPicturePath.Size = new Size(397, 38);
            txtPicturePath.TabIndex = 46;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(459, 630);
            label5.Name = "label5";
            label5.Size = new Size(134, 28);
            label5.TabIndex = 45;
            label5.Text = "Tệp đính kèm:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.System;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Chocolate;
            label1.Location = new Point(510, 58);
            label1.Name = "label1";
            label1.Size = new Size(625, 81);
            label1.TabIndex = 48;
            label1.Text = "Phản hồi khách hàng";
            // 
            // Admin_Send_Email
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1552, 882);
            Controls.Add(label1);
            Controls.Add(btnBrowse);
            Controls.Add(txtPicturePath);
            Controls.Add(label5);
            Controls.Add(txtMailDestAddress);
            Controls.Add(progressBarEmail);
            Controls.Add(btnSend);
            Controls.Add(txtContent);
            Controls.Add(txtSubject);
            Controls.Add(pictureBox4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Admin_Send_Email";
            Text = "Admin_Send_Email";
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ProgressBar progressBarEmail;
        private Button btnSend;
        private TextBox txtContent;
        private TextBox txtSubject;
        private PictureBox pictureBox4;
        private TextBox txtMailDestAddress;
        private Button btnBrowse;
        private TextBox txtPicturePath;
        private Label label5;
        private Label label1;
    }
}