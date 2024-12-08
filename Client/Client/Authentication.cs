using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
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
                Login login = new Login();
                login.ShowDialog();
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
