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
            pictureBox1.Location = new Point(-277, 2);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1261, 58);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // ListCustomer
            // 
            ListCustomer.Controls.Add(tabRegularCustomer);
            ListCustomer.Controls.Add(VIPCustomer);
            ListCustomer.Location = new Point(10, 64);
            ListCustomer.Margin = new Padding(3, 2, 3, 2);
            ListCustomer.Name = "ListCustomer";
            ListCustomer.SelectedIndex = 0;
            ListCustomer.Size = new Size(526, 449);
            ListCustomer.TabIndex = 6;
            // 
            // tabRegularCustomer
            // 
            tabRegularCustomer.Controls.Add(flowLayoutPanelRegular);
            tabRegularCustomer.Location = new Point(4, 24);
            tabRegularCustomer.Margin = new Padding(3, 2, 3, 2);
            tabRegularCustomer.Name = "tabRegularCustomer";
            tabRegularCustomer.Padding = new Padding(3, 2, 3, 2);
            tabRegularCustomer.Size = new Size(518, 421);
            tabRegularCustomer.TabIndex = 0;
            tabRegularCustomer.Text = "Regular Customer";
            tabRegularCustomer.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelRegular
            // 
            flowLayoutPanelRegular.AutoScroll = true;
            flowLayoutPanelRegular.Location = new Point(5, 4);
            flowLayoutPanelRegular.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanelRegular.Name = "flowLayoutPanelRegular";
            flowLayoutPanelRegular.Size = new Size(507, 416);
            flowLayoutPanelRegular.TabIndex = 0;
            // 
            // VIPCustomer
            // 
            VIPCustomer.Controls.Add(flowLayoutPanelVIP);
            VIPCustomer.Location = new Point(4, 24);
            VIPCustomer.Margin = new Padding(3, 2, 3, 2);
            VIPCustomer.Name = "VIPCustomer";
            VIPCustomer.Padding = new Padding(3, 2, 3, 2);
            VIPCustomer.Size = new Size(518, 421);
            VIPCustomer.TabIndex = 1;
            VIPCustomer.Text = "VIP Customer";
            VIPCustomer.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelVIP
            // 
            flowLayoutPanelVIP.AutoScroll = true;
            flowLayoutPanelVIP.Location = new Point(5, 4);
            flowLayoutPanelVIP.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanelVIP.Name = "flowLayoutPanelVIP";
            flowLayoutPanelVIP.Size = new Size(507, 416);
            flowLayoutPanelVIP.TabIndex = 1;
            // 
            // Admin_ListCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 522);
            Controls.Add(ListCustomer);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 2, 3, 2);
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