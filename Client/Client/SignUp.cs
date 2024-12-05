using Client.Controller;
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
    public partial class SignUp : Form
    {
        private readonly UserController _userController;
        private readonly HttpClient _httpClient;
        public SignUp()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _userController = new UserController(_httpClient);
        }
        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtLoginName.Text;
            string password = txtPassword.Text;
            string fullname = txtFullName.Text;
            string email = txtEmail.Text;
            int userroleid = 1; // need change afterward
            var signUpResult = await _userController.SignUpAsync(username,password,fullname,email,userroleid);
            MessageBox.Show(signUpResult);
        }
    }
}
