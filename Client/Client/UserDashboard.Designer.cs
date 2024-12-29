namespace Client
{
    partial class UserDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDashboard));
            panel1 = new Panel();
            btnTicketSearch = new Button();
            btnContact = new Button();
            btnHome = new Button();
            btnMenu = new Button();
            pictureBox1 = new PictureBox();
            statusStrip1 = new StatusStrip();
            labelUsername = new ToolStripStatusLabel();
            labelUserEmail = new ToolStripStatusLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnTicketSearch);
            panel1.Controls.Add(btnContact);
            panel1.Controls.Add(btnHome);
            panel1.Controls.Add(btnMenu);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 703);
            panel1.TabIndex = 0;
            // 
            // btnTicketSearch
            // 
            btnTicketSearch.BackColor = Color.Firebrick;
            btnTicketSearch.Dock = DockStyle.Top;
            btnTicketSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTicketSearch.ForeColor = SystemColors.Control;
            btnTicketSearch.Location = new Point(0, 225);
            btnTicketSearch.Name = "btnTicketSearch";
            btnTicketSearch.Size = new Size(250, 75);
            btnTicketSearch.TabIndex = 11;
            btnTicketSearch.Text = "Tra cứu vé";
            btnTicketSearch.UseCompatibleTextRendering = true;
            btnTicketSearch.UseVisualStyleBackColor = false;
            btnTicketSearch.Click += btnTicketSearch_Click;
            // 
            // btnContact
            // 
            btnContact.BackColor = Color.Firebrick;
            btnContact.Dock = DockStyle.Top;
            btnContact.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnContact.ForeColor = SystemColors.Control;
            btnContact.Location = new Point(0, 150);
            btnContact.Name = "btnContact";
            btnContact.Size = new Size(250, 75);
            btnContact.TabIndex = 10;
            btnContact.Text = "Hỗ trợ";
            btnContact.UseCompatibleTextRendering = true;
            btnContact.UseVisualStyleBackColor = false;
            btnContact.Click += btnContact_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.Firebrick;
            btnHome.Dock = DockStyle.Top;
            btnHome.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = SystemColors.Control;
            btnHome.Location = new Point(0, 75);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(250, 75);
            btnHome.TabIndex = 8;
            btnHome.Text = "Trang chủ";
            btnHome.UseCompatibleTextRendering = true;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
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
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(250, 75);
            btnMenu.TabIndex = 9;
            btnMenu.Text = "Menu";
            btnMenu.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(250, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(982, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { labelUsername, labelUserEmail });
            statusStrip1.Location = new Point(250, 677);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(982, 26);
            statusStrip1.TabIndex = 24;
            statusStrip1.Text = "statusStrip1";
            // 
            // labelUsername
            // 
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(108, 20);
            labelUsername.Text = "labelUsername";
            // 
            // labelUserEmail
            // 
            labelUserEmail.Name = "labelUserEmail";
            labelUserEmail.Size = new Size(108, 20);
            labelUserEmail.Text = "labelUserEmail";
            // 
            // UserDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 703);
            Controls.Add(statusStrip1);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            IsMdiContainer = true;
            Name = "UserDashboard";
            Text = "Dashboard";
            FormClosed += UserDashboard_FormClosed;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button btnTicketSearch;
        private Button btnContact;
        private Button btnHome;
        private Button btnMenu;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labelUsername;
        private ToolStripStatusLabel labelUserEmail;
    }
}