using Client.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MimeKit;
using MailKit.Net.Smtp;
using System.Security.Cryptography;

namespace Client
{
    public partial class Login : Form
    {
        private readonly UserController _userController;
        private readonly HttpClient _httpClient;

        public Login()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _userController = new UserController(_httpClient);
            txtPassword.UseSystemPasswordChar = true;
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtLoginName.Text;
                string password = HashPassword(txtPassword.Text);

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var loginResult = await _userController.LoginAsync(username, password);
                var userInfo = await _userController.UserInfoAsync(username, password, loginResult);

                if (loginResult == null || loginResult.Message.Contains("Error"))
                {
                    MessageBox.Show($"Đăng nhập thất bại: {loginResult?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                {
                    MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (userInfo.UserRoleId == 1)
                    {
                        // change to admin
                        AdminForm adminForm = new AdminForm(userInfo, loginResult);
                        adminForm.Show();
                        this.Hide();
                    }
                    if (userInfo.UserRoleId == 2)
                    {
                        // change to staff
                        StaffForm staffForm = new StaffForm(userInfo, loginResult);
                        staffForm.Show();
                        this.Hide();
                    }
                    if (userInfo.UserRoleId == 3)
                    {
                        // change to customer
                        Home home = new Home(userInfo, loginResult);
                        home.Show();
                        this.Hide();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đăng nhập thất bại: Sai thông tin username hoặc password", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }

        private void checkBoxRevealPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRevealPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
