namespace Client.Admin
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            flowLayoutPanelBus.Location = new Point(12, 81);
            flowLayoutPanelBus.Name = "flowLayoutPanelBus";
            flowLayoutPanelBus.Size = new Size(530, 488);
            flowLayoutPanelBus.TabIndex = 5;
            // 
            // Admin_BusAnalyse
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 581);
            Controls.Add(flowLayoutPanelBus);
            Controls.Add(pictureBox1);
            Name = "Admin_BusAnalyse";
            Text = "Admin_BusAnalyse";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanelBus;
    }
}