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
            label2 = new Label();
            label3 = new Label();
            cmbBoxDeparture = new ComboBox();
            cmbBoxDestination = new ComboBox();
            label4 = new Label();
            btnSearch = new Button();
            DepartDate = new DateTimePicker();
            DepartTime = new ComboBox();
            lbDepartTime = new Label();
            label5 = new Label();
            btnUpdatePassword = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.System;
            label2.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold);
            label2.ForeColor = Color.Chocolate;
            label2.Location = new Point(399, 219);
            label2.Name = "label2";
            label2.Size = new Size(125, 41);
            label2.TabIndex = 12;
            label2.Text = "Điểm đi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.System;
            label3.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold);
            label3.ForeColor = Color.Chocolate;
            label3.Location = new Point(399, 293);
            label3.Name = "label3";
            label3.Size = new Size(151, 41);
            label3.TabIndex = 13;
            label3.Text = "Điểm đến";
            // 
            // cmbBoxDeparture
            // 
            cmbBoxDeparture.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxDeparture.FlatStyle = FlatStyle.System;
            cmbBoxDeparture.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            cmbBoxDeparture.ForeColor = Color.Chocolate;
            cmbBoxDeparture.FormattingEnabled = true;
            cmbBoxDeparture.Items.AddRange(new object[] { "TP.HCM", "Hà Nội", "Cần Thơ", "Đà Nẵng", "Huế" });
            cmbBoxDeparture.Location = new Point(608, 220);
            cmbBoxDeparture.Margin = new Padding(3, 2, 3, 2);
            cmbBoxDeparture.Name = "cmbBoxDeparture";
            cmbBoxDeparture.Size = new Size(352, 44);
            cmbBoxDeparture.TabIndex = 14;
            // 
            // cmbBoxDestination
            // 
            cmbBoxDestination.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxDestination.FlatStyle = FlatStyle.System;
            cmbBoxDestination.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            cmbBoxDestination.ForeColor = Color.Chocolate;
            cmbBoxDestination.FormattingEnabled = true;
            cmbBoxDestination.Items.AddRange(new object[] { "TP.HCM", "Hà Nội", "Cần Thơ", "Đà Nẵng", "Huế" });
            cmbBoxDestination.Location = new Point(608, 294);
            cmbBoxDestination.Margin = new Padding(3, 2, 3, 2);
            cmbBoxDestination.Name = "cmbBoxDestination";
            cmbBoxDestination.Size = new Size(352, 44);
            cmbBoxDestination.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.System;
            label4.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold);
            label4.ForeColor = Color.Chocolate;
            label4.Location = new Point(399, 368);
            label4.Name = "label4";
            label4.Size = new Size(124, 41);
            label4.TabIndex = 16;
            label4.Text = "Ngày đi";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Chocolate;
            btnSearch.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(522, 490);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(323, 64);
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
            DepartDate.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            DepartDate.Format = DateTimePickerFormat.Custom;
            DepartDate.Location = new Point(608, 368);
            DepartDate.Margin = new Padding(3, 2, 3, 2);
            DepartDate.Name = "DepartDate";
            DepartDate.Size = new Size(352, 43);
            DepartDate.TabIndex = 17;
            // 
            // DepartTime
            // 
            DepartTime.DropDownStyle = ComboBoxStyle.DropDownList;
            DepartTime.FlatStyle = FlatStyle.System;
            DepartTime.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            DepartTime.ForeColor = Color.Chocolate;
            DepartTime.FormattingEnabled = true;
            DepartTime.Items.AddRange(new object[] { "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00" });
            DepartTime.Location = new Point(608, 442);
            DepartTime.Margin = new Padding(3, 2, 3, 2);
            DepartTime.Name = "DepartTime";
            DepartTime.Size = new Size(352, 44);
            DepartTime.TabIndex = 22;
            // 
            // lbDepartTime
            // 
            lbDepartTime.AutoSize = true;
            lbDepartTime.FlatStyle = FlatStyle.System;
            lbDepartTime.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold);
            lbDepartTime.ForeColor = Color.Chocolate;
            lbDepartTime.Location = new Point(399, 442);
            lbDepartTime.Name = "lbDepartTime";
            lbDepartTime.Size = new Size(99, 41);
            lbDepartTime.TabIndex = 23;
            lbDepartTime.Text = "Giờ đi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.System;
            label5.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Chocolate;
            label5.Location = new Point(443, 85);
            label5.Name = "label5";
            label5.Size = new Size(434, 65);
            label5.TabIndex = 24;
            label5.Text = "Tra cứu chuyến xe";
            // 
            // btnUpdatePassword
            // 
            btnUpdatePassword.BackColor = Color.Chocolate;
            btnUpdatePassword.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdatePassword.ForeColor = Color.White;
            btnUpdatePassword.Location = new Point(522, 575);
            btnUpdatePassword.Margin = new Padding(3, 2, 3, 2);
            btnUpdatePassword.Name = "btnUpdatePassword";
            btnUpdatePassword.Size = new Size(323, 64);
            btnUpdatePassword.TabIndex = 25;
            btnUpdatePassword.Text = "Cập nhật mật khẩu";
            btnUpdatePassword.UseVisualStyleBackColor = false;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1358, 662);
            Controls.Add(btnUpdatePassword);
            Controls.Add(label5);
            Controls.Add(lbDepartTime);
            Controls.Add(DepartTime);
            Controls.Add(btnSearch);
            Controls.Add(DepartDate);
            Controls.Add(label4);
            Controls.Add(cmbBoxDestination);
            Controls.Add(cmbBoxDeparture);
            Controls.Add(label3);
            Controls.Add(label2);
            ForeColor = Color.Chocolate;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Home";
            Text = "Home";
            TransparencyKey = Color.PapayaWhip;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private ComboBox cmbBoxDeparture;
        private ComboBox cmbBoxDestination;
        private Label label4;
        private Button btnSearch;
        private DateTimePicker DepartDate;
        private ComboBox DepartTime;
        private Label lbDepartTime;
        private Label label5;
        private Button btnUpdatePassword;
    }
}