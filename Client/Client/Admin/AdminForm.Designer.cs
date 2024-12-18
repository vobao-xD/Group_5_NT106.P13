
namespace Client
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            pictureBox1 = new PictureBox();
            btnContact = new Button();
            btnAddTrip = new Button();
            btnSchedule = new Button();
            btnHome = new Button();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-186, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1441, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btnContact
            // 
            btnContact.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnContact.Location = new Point(744, 107);
            btnContact.Name = "btnContact";
            btnContact.Size = new Size(199, 52);
            btnContact.TabIndex = 12;
            btnContact.Text = "Đọc hỗ trợ";
            btnContact.UseVisualStyleBackColor = true;
            // 
            // btnAddTrip
            // 
            btnAddTrip.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddTrip.Location = new Point(539, 107);
            btnAddTrip.Name = "btnAddTrip";
            btnAddTrip.Size = new Size(199, 52);
            btnAddTrip.TabIndex = 11;
            btnAddTrip.Text = "Thêm chuyến xe";
            btnAddTrip.UseVisualStyleBackColor = true;
            btnAddTrip.Click += this.btnAddTrip_Click;
            // 
            // btnSchedule
            // 
            btnSchedule.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSchedule.Location = new Point(334, 107);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(199, 52);
            btnSchedule.TabIndex = 10;
            btnSchedule.Text = "Thống kê";
            btnSchedule.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            btnHome.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.Location = new Point(129, 107);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(199, 52);
            btnHome.TabIndex = 9;
            btnHome.Text = "Trang chủ";
            btnHome.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(119, 98);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(835, 69);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 13;
            pictureBox3.TabStop = false;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 548);
            Controls.Add(btnContact);
            Controls.Add(btnAddTrip);
            Controls.Add(btnSchedule);
            Controls.Add(btnHome);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Name = "AdminForm";
            Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnContact;
        private Button btnAddTrip;
        private Button btnSchedule;
        private Button btnHome;
        private PictureBox pictureBox3;
    }
}