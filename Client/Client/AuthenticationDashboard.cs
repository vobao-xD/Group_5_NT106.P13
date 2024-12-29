namespace Client
{
    public partial class AuthenticationDashboard : Form
    {
        Login? login;
        SignUp? signup;
        ForgetPasswordForm? forgetPasswordForm;
        public static AuthenticationDashboard? ad_ins;
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
            ad_ins = this;
        }

        public void OpenForgetPasswordForm()
        {
            if (forgetPasswordForm == null)
            {
                forgetPasswordForm = new ForgetPasswordForm();
                forgetPasswordForm.FormClosed += ForgetPasswordForm_FormClosed;
                forgetPasswordForm.MdiParent = this;
                forgetPasswordForm.Dock = DockStyle.Fill;
                forgetPasswordForm.Show();
            }
            else { forgetPasswordForm.Activate(); }
        }
        
        private void ForgetPasswordForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            forgetPasswordForm = null;
        }

        private void Login_FormClosed(object? sender, FormClosedEventArgs e)
        {
            login = null;
        }

        public void btnLoginForm_Click(object sender, EventArgs e)
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

        private void AuthenticationDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
