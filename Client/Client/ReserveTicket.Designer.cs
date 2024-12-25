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
            pictureBox1 = new PictureBox();
            pictureBox4 = new PictureBox();
            checkedListBox1 = new CheckedListBox();
            label1 = new Label();
            btnPay = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-221, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(863, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.White;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(6, 84);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(403, 273);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            // 
            // checkedListBox1
            // 
            checkedListBox1.ColumnWidth = 60;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(110, 119);
            checkedListBox1.MultiColumn = true;
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(184, 224);
            checkedListBox1.TabIndex = 14;
            checkedListBox1.ThreeDCheckBoxes = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 84);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 15;
            label1.Text = "Chọn ghế";
            // 
            // btnPay
            // 
            btnPay.Location = new Point(153, 363);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(94, 29);
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
            ClientSize = new Size(421, 403);
            Controls.Add(btnPay);
            Controls.Add(label1);
            Controls.Add(checkedListBox1);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox1);
            Name = "ReserveTicket";
            Text = "ReserveTicket";
            Load += ReserveTicket_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
        private CheckedListBox checkedListBox1;
        private Label label1;
        private Button btnPay;
    }
}