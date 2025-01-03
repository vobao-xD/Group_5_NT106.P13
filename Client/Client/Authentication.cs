﻿namespace Client
{
    public partial class Authentication : Form
    {
        private string _otp;
        public Authentication(string otp)
        {
            InitializeComponent();
            _otp = otp;
        }
        private void CheckOTP()
        {
            if (txtOTP.Text == _otp)
            {
                MessageBox.Show($"User Authenticated. Please Sign in to continue.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                SignUp._formCloseTaskSource?.SetResult(true);
                AuthenticationDashboard.ad_ins?.btnLoginForm_Click(null, null);
            }
            else
            {
                MessageBox.Show("Your OTP is incorrect. Try again!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOTP.Clear();
            }
        }
        private void btnAuthen_Click(object sender, EventArgs e)
        {
            CheckOTP();
        }
    }
}
