using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class AuthenticationDashboard : Form
    {
        Login? login;
        SignUp? signup;
        public AuthenticationDashboard()
        {
            InitializeComponent();
            if (login == null)
            {
                login = new Login();
                login.FormClosed += Login_FormClosed;
                login.MdiParent = this;
                login.Dock = DockStyle.Fill;
                login.Show();
            }
            else { login.Activate(); }
        }

        private void Login_FormClosed(object? sender, FormClosedEventArgs e)
        {
            login = null;
        }

        private void btnLoginForm_Click(object sender, EventArgs e)
        {
            if (login == null)
            {
                login = new Login();
                login.FormClosed += Login_FormClosed;
                login.MdiParent = this;
                login.Dock = DockStyle.Fill;
                login.Show();
            }
            else { login.Activate(); }
        }

        private void btnSignupform_Click(object sender, EventArgs e)
        {
            if (signup == null)
            {
                signup = new SignUp();
                signup.FormClosed += Signup_FormClosed;
                signup.MdiParent = this;
                signup.Dock = DockStyle.Fill;
                signup.Show();
            }
            else { signup.Activate(); }
        }

        private void Signup_FormClosed(object? sender, FormClosedEventArgs e)
        {
            signup = null;
        }
    }
}
