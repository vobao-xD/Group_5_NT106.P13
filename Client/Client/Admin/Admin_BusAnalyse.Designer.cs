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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_BusAnalyse));
            pictureBox1 = new PictureBox();
            flowLayoutPanelBus = new FlowLayoutPanel();
            tabControl1 = new TabControl();
            tabPage_ListofBus = new TabPage();
            List_of_trip = new TabPage();
            flowLayoutPanelTrip = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage_ListofBus.SuspendLayout();
            List_of_trip.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-401, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1441, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanelBus
            // 
            flowLayoutPanelBus.Location = new Point(6, 6);
            flowLayoutPanelBus.Name = "flowLayoutPanelBus";
            flowLayoutPanelBus.Size = new Size(529, 443);
            flowLayoutPanelBus.TabIndex = 5;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage_ListofBus);
            tabControl1.Controls.Add(List_of_trip);
            tabControl1.Location = new Point(12, 81);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(533, 488);
            tabControl1.TabIndex = 6;
            // 
            // tabPage_ListofBus
            // 
            tabPage_ListofBus.Controls.Add(flowLayoutPanelBus);
            tabPage_ListofBus.Location = new Point(4, 29);
            tabPage_ListofBus.Name = "tabPage_ListofBus";
            tabPage_ListofBus.Padding = new Padding(3);
            tabPage_ListofBus.Size = new Size(590, 455);
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
            List_of_trip.Size = new Size(525, 455);
            List_of_trip.TabIndex = 1;
            List_of_trip.Text = "List_of_Trip";
            List_of_trip.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelTrip
            // 
            flowLayoutPanelTrip.AutoScroll = true;
            flowLayoutPanelTrip.Location = new Point(6, 6);
            flowLayoutPanelTrip.Name = "flowLayoutPanelTrip";
            flowLayoutPanelTrip.Size = new Size(511, 443);
            flowLayoutPanelTrip.TabIndex = 0;
            // 
            // Admin_BusAnalyse
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 581);
            Controls.Add(tabControl1);
            Controls.Add(pictureBox1);
            Name = "Admin_BusAnalyse";
            Text = "Admin_BusAnalyse";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage_ListofBus.ResumeLayout(false);
            List_of_trip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanelBus;
        private TabControl tabControl1;
        private TabPage tabPage_ListofBus;
        private TabPage List_of_trip;
        private FlowLayoutPanel flowLayoutPanelTrip;
    }
}