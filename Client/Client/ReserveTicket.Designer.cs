namespace Client
{
    partial class ReserveTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReserveTicket));
            pictureBox4 = new PictureBox();
            checkedListBox1 = new CheckedListBox();
            label1 = new Label();
            btnPay = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.White;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(497, 157);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(547, 634);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            // 
            // checkedListBox1
            // 
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.ColumnWidth = 60;
            checkedListBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkedListBox1.ForeColor = Color.Chocolate;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(629, 239);
            checkedListBox1.MultiColumn = true;
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(294, 384);
            checkedListBox1.TabIndex = 14;
            checkedListBox1.ThreeDCheckBoxes = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Chocolate;
            label1.Location = new Point(497, 43);
            label1.Name = "label1";
            label1.Size = new Size(547, 81);
            label1.TabIndex = 15;
            label1.Text = "Vui lòng chọn ghế";
            // 
            // btnPay
            // 
            btnPay.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPay.ForeColor = Color.Chocolate;
            btnPay.Location = new Point(542, 662);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(457, 75);
            btnPay.TabIndex = 16;
            btnPay.Text = "Thanh toán";
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // ReserveTicket
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1534, 835);
            Controls.Add(btnPay);
            Controls.Add(label1);
            Controls.Add(checkedListBox1);
            Controls.Add(pictureBox4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReserveTicket";
            Text = "ReserveTicket";
            Load += ReserveTicket_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox4;
        private CheckedListBox checkedListBox1;
        private Label label1;
        private Button btnPay;
    }
}