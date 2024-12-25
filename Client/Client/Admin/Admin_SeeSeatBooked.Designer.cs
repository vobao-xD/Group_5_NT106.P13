namespace Client.Admin
{
    partial class Admin_SeeSeatBooked
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_SeeSeatBooked));
            pictureBox1 = new PictureBox();
            CheckedBooked = new TabControl();
            HaveBooked = new TabPage();
            flowLayoutPanelBooked = new FlowLayoutPanel();
            HaventBooked = new TabPage();
            flowLayoutPanelNotBook = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            CheckedBooked.SuspendLayout();
            HaveBooked.SuspendLayout();
            HaventBooked.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-320, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1441, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // CheckedBooked
            // 
            CheckedBooked.Controls.Add(HaveBooked);
            CheckedBooked.Controls.Add(HaventBooked);
            CheckedBooked.Location = new Point(12, 82);
            CheckedBooked.Name = "CheckedBooked";
            CheckedBooked.SelectedIndex = 0;
            CheckedBooked.Size = new Size(566, 477);
            CheckedBooked.TabIndex = 5;
            // 
            // HaveBooked
            // 
            HaveBooked.Controls.Add(flowLayoutPanelBooked);
            HaveBooked.Location = new Point(4, 29);
            HaveBooked.Name = "HaveBooked";
            HaveBooked.Padding = new Padding(3);
            HaveBooked.Size = new Size(558, 444);
            HaveBooked.TabIndex = 0;
            HaveBooked.Text = "Ghế đã đặt";
            HaveBooked.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelBooked
            // 
            flowLayoutPanelBooked.AutoScroll = true;
            flowLayoutPanelBooked.Location = new Point(6, 6);
            flowLayoutPanelBooked.Name = "flowLayoutPanelBooked";
            flowLayoutPanelBooked.Size = new Size(546, 432);
            flowLayoutPanelBooked.TabIndex = 0;
            // 
            // HaventBooked
            // 
            HaventBooked.Controls.Add(flowLayoutPanelNotBook);
            HaventBooked.Location = new Point(4, 29);
            HaventBooked.Name = "HaventBooked";
            HaventBooked.Padding = new Padding(3);
            HaventBooked.Size = new Size(558, 444);
            HaventBooked.TabIndex = 1;
            HaventBooked.Text = "Ghế còn trống";
            HaventBooked.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelNotBook
            // 
            flowLayoutPanelNotBook.AutoScroll = true;
            flowLayoutPanelNotBook.Location = new Point(6, 6);
            flowLayoutPanelNotBook.Name = "flowLayoutPanelNotBook";
            flowLayoutPanelNotBook.Size = new Size(546, 432);
            flowLayoutPanelNotBook.TabIndex = 0;
            // 
            // Admin_SeeSeatBooked
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(791, 571);
            Controls.Add(CheckedBooked);
            Controls.Add(pictureBox1);
            Name = "Admin_SeeSeatBooked";
            Text = "Admin_SeeSeatBooked";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            CheckedBooked.ResumeLayout(false);
            HaveBooked.ResumeLayout(false);
            HaventBooked.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private TabControl CheckedBooked;
        private TabPage HaveBooked;
        private TabPage HaventBooked;
        private FlowLayoutPanel flowLayoutPanelBooked;
        private FlowLayoutPanel flowLayoutPanelNotBook;
    }
}