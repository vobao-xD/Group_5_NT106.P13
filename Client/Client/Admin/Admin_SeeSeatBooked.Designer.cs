namespace Client
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
            CheckedBooked = new TabControl();
            HaveBooked = new TabPage();
            flowLayoutPanelBooked = new FlowLayoutPanel();
            HaventBooked = new TabPage();
            flowLayoutPanelNotBook = new FlowLayoutPanel();
            label5 = new Label();
            CheckedBooked.SuspendLayout();
            HaveBooked.SuspendLayout();
            HaventBooked.SuspendLayout();
            SuspendLayout();
            // 
            // CheckedBooked
            // 
            CheckedBooked.Controls.Add(HaveBooked);
            CheckedBooked.Controls.Add(HaventBooked);
            CheckedBooked.Location = new Point(12, 103);
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
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.System;
            label5.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Chocolate;
            label5.Location = new Point(160, 23);
            label5.Name = "label5";
            label5.Size = new Size(285, 62);
            label5.TabIndex = 25;
            label5.Text = "Tra cứu ghế";
            // 
            // Admin_SeeSeatBooked
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 586);
            Controls.Add(label5);
            Controls.Add(CheckedBooked);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Admin_SeeSeatBooked";
            Text = "Admin_SeeSeatBooked";
            CheckedBooked.ResumeLayout(false);
            HaveBooked.ResumeLayout(false);
            HaventBooked.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl CheckedBooked;
        private TabPage HaveBooked;
        private TabPage HaventBooked;
        private FlowLayoutPanel flowLayoutPanelBooked;
        private FlowLayoutPanel flowLayoutPanelNotBook;
        private Label label5;
    }
}