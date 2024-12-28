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
            label2 = new Label();
            txtLoginName = new TextBox();
            txtTicketCode = new TextBox();
            btnSearch = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Chocolate;
            label2.Location = new Point(248, 66);
            label2.Name = "label2";
            label2.Size = new Size(495, 46);
            label2.TabIndex = 17;
            label2.Text = "TRA CỨU THÔNG TIN ĐẶT VÉ";
            // 
            // txtLoginName
            // 
            txtLoginName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLoginName.ForeColor = Color.Chocolate;
            txtLoginName.Location = new Point(337, 184);
            txtLoginName.Name = "txtLoginName";
            txtLoginName.PlaceholderText = "Tên đăng nhập...";
            txtLoginName.Size = new Size(330, 38);
            txtLoginName.TabIndex = 18;
            // 
            // txtTicketCode
            // 
            txtTicketCode.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTicketCode.ForeColor = Color.Chocolate;
            txtTicketCode.Location = new Point(337, 287);
            txtTicketCode.Name = "txtTicketCode";
            txtTicketCode.PlaceholderText = "Mã vé...";
            txtTicketCode.Size = new Size(330, 38);
            txtTicketCode.TabIndex = 19;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Chocolate;
            btnSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.Snow;
            btnSearch.Location = new Point(401, 401);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(194, 69);
            btnSearch.TabIndex = 20;
            btnSearch.Text = "Tra cứu";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // TicketInfor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(982, 543);
            Controls.Add(btnSearch);
            Controls.Add(txtTicketCode);
            Controls.Add(txtLoginName);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TicketInfor";
            Text = "TicketSearch";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtLoginName;
        private TextBox txtTicketCode;
        private Button btnSearch;
    }
}