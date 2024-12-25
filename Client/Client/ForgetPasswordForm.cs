using Client.Controller;
using MailKit.Net.Smtp;
using MimeKit;
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
    public partial class ForgetPasswordForm : Form
    {
        private HttpClient _httpClient;
        private UserController _userController;
        public ForgetPasswordForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _userController = new UserController(_httpClient);
        }

        private static string GenerateRandomPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                sb.Append(validChars[rnd.Next(validChars.Length)]);
            }
            return sb.ToString();
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

        private async Task<bool> SendEmailAsync(string email, string newPassword)
        {
            string senderEmail = "khoibaochien@gmail.com";
            string senderPassword = "krti dtle hdjb exew";
            string subject = "Reset Password";
            string body = $@"
                <!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Reset Password</title>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            margin: 0;
                            padding: 0;
                            background-color: #f4f4f4;
                        }}
                        .container {{
                            width: 100%;
                            max-width: 600px;
                            margin: 0 auto;
                            padding: 20px;
                            background-color: #ffffff;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                        }}
                        .header {{
                            text-align: center;
                            padding: 10px 0;
                            border-bottom: 1px solid #dddddd;
                        }}
                        .content {{
                            padding: 20px 0;
                        }}
                        .footer {{
                            text-align: center;
                            padding: 10px 0;
                            border-top: 1px solid #dddddd;
                            font-size: 12px;
                            color: #999999;
                        }}
                        .button {{
                            display: inline-block;
                            padding: 10px 20px;
                            margin-top: 20px;
                            background-color: #28a745;
                            color: #ffffff;
                            text-decoration: none;
                            border-radius: 5px;
                        }}
                    </style>
                </head>
                <body>
                    <div class=""container"">
                        <div class=""header"">
                            <h2>Password Reset</h2>
                        </div>
                        <div class=""content"">
                            <p>Dear User,</p>
                            <p>Your new password is:</p>
                            <p><strong>{newPassword}</strong></p>
                            <p>Please use this new password to log in with your username. We recommend changing your password once you have successfully logged in.</p>
                        </div>
                        <div class=""footer"">
                            <p>If you did not request this password reset, please contact our support team immediately.</p>
                            <p>Thank you,<br>Group 5</p>
                        </div>
                    </div>
                </body>
                </html>";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Reset Password From Group 5", senderEmail));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;
            message.Body = new TextPart("html")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    // Kết nối với máy chủ SMTP
                    await client.ConnectAsync("smtp.gmail.com", 465, true);

                    // Xác thực với máy chủ SMTP
                    await client.AuthenticateAsync(senderEmail, senderPassword);

                    // Gửi email
                    await client.SendAsync(message);

                    // Ngắt kết nối
                    await client.DisconnectAsync(true);

                    MessageBox.Show("Email sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        private async void btnSend_Click(object sender, EventArgs e)
        {
            string newPassword = GenerateRandomPassword(8);
            string HashedPassword = HashPassword(newPassword);
            var result = await _userController.ForgetPasswordAsync(txtEmail.Text, HashedPassword);
            if (result.Id == 1)
            {
                await SendEmailAsync(txtEmail.Text, newPassword);
                MessageBox.Show("Mật khẩu mới đã được gửi đến email của bạn! Vui lòng đăng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                Login login = new Login();
                login.Show();
            }
            else
            {
                MessageBox.Show("Email không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
