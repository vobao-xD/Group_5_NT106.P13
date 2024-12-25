namespace Client
{
    partial class TicketInfor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketInfor));
            btnContact = new Button();
            btnTicketSearch = new Button();
            btnSchedule = new Button();
            btnHome = new Button();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            txtLoginName = new TextBox();
            txtTicketCode = new TextBox();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // btnContact
            // 
            btnContact.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnContact.ForeColor = Color.Chocolate;
            btnContact.Location = new Point(916, 151);
            btnContact.Name = "btnContact";
            btnContact.Size = new Size(199, 52);
            btnContact.TabIndex = 15;
            btnContact.Text = "Hỗ trợ";
            btnContact.UseVisualStyleBackColor = true;
            // 
            // btnTicketSearch
            // 
            btnTicketSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTicketSearch.ForeColor = Color.Chocolate;
            btnTicketSearch.Location = new Point(711, 151);
            btnTicketSearch.Name = "btnTicketSearch";
            btnTicketSearch.Size = new Size(199, 52);
            btnTicketSearch.TabIndex = 14;
            btnTicketSearch.Text = "Tra cứu vé";
            btnTicketSearch.UseVisualStyleBackColor = true;
            // 
            // btnSchedule
            // 
            btnSchedule.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSchedule.ForeColor = Color.Chocolate;
            btnSchedule.Location = new Point(506, 151);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(199, 52);
            btnSchedule.TabIndex = 13;
            btnSchedule.Text = "Lịch trình";
            btnSchedule.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            btnHome.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.Chocolate;
            btnHome.Location = new Point(301, 151);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(199, 52);
            btnHome.TabIndex = 12;
            btnHome.Text = "Trang chủ";
            btnHome.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(1252, 96);
            label1.Name = "label1";
            label1.Size = new Size(124, 23);
            label1.TabIndex = 11;
            label1.Text = "Tên đăng nhập";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1203, 85);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 43);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-7, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1441, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(291, 142);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(835, 69);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 16;
            pictureBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(550, 247);
            label2.Name = "label2";
            label2.Size = new Size(330, 31);
            label2.TabIndex = 17;
            label2.Text = "TRA CỨU THÔNG TIN ĐẶT VÉ";
            // 
            // txtLoginName
            // 
            txtLoginName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLoginName.Location = new Point(506, 308);
            txtLoginName.Name = "txtLoginName";
            txtLoginName.Size = new Size(419, 38);
            txtLoginName.TabIndex = 18;
            txtLoginName.Text = "Tên đăng nhập...";
            // 
            // txtTicketCode
            // 
            txtTicketCode.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTicketCode.Location = new Point(506, 375);
            txtTicketCode.Name = "txtTicketCode";
            txtTicketCode.Size = new Size(419, 38);
            txtTicketCode.TabIndex = 19;
            txtTicketCode.Text = "Mã vé...";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Chocolate;
            btnSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.Snow;
            btnSearch.Location = new Point(636, 459);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(137, 49);
            btnSearch.TabIndex = 20;
            btnSearch.Text = "Tra cứu";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // TicketSearch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1430, 599);
            Controls.Add(btnSearch);
            Controls.Add(txtTicketCode);
            Controls.Add(txtLoginName);
            Controls.Add(label2);
            Controls.Add(btnContact);
            Controls.Add(btnTicketSearch);
            Controls.Add(btnSchedule);
            Controls.Add(btnHome);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            Name = "TicketSearch";
            Text = "TicketSearch";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnContact;
        private Button btnTicketSearch;
        private Button btnSchedule;
        private Button btnHome;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private Label label2;
        private TextBox txtLoginName;
        private TextBox txtTicketCode;
        private Button btnSearch;
    }
}