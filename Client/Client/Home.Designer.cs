namespace Client
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            btnHome = new Button();
            btnSchedule = new Button();
            btnTicketSearch = new Button();
            btnContact = new Button();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            cmbBoxDeparture = new ComboBox();
            cmbBoxDestination = new ComboBox();
            label4 = new Label();
            btnSearch = new Button();
            DepartDate = new DateTimePicker();
            DepartTime = new ComboBox();
            statusStrip1 = new StatusStrip();
            labelUsername = new ToolStripStatusLabel();
            labelUserEmail = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1441, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1211, 82);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 43);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Small Light", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Sienna;
            label1.Location = new Point(1260, 93);
            label1.Name = "label1";
            label1.Size = new Size(124, 22);
            label1.TabIndex = 3;
            label1.Text = "Tên đăng nhập";
            // 
            // btnHome
            // 
            btnHome.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.Location = new Point(309, 148);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(199, 52);
            btnHome.TabIndex = 4;
            btnHome.Text = "Trang chủ";
            btnHome.UseVisualStyleBackColor = true;
            // 
            // btnSchedule
            // 
            btnSchedule.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSchedule.Location = new Point(514, 148);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(199, 52);
            btnSchedule.TabIndex = 5;
            btnSchedule.Text = "Lịch trình";
            btnSchedule.UseVisualStyleBackColor = true;
            // 
            // btnTicketSearch
            // 
            btnTicketSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTicketSearch.Location = new Point(719, 148);
            btnTicketSearch.Name = "btnTicketSearch";
            btnTicketSearch.Size = new Size(199, 52);
            btnTicketSearch.TabIndex = 6;
            btnTicketSearch.Text = "Tra cứu vé";
            btnTicketSearch.UseVisualStyleBackColor = true;
            // 
            // btnContact
            // 
            btnContact.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnContact.Location = new Point(924, 148);
            btnContact.Name = "btnContact";
            btnContact.Size = new Size(199, 52);
            btnContact.TabIndex = 7;
            btnContact.Text = "Hỗ trợ";
            btnContact.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(299, 139);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(835, 69);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(147, 223);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(1117, 268);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Chocolate;
            label2.Location = new Point(237, 316);
            label2.Name = "label2";
            label2.Size = new Size(74, 23);
            label2.TabIndex = 12;
            label2.Text = "Điểm đi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Chocolate;
            label3.Location = new Point(533, 316);
            label3.Name = "label3";
            label3.Size = new Size(88, 23);
            label3.TabIndex = 13;
            label3.Text = "Điểm đến";
            // 
            // cmbBoxDeparture
            // 
            cmbBoxDeparture.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxDeparture.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbBoxDeparture.ForeColor = Color.Chocolate;
            cmbBoxDeparture.FormattingEnabled = true;
            cmbBoxDeparture.Items.AddRange(new object[] { "TP.HCM", "Hà Nội", "Cần Thơ", "Đà Nẵng", "Huế" });
            cmbBoxDeparture.Location = new Point(237, 342);
            cmbBoxDeparture.Name = "cmbBoxDeparture";
            cmbBoxDeparture.Size = new Size(251, 36);
            cmbBoxDeparture.TabIndex = 14;
            // 
            // cmbBoxDestination
            // 
            cmbBoxDestination.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxDestination.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbBoxDestination.ForeColor = Color.Chocolate;
            cmbBoxDestination.FormattingEnabled = true;
            cmbBoxDestination.Items.AddRange(new object[] { "TP.HCM", "Hà Nội", "Cần Thơ", "Đà Nẵng", "Huế" });
            cmbBoxDestination.Location = new Point(533, 340);
            cmbBoxDestination.Name = "cmbBoxDestination";
            cmbBoxDestination.Size = new Size(251, 36);
            cmbBoxDestination.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Chocolate;
            label4.Location = new Point(900, 316);
            label4.Name = "label4";
            label4.Size = new Size(73, 23);
            label4.TabIndex = 16;
            label4.Text = "Ngày đi";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Chocolate;
            btnSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(612, 425);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(207, 50);
            btnSearch.TabIndex = 18;
            btnSearch.Text = "Tìm chuyến xe";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // DepartDate
            // 
            DepartDate.CalendarForeColor = Color.Chocolate;
            DepartDate.CalendarTitleBackColor = Color.PeachPuff;
            DepartDate.CalendarTitleForeColor = Color.Chocolate;
            DepartDate.CalendarTrailingForeColor = Color.Peru;
            DepartDate.CustomFormat = "dd-MM-yyyy";
            DepartDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DepartDate.Format = DateTimePickerFormat.Custom;
            DepartDate.Location = new Point(900, 342);
            DepartDate.Name = "DepartDate";
            DepartDate.Size = new Size(139, 34);
            DepartDate.TabIndex = 17;
            // 
            // DepartTime
            // 
            DepartTime.DropDownStyle = ComboBoxStyle.DropDownList;
            DepartTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DepartTime.FormattingEnabled = true;
            DepartTime.Items.AddRange(new object[] { "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00" });
            DepartTime.Location = new Point(1060, 342);
            DepartTime.Name = "DepartTime";
            DepartTime.Size = new Size(133, 36);
            DepartTime.TabIndex = 22;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { labelUsername, labelUserEmail });
            statusStrip1.Location = new Point(0, 697);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1440, 26);
            statusStrip1.TabIndex = 23;
            statusStrip1.Text = "statusStrip1";
            // 
            // labelUsername
            // 
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(108, 20);
            labelUsername.Text = "labelUsername";
            // 
            // labelUserEmail
            // 
            labelUserEmail.Name = "labelUserEmail";
            labelUserEmail.Size = new Size(108, 20);
            labelUserEmail.Text = "labelUserEmail";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1440, 723);
            Controls.Add(statusStrip1);
            Controls.Add(DepartTime);
            Controls.Add(btnSearch);
            Controls.Add(DepartDate);
            Controls.Add(label4);
            Controls.Add(cmbBoxDestination);
            Controls.Add(cmbBoxDeparture);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox4);
            Controls.Add(btnContact);
            Controls.Add(btnTicketSearch);
            Controls.Add(btnSchedule);
            Controls.Add(btnHome);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            ForeColor = Color.Chocolate;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Home";
            Text = "Home";
            TransparencyKey = Color.PapayaWhip;
            Load += Home_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Button btnHome;
        private Button btnSchedule;
        private Button btnTicketSearch;
        private Button btnContact;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label label2;
        private Label label3;
        private ComboBox cmbBoxDeparture;
        private ComboBox cmbBoxDestination;
        private Label label4;
        private Button btnSearch;
        private DateTimePicker DepartDate;
        private ComboBox DepartTime;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labelUsername;
        private ToolStripStatusLabel labelUserEmail;
    }
}