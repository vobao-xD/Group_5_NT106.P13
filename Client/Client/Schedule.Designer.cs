namespace Client
{
    partial class Schedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schedule));
            btnContact = new Button();
            btnTicketSearch = new Button();
            btnSchedule = new Button();
            btnHome = new Button();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            btnSearch = new Button();
            cmbBoxDestination = new ComboBox();
            cmbBoxDeparture = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            flowLayoutPanel_Trips = new FlowLayoutPanel();
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
            // btnSearch
            // 
            btnSearch.BackColor = Color.Chocolate;
            btnSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(919, 257);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(207, 50);
            btnSearch.TabIndex = 23;
            btnSearch.Text = "Tìm chuyến xe";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbBoxDestination
            // 
            cmbBoxDestination.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBoxDestination.FormattingEnabled = true;
            cmbBoxDestination.Items.AddRange(new object[] { "TP.HCM", "Hà Nội", "Cần Thơ", "Đà Nẵng", "Huế" });
            cmbBoxDestination.Location = new Point(611, 266);
            cmbBoxDestination.Name = "cmbBoxDestination";
            cmbBoxDestination.Size = new Size(251, 36);
            cmbBoxDestination.TabIndex = 22;
            // 
            // cmbBoxDeparture
            // 
            cmbBoxDeparture.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBoxDeparture.FormattingEnabled = true;
            cmbBoxDeparture.Items.AddRange(new object[] { "TP.HCM", "Hà Nội", "Cần Thơ", "Đà Nẵng", "Huế" });
            cmbBoxDeparture.Location = new Point(291, 266);
            cmbBoxDeparture.Name = "cmbBoxDeparture";
            cmbBoxDeparture.Size = new Size(251, 36);
            cmbBoxDeparture.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(611, 243);
            label3.Name = "label3";
            label3.Size = new Size(84, 23);
            label3.TabIndex = 20;
            label3.Text = "Điểm đến";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(291, 243);
            label4.Name = "label4";
            label4.Size = new Size(69, 23);
            label4.TabIndex = 19;
            label4.Text = "Điểm đi";
            // 
            // flowLayoutPanel_Trips
            // 
            flowLayoutPanel_Trips.Location = new Point(291, 359);
            flowLayoutPanel_Trips.Name = "flowLayoutPanel_Trips";
            flowLayoutPanel_Trips.Size = new Size(824, 506);
            flowLayoutPanel_Trips.TabIndex = 24;
            // 
            // Schedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1433, 903);
            Controls.Add(flowLayoutPanel_Trips);
            Controls.Add(btnSearch);
            Controls.Add(cmbBoxDestination);
            Controls.Add(cmbBoxDeparture);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(btnContact);
            Controls.Add(btnTicketSearch);
            Controls.Add(btnSchedule);
            Controls.Add(btnHome);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            Name = "Schedule";
            Text = "Schedule";
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
        private Button btnSearch;
        private ComboBox cmbBoxDestination;
        private ComboBox cmbBoxDeparture;
        private Label label3;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel_Trips;
    }
}