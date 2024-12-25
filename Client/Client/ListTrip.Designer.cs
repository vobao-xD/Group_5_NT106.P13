namespace Client
{
    partial class ListTrip
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
            listView1 = new ListView();
            id = new ColumnHeader();
            name = new ColumnHeader();
            depart = new ColumnHeader();
            arrive = new ColumnHeader();
            time = new ColumnHeader();
            status = new ColumnHeader();
            plate = new ColumnHeader();
            btnReserve = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.CheckBoxes = true;
            listView1.Columns.AddRange(new ColumnHeader[] { id, name, depart, arrive, time, status, plate });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 12);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(1108, 379);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // id
            // 
            id.Text = "Mã Chuyến Đi";
            id.TextAlign = HorizontalAlignment.Center;
            id.Width = 150;
            // 
            // name
            // 
            name.Text = "Tên";
            name.Width = 200;
            // 
            // depart
            // 
            depart.Text = "Điểm Đi";
            depart.Width = 100;
            // 
            // arrive
            // 
            arrive.Text = "Điểm Đến";
            arrive.Width = 100;
            // 
            // time
            // 
            time.Text = "Thời Gian Khởi Hành";
            time.TextAlign = HorizontalAlignment.Center;
            time.Width = 300;
            // 
            // status
            // 
            status.Text = "Trạng Thái";
            status.Width = 100;
            // 
            // plate
            // 
            plate.Text = "Biển Số Xe";
            plate.Width = 150;
            // 
            // btnReserve
            // 
            btnReserve.Enabled = false;
            btnReserve.Location = new Point(973, 409);
            btnReserve.Name = "btnReserve";
            btnReserve.Size = new Size(147, 29);
            btnReserve.TabIndex = 1;
            btnReserve.Text = "Đặt vé";
            btnReserve.UseVisualStyleBackColor = true;
            btnReserve.Click += btnReserve_Click;
            // 
            // ListTrip
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 450);
            Controls.Add(btnReserve);
            Controls.Add(listView1);
            Name = "ListTrip";
            Text = "ListTrip";
            Load += ListTrip_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader name;
        private ColumnHeader depart;
        private ColumnHeader arrive;
        private ColumnHeader time;
        private ColumnHeader status;
        private ColumnHeader plate;
        private ColumnHeader id;
        private Button btnReserve;
    }
}