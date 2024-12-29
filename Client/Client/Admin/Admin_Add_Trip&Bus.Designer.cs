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
            cmbBoxDeparture = new ComboBox();
            cmbBoxDestination = new ComboBox();
            DepartTime = new ComboBox();
            DepartDate = new DateTimePicker();
            txtPlate = new TextBox();
            txtSeatNum = new TextBox();
            btnAddTrip = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            lbDepartTime = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // cmbBoxDeparture
            // 
            cmbBoxDeparture.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxDeparture.Font = new Font("Microsoft Sans Serif", 16.2F);
            cmbBoxDeparture.FormattingEnabled = true;
            cmbBoxDeparture.Items.AddRange(new object[] { "TP.HCM", "Hà Nội", "Cần Thơ", "Đà Nẵng", "Huế" });
            cmbBoxDeparture.Location = new Point(723, 175);
            cmbBoxDeparture.Name = "cmbBoxDeparture";
            cmbBoxDeparture.Size = new Size(389, 39);
            cmbBoxDeparture.TabIndex = 15;
            // 
            // cmbBoxDestination
            // 
            cmbBoxDestination.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxDestination.Font = new Font("Microsoft Sans Serif", 16.2F);
            cmbBoxDestination.FormattingEnabled = true;
            cmbBoxDestination.Items.AddRange(new object[] { "TP.HCM", "Hà Nội", "Cần Thơ", "Đà Nẵng", "Huế" });
            cmbBoxDestination.Location = new Point(723, 261);
            cmbBoxDestination.Name = "cmbBoxDestination";
            cmbBoxDestination.Size = new Size(389, 39);
            cmbBoxDestination.TabIndex = 16;
            // 
            // DepartTime
            // 
            DepartTime.DropDownStyle = ComboBoxStyle.DropDownList;
            DepartTime.Font = new Font("Microsoft Sans Serif", 16.2F);
            DepartTime.FormattingEnabled = true;
            DepartTime.Items.AddRange(new object[] { "17:00", "18:00", "19:00", "20:00", "21:00" });
            DepartTime.Location = new Point(723, 442);
            DepartTime.Name = "DepartTime";
            DepartTime.Size = new Size(389, 39);
            DepartTime.TabIndex = 25;
            // 
            // DepartDate
            // 
            DepartDate.CustomFormat = "yyyy-MM-dd";
            DepartDate.Font = new Font("Microsoft Sans Serif", 16.2F);
            DepartDate.Format = DateTimePickerFormat.Custom;
            DepartDate.Location = new Point(723, 352);
            DepartDate.Name = "DepartDate";
            DepartDate.Size = new Size(389, 38);
            DepartDate.TabIndex = 24;
            // 
            // txtPlate
            // 
            txtPlate.Font = new Font("Microsoft Sans Serif", 16.2F);
            txtPlate.Location = new Point(723, 522);
            txtPlate.Multiline = true;
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(389, 50);
            txtPlate.TabIndex = 26;
            // 
            // txtSeatNum
            // 
            txtSeatNum.Font = new Font("Microsoft Sans Serif", 16.2F);
            txtSeatNum.Location = new Point(723, 621);
            txtSeatNum.Multiline = true;
            txtSeatNum.Name = "txtSeatNum";
            txtSeatNum.Size = new Size(389, 50);
            txtSeatNum.TabIndex = 27;
            // 
            // btnAddTrip
            // 
            btnAddTrip.BackColor = Color.Chocolate;
            btnAddTrip.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddTrip.ForeColor = Color.White;
            btnAddTrip.Location = new Point(1252, 352);
            btnAddTrip.Name = "btnAddTrip";
            btnAddTrip.Size = new Size(157, 129);
            btnAddTrip.TabIndex = 29;
            btnAddTrip.Text = "Thêm";
            btnAddTrip.UseVisualStyleBackColor = false;
            btnAddTrip.Click += btnAddTrip_Click;
            // 
            // lbDepartTime
            // 
            lbDepartTime.AutoSize = true;
            lbDepartTime.FlatStyle = FlatStyle.System;
            lbDepartTime.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold);
            lbDepartTime.ForeColor = Color.Chocolate;
            lbDepartTime.Location = new Point(538, 431);
            lbDepartTime.Name = "lbDepartTime";
            lbDepartTime.Size = new Size(124, 50);
            lbDepartTime.TabIndex = 33;
            lbDepartTime.Text = "Giờ đi";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.FlatStyle = FlatStyle.System;
            label6.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold);
            label6.ForeColor = Color.Chocolate;
            label6.Location = new Point(509, 344);
            label6.Name = "label6";
            label6.Size = new Size(153, 50);
            label6.TabIndex = 32;
            label6.Text = "Ngày đi";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.FlatStyle = FlatStyle.System;
            label7.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold);
            label7.ForeColor = Color.Chocolate;
            label7.Location = new Point(475, 250);
            label7.Name = "label7";
            label7.Size = new Size(187, 50);
            label7.TabIndex = 31;
            label7.Text = "Điểm đến";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.FlatStyle = FlatStyle.System;
            label8.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold);
            label8.ForeColor = Color.Chocolate;
            label8.Location = new Point(507, 164);
            label8.Name = "label8";
            label8.Size = new Size(155, 50);
            label8.TabIndex = 30;
            label8.Text = "Điểm đi";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.FlatStyle = FlatStyle.System;
            label9.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Chocolate;
            label9.Location = new Point(568, 38);
            label9.Name = "label9";
            label9.Size = new Size(492, 81);
            label9.TabIndex = 34;
            label9.Text = "Thêm chuyến xe";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.FlatStyle = FlatStyle.System;
            label10.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold);
            label10.ForeColor = Color.Chocolate;
            label10.Location = new Point(469, 522);
            label10.Name = "label10";
            label10.Size = new Size(193, 50);
            label10.TabIndex = 35;
            label10.Text = "Biển số xe";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.System;
            label1.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold);
            label1.ForeColor = Color.Chocolate;
            label1.Location = new Point(441, 621);
            label1.Name = "label1";
            label1.Size = new Size(221, 50);
            label1.TabIndex = 36;
            label1.Text = "Số chỗ ngồi";
            // 
            // Admin_Add_Trip_Bus
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1552, 882);
            Controls.Add(label1);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(lbDepartTime);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(btnAddTrip);
            Controls.Add(txtSeatNum);
            Controls.Add(txtPlate);
            Controls.Add(DepartTime);
            Controls.Add(DepartDate);
            Controls.Add(cmbBoxDestination);
            Controls.Add(cmbBoxDeparture);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Admin_Add_Trip_Bus";
            Text = "Admin_Add_Trip_Bus";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbBoxDeparture;
        private ComboBox cmbBoxDestination;
        private ComboBox DepartTime;
        private DateTimePicker DepartDate;
        private TextBox txtPlate;
        private TextBox txtSeatNum;
        private Button btnAddTrip;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label lbDepartTime;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label1;
    }
}