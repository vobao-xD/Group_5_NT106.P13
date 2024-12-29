namespace Client
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
            ListCustomer = new TabControl();
            tabRegularCustomer = new TabPage();
            flowLayoutPanelRegular = new FlowLayoutPanel();
            VIPCustomer = new TabPage();
            flowLayoutPanelVIP = new FlowLayoutPanel();
            label5 = new Label();
            ListCustomer.SuspendLayout();
            tabRegularCustomer.SuspendLayout();
            VIPCustomer.SuspendLayout();
            SuspendLayout();
            // 
            // ListCustomer
            // 
            ListCustomer.Controls.Add(tabRegularCustomer);
            ListCustomer.Controls.Add(VIPCustomer);
            ListCustomer.Location = new Point(514, 197);
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
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.System;
            label5.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Chocolate;
            label5.Location = new Point(514, 73);
            label5.Name = "label5";
            label5.Size = new Size(592, 81);
            label5.TabIndex = 26;
            label5.Text = "Quản lý khách hàng";
            // 
            // Admin_ListCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1534, 835);
            Controls.Add(label5);
            Controls.Add(ListCustomer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Admin_ListCustomer";
            Text = "Admin_ListCustomer";
            ListCustomer.ResumeLayout(false);
            tabRegularCustomer.ResumeLayout(false);
            VIPCustomer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl ListCustomer;
        private TabPage tabRegularCustomer;
        private TabPage VIPCustomer;
        private FlowLayoutPanel flowLayoutPanelRegular;
        private FlowLayoutPanel flowLayoutPanelVIP;
        private Label label5;
    }
}