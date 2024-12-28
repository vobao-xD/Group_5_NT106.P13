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
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Chocolate;
            label2.Location = new Point(382, 178);
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
            label3.Location = new Point(382, 285);
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
            cmbBoxDeparture.Location = new Point(382, 204);
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
            cmbBoxDestination.Location = new Point(382, 309);
            cmbBoxDestination.Name = "cmbBoxDestination";
            cmbBoxDestination.Size = new Size(251, 36);
            cmbBoxDestination.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Chocolate;
            label4.Location = new Point(382, 387);
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
            btnSearch.Location = new Point(382, 598);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(251, 50);
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
            DepartDate.Location = new Point(382, 413);
            DepartDate.Name = "DepartDate";
            DepartDate.Size = new Size(251, 34);
            DepartDate.TabIndex = 17;
            // 
            // DepartTime
            // 
            DepartTime.DropDownStyle = ComboBoxStyle.DropDownList;
            DepartTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DepartTime.FormattingEnabled = true;
            DepartTime.Items.AddRange(new object[] { "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00" });
            DepartTime.Location = new Point(382, 511);
            DepartTime.Name = "DepartTime";
            DepartTime.Size = new Size(251, 36);
            DepartTime.TabIndex = 22;
            // 
            // lbDepartTime
            // 
            lbDepartTime.AutoSize = true;
            lbDepartTime.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDepartTime.ForeColor = Color.Chocolate;
            lbDepartTime.Location = new Point(382, 485);
            lbDepartTime.Name = "lbDepartTime";
            lbDepartTime.Size = new Size(59, 23);
            lbDepartTime.TabIndex = 23;
            lbDepartTime.Text = "Giờ đi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Chocolate;
            label5.Location = new Point(351, 83);
            label5.Name = "label5";
            label5.Size = new Size(306, 46);
            label5.TabIndex = 24;
            label5.Text = "Tra cứu chuyến xe";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(982, 703);
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
    }
}