namespace Client
{
    partial class Admin_Add_Trip_Bus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Add_Trip_Bus));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbBoxDeparture = new ComboBox();
            cmbBoxDestination = new ComboBox();
            DepartTime = new ComboBox();
            DepartDate = new DateTimePicker();
            label5 = new Label();
            txtPlate = new TextBox();
            txtSeatNum = new TextBox();
            btnAddTrip = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1103, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(41, 139);
            label1.Name = "label1";
            label1.Size = new Size(69, 23);
            label1.TabIndex = 4;
            label1.Text = "Điểm đi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(377, 139);
            label2.Name = "label2";
            label2.Size = new Size(84, 23);
            label2.TabIndex = 5;
            label2.Text = "Điểm đến";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(41, 252);
            label3.Name = "label3";
            label3.Size = new Size(87, 23);
            label3.TabIndex = 6;
            label3.Text = "Biển số xe";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(377, 252);
            label4.Name = "label4";
            label4.Size = new Size(101, 23);
            label4.TabIndex = 7;
            label4.Text = "Số chỗ ngồi";
            // 
            // cmbBoxDeparture
            // 
            cmbBoxDeparture.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBoxDeparture.FormattingEnabled = true;
            cmbBoxDeparture.Items.AddRange(new object[] { "TP.HCM", "Hà Nội", "Cần Thơ", "Đà Nẵng", "Huế" });
            cmbBoxDeparture.Location = new Point(41, 174);
            cmbBoxDeparture.Name = "cmbBoxDeparture";
            cmbBoxDeparture.Size = new Size(251, 36);
            cmbBoxDeparture.TabIndex = 15;
            cmbBoxDeparture.Text = "Hà Nội";
            // 
            // cmbBoxDestination
            // 
            cmbBoxDestination.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBoxDestination.FormattingEnabled = true;
            cmbBoxDestination.Items.AddRange(new object[] { "TP.HCM", "Hà Nội", "Cần Thơ", "Đà Nẵng", "Huế" });
            cmbBoxDestination.Location = new Point(377, 174);
            cmbBoxDestination.Name = "cmbBoxDestination";
            cmbBoxDestination.Size = new Size(251, 36);
            cmbBoxDestination.TabIndex = 16;
            cmbBoxDestination.Text = "TP.HCM";
            // 
            // DepartTime
            // 
            DepartTime.FormattingEnabled = true;
            DepartTime.Items.AddRange(new object[] { "17:00", "18:00", "19:00", "20:00", "21:00" });
            DepartTime.Location = new Point(806, 181);
            DepartTime.Name = "DepartTime";
            DepartTime.Size = new Size(133, 28);
            DepartTime.TabIndex = 25;
            DepartTime.Text = "17:00";
            // 
            // DepartDate
            // 
            DepartDate.CustomFormat = "yyyy-mm-dd";
            DepartDate.Format = DateTimePickerFormat.Custom;
            DepartDate.Location = new Point(675, 179);
            DepartDate.Name = "DepartDate";
            DepartDate.Size = new Size(111, 27);
            DepartDate.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(675, 139);
            label5.Name = "label5";
            label5.Size = new Size(69, 23);
            label5.TabIndex = 23;
            label5.Text = "Ngày đi";
            // 
            // txtPlate
            // 
            txtPlate.Location = new Point(41, 292);
            txtPlate.Multiline = true;
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(251, 34);
            txtPlate.TabIndex = 26;
            // 
            // txtSeatNum
            // 
            txtSeatNum.Location = new Point(377, 292);
            txtSeatNum.Multiline = true;
            txtSeatNum.Name = "txtSeatNum";
            txtSeatNum.Size = new Size(251, 34);
            txtSeatNum.TabIndex = 27;
            // 
            // btnAddTrip
            // 
            btnAddTrip.BackColor = Color.Chocolate;
            btnAddTrip.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddTrip.ForeColor = Color.White;
            btnAddTrip.Location = new Point(457, 393);
            btnAddTrip.Name = "btnAddTrip";
            btnAddTrip.Size = new Size(207, 50);
            btnAddTrip.TabIndex = 29;
            btnAddTrip.Text = "Thêm";
            btnAddTrip.UseVisualStyleBackColor = false;
            btnAddTrip.Click += btnAddTrip_Click;
            // 
            // Admin_Add_Trip_Bus
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1097, 469);
            Controls.Add(btnAddTrip);
            Controls.Add(txtSeatNum);
            Controls.Add(txtPlate);
            Controls.Add(DepartTime);
            Controls.Add(DepartDate);
            Controls.Add(label5);
            Controls.Add(cmbBoxDestination);
            Controls.Add(cmbBoxDeparture);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Admin_Add_Trip_Bus";
            Text = "Admin_Add_Trip_Bus";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cmbBoxDeparture;
        private ComboBox cmbBoxDestination;
        private ComboBox DepartTime;
        private DateTimePicker DepartDate;
        private Label label5;
        private TextBox txtPlate;
        private TextBox txtSeatNum;
        private Button btnAddTrip;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}