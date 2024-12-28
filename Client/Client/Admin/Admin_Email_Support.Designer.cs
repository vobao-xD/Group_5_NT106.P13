namespace Client.Admin
{
    partial class Admin_Email_Support
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Email_Support));
            pictureBox1 = new PictureBox();
            dataGridViewEmails = new DataGridView();
            NumOrder = new DataGridViewTextBoxColumn();
            Subject = new DataGridViewTextBoxColumn();
            From = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            btnRefresh = new Button();
            btnSendEmail = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmails).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1077, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // dataGridViewEmails
            // 
            dataGridViewEmails.AllowUserToAddRows = false;
            dataGridViewEmails.AllowUserToDeleteRows = false;
            dataGridViewEmails.AllowUserToResizeColumns = false;
            dataGridViewEmails.AllowUserToResizeRows = false;
            dataGridViewEmails.BackgroundColor = Color.White;
            dataGridViewEmails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmails.Columns.AddRange(new DataGridViewColumn[] { NumOrder, Subject, From, Date });
            dataGridViewEmails.GridColor = Color.White;
            dataGridViewEmails.Location = new Point(12, 83);
            dataGridViewEmails.Name = "dataGridViewEmails";
            dataGridViewEmails.ReadOnly = true;
            dataGridViewEmails.RowHeadersVisible = false;
            dataGridViewEmails.RowHeadersWidth = 51;
            dataGridViewEmails.Size = new Size(1054, 364);
            dataGridViewEmails.TabIndex = 16;
            dataGridViewEmails.CellContentDoubleClick += dataGridViewEmails_CellContentDoubleClick;
            // 
            // NumOrder
            // 
            NumOrder.HeaderText = "#";
            NumOrder.MinimumWidth = 6;
            NumOrder.Name = "NumOrder";
            NumOrder.ReadOnly = true;
            NumOrder.Width = 50;
            // 
            // Subject
            // 
            Subject.HeaderText = "Tiêu đề";
            Subject.MinimumWidth = 6;
            Subject.Name = "Subject";
            Subject.ReadOnly = true;
            Subject.Width = 300;
            // 
            // From
            // 
            From.HeaderText = "Từ";
            From.MinimumWidth = 6;
            From.Name = "From";
            From.ReadOnly = true;
            From.Width = 500;
            // 
            // Date
            // 
            Date.HeaderText = "Ngày";
            Date.MinimumWidth = 6;
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Width = 200;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.Chocolate;
            btnRefresh.Location = new Point(12, 464);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(118, 39);
            btnRefresh.TabIndex = 24;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSendEmail
            // 
            btnSendEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSendEmail.ForeColor = Color.Chocolate;
            btnSendEmail.Location = new Point(947, 464);
            btnSendEmail.Name = "btnSendEmail";
            btnSendEmail.Size = new Size(118, 39);
            btnSendEmail.TabIndex = 25;
            btnSendEmail.Text = "Gửi mail";
            btnSendEmail.UseVisualStyleBackColor = true;
            btnSendEmail.Click += btnSendEmail_Click;
            // 
            // Admin_Email_Support
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1078, 538);
            Controls.Add(btnSendEmail);
            Controls.Add(btnRefresh);
            Controls.Add(dataGridViewEmails);
            Controls.Add(pictureBox1);
            Name = "Admin_Email_Support";
            Text = "Admin_Email_Support";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmails).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridViewEmails;
        private Button btnRefresh;
        private Button btnSendEmail;
        private DataGridViewTextBoxColumn NumOrder;
        private DataGridViewTextBoxColumn Subject;
        private DataGridViewTextBoxColumn From;
        private DataGridViewTextBoxColumn Date;
    }
}