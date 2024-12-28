namespace Client
{
    partial class AuthenticationDashboard
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
            btnLoginForm = new Button();
            btnSignupform = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoginForm
            // 
            btnLoginForm.Dock = DockStyle.Left;
            btnLoginForm.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnLoginForm.ForeColor = Color.Chocolate;
            btnLoginForm.Location = new Point(0, 0);
            btnLoginForm.Name = "btnLoginForm";
            btnLoginForm.Size = new Size(391, 50);
            btnLoginForm.TabIndex = 0;
            btnLoginForm.Text = "Have an account?";
            btnLoginForm.UseVisualStyleBackColor = true;
            btnLoginForm.Click += btnLoginForm_Click;
            // 
            // btnSignupform
            // 
            btnSignupform.Dock = DockStyle.Right;
            btnSignupform.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnSignupform.ForeColor = Color.Chocolate;
            btnSignupform.Location = new Point(491, 0);
            btnSignupform.Name = "btnSignupform";
            btnSignupform.Size = new Size(391, 50);
            btnSignupform.TabIndex = 1;
            btnSignupform.Text = "Don't have an account?";
            btnSignupform.UseVisualStyleBackColor = true;
            btnSignupform.Click += btnSignupform_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLoginForm);
            panel1.Controls.Add(btnSignupform);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 553);
            panel1.Name = "panel1";
            panel1.Size = new Size(882, 50);
            panel1.TabIndex = 2;
            // 
            // AuthenticationDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 603);
            Controls.Add(panel1);
            IsMdiContainer = true;
            Name = "AuthenticationDashboard";
            Text = "AuthenticationDashboard";
            FormClosed += AuthenticationDashboard_FormClosed;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoginForm;
        private Button btnSignupform;
        private Panel panel1;
    }
}