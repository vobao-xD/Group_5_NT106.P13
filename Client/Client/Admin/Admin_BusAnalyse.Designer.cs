namespace Client
{
    partial class Admin_BusAnalyse
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
            flowLayoutPanelBus = new FlowLayoutPanel();
            tabControl1 = new TabControl();
            tabPage_ListofBus = new TabPage();
            List_of_trip = new TabPage();
            flowLayoutPanelTrip = new FlowLayoutPanel();
            label5 = new Label();
            tabControl1.SuspendLayout();
            tabPage_ListofBus.SuspendLayout();
            List_of_trip.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelBus
            // 
            flowLayoutPanelBus.AutoScroll = true;
            flowLayoutPanelBus.Location = new Point(6, 6);
            flowLayoutPanelBus.Name = "flowLayoutPanelBus";
            flowLayoutPanelBus.Size = new Size(623, 510);
            flowLayoutPanelBus.TabIndex = 5;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage_ListofBus);
            tabControl1.Controls.Add(List_of_trip);
            tabControl1.Location = new Point(447, 213);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(640, 555);
            tabControl1.TabIndex = 6;
            // 
            // tabPage_ListofBus
            // 
            tabPage_ListofBus.Controls.Add(flowLayoutPanelBus);
            tabPage_ListofBus.Location = new Point(4, 29);
            tabPage_ListofBus.Name = "tabPage_ListofBus";
            tabPage_ListofBus.Padding = new Padding(3);
            tabPage_ListofBus.Size = new Size(632, 522);
            tabPage_ListofBus.TabIndex = 0;
            tabPage_ListofBus.Text = "List_of_Bus";
            tabPage_ListofBus.UseVisualStyleBackColor = true;
            // 
            // List_of_trip
            // 
            List_of_trip.Controls.Add(flowLayoutPanelTrip);
            List_of_trip.Location = new Point(4, 29);
            List_of_trip.Name = "List_of_trip";
            List_of_trip.Padding = new Padding(3);
            List_of_trip.Size = new Size(632, 522);
            List_of_trip.TabIndex = 1;
            List_of_trip.Text = "List_of_Trip";
            List_of_trip.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelTrip
            // 
            flowLayoutPanelTrip.AutoScroll = true;
            flowLayoutPanelTrip.Location = new Point(6, 6);
            flowLayoutPanelTrip.Name = "flowLayoutPanelTrip";
            flowLayoutPanelTrip.Size = new Size(623, 510);
            flowLayoutPanelTrip.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.System;
            label5.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Chocolate;
            label5.Location = new Point(447, 75);
            label5.Name = "label5";
            label5.Size = new Size(670, 81);
            label5.TabIndex = 25;
            label5.Text = "Quản lý xe - Chuyến đi";
            // 
            // Admin_BusAnalyse
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1534, 835);
            Controls.Add(label5);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Admin_BusAnalyse";
            Text = "Admin_BusAnalyse";
            tabControl1.ResumeLayout(false);
            tabPage_ListofBus.ResumeLayout(false);
            List_of_trip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanelBus;
        private TabControl tabControl1;
        private TabPage tabPage_ListofBus;
        private TabPage List_of_trip;
        private FlowLayoutPanel flowLayoutPanelTrip;
        private Label label5;
    }
}