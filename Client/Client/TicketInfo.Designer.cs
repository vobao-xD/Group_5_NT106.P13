namespace Client
{
    partial class TicketInfo
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
            txtTicketCode = new TextBox();
            btnSearch = new Button();
            flowLayoutPanel_TicketInfo = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Chocolate;
            label2.Location = new Point(240, 42);
            label2.Name = "label2";
            label2.Size = new Size(495, 46);
            label2.TabIndex = 17;
            label2.Text = "TRA CỨU THÔNG TIN ĐẶT VÉ";
            // 
            // txtTicketCode
            // 
            txtTicketCode.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTicketCode.ForeColor = Color.Chocolate;
            txtTicketCode.Location = new Point(325, 115);
            txtTicketCode.Name = "txtTicketCode";
            txtTicketCode.PlaceholderText = "Mã vé...";
            txtTicketCode.Size = new Size(347, 38);
            txtTicketCode.TabIndex = 19;
            txtTicketCode.TabStop = false;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Chocolate;
            btnSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.Snow;
            btnSearch.Location = new Point(418, 180);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(165, 61);
            btnSearch.TabIndex = 20;
            btnSearch.Text = "Tra cứu";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // flowLayoutPanel_TicketInfo
            // 
            flowLayoutPanel_TicketInfo.BackColor = Color.Bisque;
            flowLayoutPanel_TicketInfo.Location = new Point(325, 274);
            flowLayoutPanel_TicketInfo.Name = "flowLayoutPanel_TicketInfo";
            flowLayoutPanel_TicketInfo.Size = new Size(347, 245);
            flowLayoutPanel_TicketInfo.TabIndex = 21;
            // 
            // TicketInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(982, 543);
            Controls.Add(txtTicketCode);
            Controls.Add(btnSearch);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanel_TicketInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TicketInfo";
            Text = "TicketSearch";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtTicketCode;
        private Button btnSearch;
        private FlowLayoutPanel flowLayoutPanel_TicketInfo;
    }
}