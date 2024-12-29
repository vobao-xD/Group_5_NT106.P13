using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using MailKit.Net.Smtp;
using MimeKit;

namespace Client
{
    public partial class SignUp : Form
    {
        private readonly UserController _userController;
        private readonly HttpClient _httpClient;
        private static readonly Random _random = new Random();
        Authentication? auth;
        public SignUp()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _userController = new UserController(_httpClient);
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }
        private void checkBoxRevealPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRevealPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
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
        private static bool IsValid(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|edu\.[a-z]{2})$";
            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }
        public static string GenerateOtp(int length = 4)
        {
            const string digits = "0123456789";
            char[] otp = new char[length];
            for (int i = 0; i < length; i++)
            {
                otp[i] = digits[_random.Next(digits.Length)];
            }
            return new string(otp);
        }
        public async Task SendEmail(string toEmail, string otp)
        {
            string htmlBody = $@"
                            <html>
                            <head>
                                <style>
                                    body {{
                                        font-family: Arial, sans-serif;
                                        background-color: #f4f4f4;
                                        margin: 0;
                                        padding: 0;
                                    }}
                                    .container {{
                                        max-width: 600px;
                                        margin: auto;
                                        background-color: #ffffff;
                                        padding: 20px;
                                        border-radius: 10px;
                                        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                                    }}
                                    .header {{
                                        background-color: #007bff;
                                        color: #ffffff;
                                        padding: 20px;
                                        text-align: center;
                                        border-radius: 10px 10px 0 0;
                                    }}
                                    .content {{
                                        padding: 20px;
                                    }}
                                    .otp {{
                                        display: inline-block;
                                        font-size: 24px;
                                        font-weight: bold;
                                        margin: 20px 0;
                                        padding: 10px;
                                        background-color: #e0e0e0;
                                        border-radius: 5px;
                                    }}
                                    .footer {{
                                        margin-top: 20px;
                                        font-size: 12px;
                                        color: #777777;
                                        text-align: center;
                                    }}
                                </style>
                            </head>
                            <body>
                                <div class='container'>
                                    <div class='header'>
                                        <h1>Chào mừng bạn đến với Công ty cổ phần Xe khách G5!</h1>
                                    </div>
                                    <div class='content'>
                                        <p>Chúng tôi rất vui mừng vì bạn đã đăng ký tài khoản với chúng tôi.</p>
                                        <p>Mã OTP của bạn để xác nhận email là:</p>
                                        <div class='otp'>{otp}</div>
                                        <p>Vui lòng nhập mã này để hoàn tất quá trình đăng ký.</p>
                                        <p>Nếu bạn không yêu cầu đăng ký tài khoản này, vui lòng bỏ qua email này.</p>
                                        <p>Trân trọng,</p>
                                        <p>Đội ngũ hỗ trợ Công ty cổ phần Xe khách G5</p>
                                    </div>
                                    <div class='footer'>
                                        <p>Địa chỉ: Phường Linh Trung, Thành Phố Thủ Đức, TP.HCM</p>
                                        <p>Email: support@xekhachg5.com | Hotline: 0123 456 789</p>
                                    </div>
                                </div>
                            </body>
                            </html>";
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("[Công ty cổ phần Xe khách G5]", "khoibaochien@gmail.com"));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = "[Công ty cổ phần Xe khách G5] Xác nhận Email người dùng";
            message.Body = new TextPart("html")
            {
                Text = htmlBody
            };
            using (var client = new SmtpClient())
            {
                try
                {
                    // Kết nối với máy chủ SMTP
                    await client.ConnectAsync("smtp.gmail.com", 465, true);

                    // Xác thực với máy chủ SMTP
                    await client.AuthenticateAsync("khoibaochien@gmail.com", "krti dtle hdjb exew");

                    // Gửi email
                    await client.SendAsync(message);

                    // Ngắt kết nối
                    await client.DisconnectAsync(true);
                    MessageBox.Show($"OTP has been sent to your email: {toEmail}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtLoginName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    MessageBox.Show("Please fill out all the form.");
                    return;
                }
                if (!IsValid(txtEmail.Text))
                {
                    MessageBox.Show("Your email is invalid");
                    return;
                }
                if (txtPassword.Text.Length < 8)
                {
                    MessageBox.Show("Your password is too short, needs to be more than or equal 8 characters.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Your password is not match!");
                    return;
                }
                string username = txtLoginName.Text;
                string password = HashPassword(txtPassword.Text);
                string fullname = txtFullName.Text;
                string email = txtEmail.Text;
                int userroleid = 1;
                var signUpResult = await _userController.SignUpAsync(username, password, fullname, email, userroleid);
                if (signUpResult.Id == 1)
                {
                    MessageBox.Show("You need to authenticate your Email first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string otp = GenerateOtp();
                    await SendEmail(email, otp);
                    await OpenAuthenticationFormAsync(otp);
                    MessageBox.Show(signUpResult.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    AuthenticationDashboard.ad_ins?.btnLoginForm_Click(null, null);
                }
                else
                {
                    MessageBox.Show(signUpResult.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static TaskCompletionSource<bool>? _formCloseTaskSource;

        private async Task<bool> OpenAuthenticationFormAsync(string otp)
        {
            if (auth == null)
            {
                _formCloseTaskSource = new TaskCompletionSource<bool>();

                auth = new Authentication(otp);
                auth.FormClosed += Auth_FormClosed;
                auth.MdiParent = AuthenticationDashboard.ad_ins;
                auth.Dock = DockStyle.Fill;
                auth.Show();
                await _formCloseTaskSource.Task;
            }
            else
            {
                auth.Activate();
            }

            return true;
        }

        private void Auth_FormClosed(object? sender, FormClosedEventArgs e)
        {
            auth = null;
        }
    }
}
