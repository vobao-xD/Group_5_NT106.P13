using Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class UpdatePassword : Form
    {
        private string _username;
        private AuthToken _authToken;
        private HttpClient _httpClient;
        private UserController _userController;
        public UpdatePassword(string username, AuthToken authToken)
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _userController = new UserController(_httpClient);
            _authToken = authToken;
            _username = username;
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
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
        private async void ChangePasswordAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text) ||
                string.IsNullOrWhiteSpace(txtNewPassword.Text))
                {
                    MessageBox.Show("Please fill out all the form.");
                    return;
                }

                if (txtNewPassword.Text.Length < 8)
                {
                    MessageBox.Show("Your password is too short, needs to be more than or equal 8 characters.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Your password is not match!");
                    return;
                }

                string username = _username;
                string password = HashPassword(txtNewPassword.Text);

                var changePasswordResult = await _userController.UpdatePasswordAsync(username, password, _authToken);

                if (changePasswordResult.Id == 1)
                {
                    MessageBox.Show("Thay đổi mật khẩu thành công! Vui lòng đăng nhập lại!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Login login = new Login();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra vui lòng thực hiện lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RevealPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (RevealPassword.Checked)
            {
                txtNewPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtConfirmPassword.UseSystemPasswordChar = true;
                txtNewPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordAsync();
        }
    }
}
