using Client.Controller;
using Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Home : Form
    {
        private AuthToken _authToken;
        public Home(UserInfo userInfo, AuthToken authToken)
        {
            InitializeComponent();
            DisplayUserInfo(userInfo);
            _authToken = authToken; // dùng biến auth token này để tiếp tục làm việc
        }
        private void DisplayUserInfo(UserInfo userInfo)
        {
            try
            {
                var username = userInfo.FullName;
                var email = userInfo.UserEmail;
                labelUsername.Text = $"Welcome, {username}";
                labelUserEmail.Text = $"Your Email:, {email}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void labelLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged Out!");
            this.Close();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
