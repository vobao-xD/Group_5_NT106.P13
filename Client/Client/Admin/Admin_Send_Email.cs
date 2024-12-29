using MailKit.Net.Smtp;
using MimeKit;

namespace Client
{
    public partial class Admin_Send_Email : Form
    {
        public Admin_Send_Email()
        {
            InitializeComponent();
            progressBarEmail.Visible = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            progressBarEmail.Visible = true;
            progressBarEmail.Value = 0;
            try
            {
                // Cập nhật tiến trình khi bắt đầu gửi
                progressBarEmail.Value = 25;

                // Gửi email
                SendEmailResponseWithAttachment();

                // Cập nhật tiến trình khi hoàn thành
                progressBarEmail.Value = 100;

                // Hiển thị thông báo thành công
                MessageBox.Show($"Đã gửi email thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Cập nhật tiến trình khi gặp lỗi
                progressBarEmail.Value = 0;
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Task.Delay(500);
                progressBarEmail.Visible = false;
            }
        }

        public async Task SendEmailResponseWithAttachment()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("[Công ty cổ phần Xe khách G5]", "khoibaochien@gmail.com"));
            message.To.Add(new MailboxAddress("", txtMailDestAddress.Text));
            message.Subject = $"[Phản hồi từ Admin] {txtSubject.Text}";

            var bodyBuilder = new BodyBuilder();
            string htmlBody = $@"
                    <!DOCTYPE html>
                    <html lang=""vi"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Phản hồi hỗ trợ</title>
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
                                <div class=""card-header text-center bg-success text-white"">
                                    <h2>Phản Hồi Yêu Cầu Hỗ Trợ</h2>
                                </div>
                                <div class=""card-body"">
                                    <p>Kính gửi Quý khách,</p>
                                    <p>Cảm ơn Quý khách đã liên hệ với chúng tôi. Dưới đây là phản hồi của chúng tôi cho yêu cầu hỗ trợ của Quý khách:</p>
                                    <hr>
                                    <p><strong>Email liên hệ:</strong> <span class=""text-primary"">{txtMailDestAddress.Text}</span></p>
                                    <p><strong>Chủ đề:</strong> <span class=""text-primary"">{txtSubject.Text}</span></p>
                                    <p><strong>Nội dung phản hồi:</strong></p>
                                    <p class=""border p-2"">{txtContent.Text}</p>
                                    <hr>
                                    <p>Chúng tôi hy vọng phản hồi này sẽ giúp giải quyết yêu cầu của Quý khách. Nếu Quý khách còn bất kỳ thắc mắc nào, vui lòng liên hệ với chúng tôi qua email.</p>
                                    <p>Trân trọng,</p>
                                    <p><strong>Đội ngũ hỗ trợ khách hàng</strong></p>
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

            bodyBuilder.HtmlBody = htmlBody;

            // Đính kèm nhiều tệp nếu có
            if (!string.IsNullOrWhiteSpace(txtPicturePath.Text))
            {
                var files = txtPicturePath.Text.Split(';');
                foreach (var file in files)
                {
                    bodyBuilder.Attachments.Add(file);
                }
            }

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync("smtp.gmail.com", 465, true);

                    await client.AuthenticateAsync("khoibaochien@gmail.com", "krti dtle hdjb exew");

                    await client.SendAsync(message);

                    await client.DisconnectAsync(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "All Files (*.*)|*.*|Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|PDF Files (*.pdf)|*.pdf|Word Files (*.doc;*.docx)|*.doc;*.docx";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPicturePath.Text = string.Join(";", openFileDialog.FileNames);
                }
            }
        }

    }
}
