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
            string username = txtLoginName.Text;
            string password = HashPassword(txtPassword.Text);

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var loginResult = await _userController.LoginAsync(username, password);
            var userInfo = await _userController.UserInfoAsync(username, password);

            if (loginResult.Contains("Error"))
            {
                MessageBox.Show($"Đăng nhập thất bại: {loginResult}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xử lý logic tiếp theo, ví dụ: chuyển sang form chính
                Home home = new Home(userInfo);
                home.ShowDialog();
                this.Hide();
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }
    }
}
