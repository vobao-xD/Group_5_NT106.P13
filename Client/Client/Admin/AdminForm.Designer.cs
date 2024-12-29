namespace Client
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            panel1 = new Panel();
            btnAnalyse = new Button();
            btnAddTrip = new Button();
            btnListCustomer = new Button();
            btnContact = new Button();
            btnMenu = new Button();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAnalyse);
            panel1.Controls.Add(btnAddTrip);
            panel1.Controls.Add(btnListCustomer);
            panel1.Controls.Add(btnContact);
            panel1.Controls.Add(btnMenu);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 1033);
            panel1.TabIndex = 14;
            // 
            // btnAnalyse
            // 
            btnAnalyse.BackColor = Color.Firebrick;
            btnAnalyse.Dock = DockStyle.Top;
            btnAnalyse.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnAnalyse.ForeColor = SystemColors.Control;
            btnAnalyse.Location = new Point(0, 350);
            btnAnalyse.Margin = new Padding(5);
            btnAnalyse.Name = "btnAnalyse";
            btnAnalyse.Size = new Size(350, 75);
            btnAnalyse.TabIndex = 23;
            btnAnalyse.Text = "Thống kê";
            btnAnalyse.UseCompatibleTextRendering = true;
            btnAnalyse.UseVisualStyleBackColor = false;
            btnAnalyse.Click += btnAnalyse_Click;
            // 
            // btnAddTrip
            // 
            btnAddTrip.BackColor = Color.Firebrick;
            btnAddTrip.Dock = DockStyle.Top;
            btnAddTrip.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnAddTrip.ForeColor = SystemColors.Control;
            btnAddTrip.Location = new Point(0, 275);
            btnAddTrip.Margin = new Padding(5);
            btnAddTrip.Name = "btnAddTrip";
            btnAddTrip.Size = new Size(350, 75);
            btnAddTrip.TabIndex = 24;
            btnAddTrip.Text = "Thêm chuyến xe";
            btnAddTrip.UseCompatibleTextRendering = true;
            btnAddTrip.UseVisualStyleBackColor = false;
            btnAddTrip.Click += btnAddTrip_Click;
            // 
            // btnListCustomer
            // 
            btnListCustomer.BackColor = Color.Firebrick;
            btnListCustomer.Dock = DockStyle.Top;
            btnListCustomer.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnListCustomer.ForeColor = SystemColors.Control;
            btnListCustomer.Location = new Point(0, 200);
            btnListCustomer.Margin = new Padding(5);
            btnListCustomer.Name = "btnListCustomer";
            btnListCustomer.Size = new Size(350, 75);
            btnListCustomer.TabIndex = 19;
            btnListCustomer.Text = "Xem thông tin KH";
            btnListCustomer.UseCompatibleTextRendering = true;
            btnListCustomer.UseVisualStyleBackColor = false;
            btnListCustomer.Click += btnListCustomer_Click;
            // 
            // btnContact
            // 
            btnContact.BackColor = Color.Firebrick;
            btnContact.Dock = DockStyle.Top;
            btnContact.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnContact.ForeColor = SystemColors.Control;
            btnContact.Location = new Point(0, 125);
            btnContact.Margin = new Padding(5);
            btnContact.Name = "btnContact";
            btnContact.Size = new Size(350, 75);
            btnContact.TabIndex = 22;
            btnContact.Text = "Đọc hỗ trợ";
            btnContact.UseCompatibleTextRendering = true;
            btnContact.UseVisualStyleBackColor = false;
            btnContact.Click += btnContact_Click;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.IndianRed;
            btnMenu.Dock = DockStyle.Top;
            btnMenu.Enabled = false;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu.ForeColor = SystemColors.Control;
            btnMenu.Location = new Point(0, 0);
            btnMenu.Margin = new Padding(5);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(350, 125);
            btnMenu.TabIndex = 18;
            btnMenu.Text = "Menu";
            btnMenu.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(350, 0);
            pictureBox1.Margin = new Padding(5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1552, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1902, 1033);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            IsMdiContainer = true;
            Margin = new Padding(5);
            Name = "AdminForm";
            Text = "AdminForm";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private PictureBox pictureBox1;
        private Button btnListCustomer;
        private Button btnContact;
        private Button btnMenu;
        private Button btnAnalyse;
        private Button btnAddTrip;
    }
}