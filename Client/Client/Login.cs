using System.Security.Cryptography;
using System.Text;
using Client.Controller;

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
                        AdminForm adminForm = new AdminForm(userInfo, loginResult);
                        adminForm.Show();
                        this.Hide();
                    }
                    else if (userInfo.UserRoleId == 3)
                    {
                        UserDashboard ds = new UserDashboard(userInfo, loginResult);
                        ds.Show();
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
    }
}
