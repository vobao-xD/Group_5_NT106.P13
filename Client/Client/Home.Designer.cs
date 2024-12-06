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
            chkboxRoundtrip = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            cmbBoxDeparture = new ComboBox();
            cmbBoxDestination = new ComboBox();
            label4 = new Label();
            ReturnDate = new DateTimePicker();
            btnSearch = new Button();
            label5 = new Label();
            NumOfTicket = new DomainUpDown();
            label6 = new Label();
            DepartDate = new DateTimePicker();
            ReturnTime = new ComboBox();
            DepartTime = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
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
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(1260, 93);
            label1.Name = "label1";
            label1.Size = new Size(124, 23);
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
            // chkboxRoundtrip
            // 
            chkboxRoundtrip.AutoSize = true;
            chkboxRoundtrip.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkboxRoundtrip.ForeColor = Color.Black;
            chkboxRoundtrip.Location = new Point(237, 268);
            chkboxRoundtrip.Name = "chkboxRoundtrip";
            chkboxRoundtrip.Size = new Size(102, 32);
            chkboxRoundtrip.TabIndex = 11;
            chkboxRoundtrip.Text = "Khứ hồi";
            chkboxRoundtrip.UseVisualStyleBackColor = true;
            chkboxRoundtrip.CheckedChanged += chkboxRoundtrip_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(237, 316);
            label2.Name = "label2";
            label2.Size = new Size(69, 23);
            label2.TabIndex = 12;
            label2.Text = "Điểm đi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(494, 316);
            label3.Name = "label3";
            label3.Size = new Size(84, 23);
            label3.TabIndex = 13;
            label3.Text = "Điểm đến";
            // 
            // cmbBoxDeparture
            // 
            cmbBoxDeparture.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBoxDeparture.FormattingEnabled = true;
            cmbBoxDeparture.Items.AddRange(new object[] { "TP.HCM", "Hà Nội", "Cần Thơ", "Đà Nẵng", "Huế" });
            cmbBoxDeparture.Location = new Point(237, 342);
            cmbBoxDeparture.Name = "cmbBoxDeparture";
            cmbBoxDeparture.Size = new Size(251, 36);
            cmbBoxDeparture.TabIndex = 14;
            // 
            // cmbBoxDestination
            // 
            cmbBoxDestination.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBoxDestination.FormattingEnabled = true;
            cmbBoxDestination.Items.AddRange(new object[] { "TP.HCM", "Hà Nội", "Cần Thơ", "Đà Nẵng", "Huế" });
            cmbBoxDestination.Location = new Point(494, 342);
            cmbBoxDestination.Name = "cmbBoxDestination";
            cmbBoxDestination.Size = new Size(251, 36);
            cmbBoxDestination.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(779, 277);
            label4.Name = "label4";
            label4.Size = new Size(69, 23);
            label4.TabIndex = 16;
            label4.Text = "Ngày đi";
            // 
            // ReturnDate
            // 
            ReturnDate.CustomFormat = "yyyy-mm-dd";
            ReturnDate.Enabled = false;
            ReturnDate.Format = DateTimePickerFormat.Custom;
            ReturnDate.Location = new Point(779, 381);
            ReturnDate.Name = "ReturnDate";
            ReturnDate.Size = new Size(111, 27);
            ReturnDate.TabIndex = 17;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Chocolate;
            btnSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(623, 424);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(207, 50);
            btnSearch.TabIndex = 18;
            btnSearch.Text = "Tìm chuyến xe";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(1053, 316);
            label5.Name = "label5";
            label5.Size = new Size(51, 23);
            label5.TabIndex = 19;
            label5.Text = "Số vé";
            // 
            // NumOfTicket
            // 
            NumOfTicket.Items.Add("1");
            NumOfTicket.Items.Add("2");
            NumOfTicket.Items.Add("3");
            NumOfTicket.Items.Add("4");
            NumOfTicket.Items.Add("5");
            NumOfTicket.Items.Add("6");
            NumOfTicket.Items.Add("7");
            NumOfTicket.Items.Add("8");
            NumOfTicket.Items.Add("9");
            NumOfTicket.Items.Add("10");
            NumOfTicket.Items.Add("11");
            NumOfTicket.Items.Add("12");
            NumOfTicket.Items.Add("13");
            NumOfTicket.Items.Add("14");
            NumOfTicket.Items.Add("15");
            NumOfTicket.Items.Add("16");
            NumOfTicket.Items.Add("17");
            NumOfTicket.Items.Add("18");
            NumOfTicket.Items.Add("19");
            NumOfTicket.Items.Add("20");
            NumOfTicket.Location = new Point(1053, 350);
            NumOfTicket.Name = "NumOfTicket";
            NumOfTicket.Size = new Size(150, 27);
            NumOfTicket.TabIndex = 20;
            NumOfTicket.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(779, 355);
            label6.Name = "label6";
            label6.Size = new Size(72, 23);
            label6.TabIndex = 16;
            label6.Text = "Ngày về";
            // 
            // DepartDate
            // 
            DepartDate.CustomFormat = "yyyy-mm-dd";
            DepartDate.Format = DateTimePickerFormat.Custom;
            DepartDate.Location = new Point(779, 303);
            DepartDate.Name = "DepartDate";
            DepartDate.Size = new Size(111, 27);
            DepartDate.TabIndex = 17;
            // 
            // ReturnTime
            // 
            ReturnTime.Enabled = false;
            ReturnTime.FormattingEnabled = true;
            ReturnTime.Items.AddRange(new object[] { "17:00", "18:00", "19:00", "20:00", "21:00" });
            ReturnTime.Location = new Point(896, 380);
            ReturnTime.Name = "ReturnTime";
            ReturnTime.Size = new Size(133, 28);
            ReturnTime.TabIndex = 21;
            // 
            // DepartTime
            // 
            DepartTime.FormattingEnabled = true;
            DepartTime.Items.AddRange(new object[] { "17:00", "18:00", "19:00", "20:00", "21:00" });
            DepartTime.Location = new Point(896, 302);
            DepartTime.Name = "DepartTime";
            DepartTime.Size = new Size(133, 28);
            DepartTime.TabIndex = 22;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1440, 723);
            Controls.Add(DepartTime);
            Controls.Add(ReturnTime);
            Controls.Add(NumOfTicket);
            Controls.Add(label5);
            Controls.Add(btnSearch);
            Controls.Add(DepartDate);
            Controls.Add(ReturnDate);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(cmbBoxDestination);
            Controls.Add(cmbBoxDeparture);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(chkboxRoundtrip);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
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
        private CheckBox chkboxRoundtrip;
        private Label label2;
        private Label label3;
        private ComboBox cmbBoxDeparture;
        private ComboBox cmbBoxDestination;
        private Label label4;
        private DateTimePicker ReturnDate;
        private Button btnSearch;
        private Label label5;
        private DomainUpDown NumOfTicket;
        private Label label6;
        private DateTimePicker DepartDate;
        private ComboBox ReturnTime;
        private ComboBox DepartTime;
    }
}