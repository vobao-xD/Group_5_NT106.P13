namespace Client.Admin
{
    partial class Admin_ListCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_ListCustomer));
            pictureBox1 = new PictureBox();
            ListCustomer = new TabControl();
            tabRegularCustomer = new TabPage();
            flowLayoutPanelRegular = new FlowLayoutPanel();
            VIPCustomer = new TabPage();
            flowLayoutPanelVIP = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ListCustomer.SuspendLayout();
            tabRegularCustomer.SuspendLayout();
            VIPCustomer.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-317, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1441, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // ListCustomer
            // 
            ListCustomer.Controls.Add(tabRegularCustomer);
            ListCustomer.Controls.Add(VIPCustomer);
            ListCustomer.Location = new Point(12, 85);
            ListCustomer.Name = "ListCustomer";
            ListCustomer.SelectedIndex = 0;
            ListCustomer.Size = new Size(564, 599);
            ListCustomer.TabIndex = 6;
            // 
            // tabRegularCustomer
            // 
            tabRegularCustomer.Controls.Add(flowLayoutPanelRegular);
            tabRegularCustomer.Location = new Point(4, 29);
            tabRegularCustomer.Name = "tabRegularCustomer";
            tabRegularCustomer.Padding = new Padding(3);
            tabRegularCustomer.Size = new Size(556, 566);
            tabRegularCustomer.TabIndex = 0;
            tabRegularCustomer.Text = "Regular Customer";
            tabRegularCustomer.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelRegular
            // 
            flowLayoutPanelRegular.AutoScroll = true;
            flowLayoutPanelRegular.Location = new Point(6, 6);
            flowLayoutPanelRegular.Name = "flowLayoutPanelRegular";
            flowLayoutPanelRegular.Size = new Size(544, 554);
            flowLayoutPanelRegular.TabIndex = 0;
            // 
            // VIPCustomer
            // 
            VIPCustomer.Controls.Add(flowLayoutPanelVIP);
            VIPCustomer.Location = new Point(4, 29);
            VIPCustomer.Name = "VIPCustomer";
            VIPCustomer.Padding = new Padding(3);
            VIPCustomer.Size = new Size(556, 566);
            VIPCustomer.TabIndex = 1;
            VIPCustomer.Text = "VIP Customer";
            VIPCustomer.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelVIP
            // 
            flowLayoutPanelVIP.AutoScroll = true;
            flowLayoutPanelVIP.Location = new Point(6, 6);
            flowLayoutPanelVIP.Name = "flowLayoutPanelVIP";
            flowLayoutPanelVIP.Size = new Size(544, 554);
            flowLayoutPanelVIP.TabIndex = 1;
            // 
            // Admin_ListCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 696);
            Controls.Add(ListCustomer);
            Controls.Add(pictureBox1);
            Name = "Admin_ListCustomer";
            Text = "Admin_ListCustomer";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ListCustomer.ResumeLayout(false);
            tabRegularCustomer.ResumeLayout(false);
            VIPCustomer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private TabControl ListCustomer;
        private TabPage tabRegularCustomer;
        private TabPage VIPCustomer;
        private FlowLayoutPanel flowLayoutPanelRegular;
        private FlowLayoutPanel flowLayoutPanelVIP;
    }
}