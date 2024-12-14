using Client.Model;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Client
{
    public partial class Support : Form
    {
        private UserInfo _userinfo;
        public Support(UserInfo userInfo)
        {
            InitializeComponent();
            _userinfo = userInfo;
            progressBarEmail.Visible = false;
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            progressBarEmail.Visible = true;
            progressBarEmail.Value = 0;
            try
            {
                // Cập nhật tiến trình khi bắt đầu gửi
                progressBarEmail.Value = 25;

                // Gửi email
                await SendEmail();

                // Cập nhật tiến trình khi hoàn thành
                progressBarEmail.Value = 100;

                // Hiển thị thông báo thành công
                MessageBox.Show($"Đã gửi yêu cầu hỗ trợ thành công đến Admin!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Cập nhật tiến trình khi gặp lỗi
                progressBarEmail.Value = 0;
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ẩn ProgressBar sau khi hoàn tất
                await Task.Delay(500); // Thêm một khoảng thời gian để người dùng thấy ProgressBar hoàn thành
                progressBarEmail.Visible = false;
            }
        }
        public async Task SendEmail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("[Công ty cổ phần Xe khách G5]", "s78776033@gmail.com"));
            message.To.Add(new MailboxAddress("", "khoibaochien@gmail.com"));
            message.Subject = $"[Yêu cầu hỗ trợ từ người dùng] {txtSubject.Text}";
            string htmlBody = $@"
                            <!DOCTYPE html>
                            <html lang=""vi"">
                            <head>
                                <meta charset=""UTF-8"">
                                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                                <title>Email hỗ trợ</title>
                                <!-- Bootstrap CSS -->
                                <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css"" rel=""stylesheet"">
                                <style>
                                    body {{
                                        font-family: 'Roboto', sans-serif;
                                    }}
                                    h2 {{
                                        font-family: 'Poppins', sans-serif;
                                        font-weight: 600;
                                    }}
                                    .card {{
                                        border-radius: 12px;
                                    }}
                                    .card-header {{
                                        border-radius: 12px 12px 0 0;
                                    }}
                                    .card-footer {{
                                        border-radius: 0 0 12px 12px;
                                    }}
                                </style>
                                <!-- Google Fonts -->
                                <link href=""https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&family=Roboto:wght@300;400&display=swap"" rel=""stylesheet"">
                            </head>
                            <body>
                                <div class=""container mt-4"">
                                    <div class=""card shadow"">
                                        <div class=""card-header text-center bg-primary text-white"">
                                            <h2>Yêu Cầu Hỗ Trợ Từ Người Dùng</h2>
                                        </div>
                                        <div class=""card-body"">
                                            <p>Kính gửi Admin,</p>
                                            <p>Người dùng <span class=""text-primary fw-bold"">{_userinfo.FullName}</span> đã gửi một yêu cầu hỗ trợ với nội dung như sau:</p>
                                            <hr>
                                            <p><strong>Email liên hệ:</strong> <span class=""text-primary"">{_userinfo.UserEmail}</span></p>
                                            <p><strong>Chủ đề:</strong> <span class=""text-primary"">{txtSubject.Text}</span></p>
                                            <p><strong>Nội dung cần hỗ trợ:</strong></p>
                                            <p class=""border p-2"">{txtContent.Text}</p>
                                            <hr>
                                            <p>Vui lòng liên hệ với khách hàng qua email để hỗ trợ yêu cầu này sớm nhất có thể.</p>
                                        </div>
                                        <div class=""card-footer text-center text-muted"">
                                            <p>&copy; 2024 Công ty cổ phần Xe khách G5. Mọi quyền được bảo lưu.</p>
                                        </div>
                                    </div>
                                </div>
                                <!-- Bootstrap JS (Optional) -->
                                <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js""></script>
                            </body>
                            </html>";
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
                    await client.AuthenticateAsync("s78776033@gmail.com", "lxgv zeiy gxss yocj");

                    // Gửi email
                    await client.SendAsync(message);

                    // Ngắt kết nối
                    await client.DisconnectAsync(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
