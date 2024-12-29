using Client.Model;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Admin_Email_Support : Form
    {
        private List<MimeMessage> messages = new List<MimeMessage>();
        public Admin_Email_Support()
        {
            InitializeComponent();
            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                using (var client = new ImapClient())
                {
                    await client.ConnectAsync("imap.gmail.com", 993, true);

                    await client.AuthenticateAsync("khoibaochien@gmail.com", "krti dtle hdjb exew");

                    var inbox = client.Inbox;
                    await inbox.OpenAsync(FolderAccess.ReadOnly);

                    dataGridViewEmails.Rows.Clear();
                    messages.Clear();

                    foreach (var uid in await inbox.SearchAsync(SearchQuery.All))
                    {
                        var message = await inbox.GetMessageAsync(uid);
                        messages.Add(message);
                        dataGridViewEmails.Rows.Add(dataGridViewEmails.Rows.Count + 1, message.Subject, message.From.ToString(), message.Date.ToString("dd/MM/yyyy HH:mm:ss"));
                    }
                    await client.DisconnectAsync(true);
                }

                MessageBox.Show("Emails retrieved successfully!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridViewEmails.Rows.Clear();
            messages.Clear();
            LoadDataAsync();
        }

        private void dataGridViewEmails_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < messages.Count)
            {
                MimeMessage selectedMessage = messages[e.RowIndex];
                if (selectedMessage != null)
                {
                    List<string> imageAttachments = new List<string>();
                    foreach (var attachment in selectedMessage.Attachments)
                    {
                        if (attachment is MimePart mimePart && mimePart.ContentType.MimeType.StartsWith("image/"))
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                mimePart.Content.DecodeTo(memoryStream);
                                string base64Image = Convert.ToBase64String(memoryStream.ToArray());
                                string imageDataUrl = $"data:{mimePart.ContentType.MimeType};base64,{base64Image}";
                                imageAttachments.Add(imageDataUrl);
                            }
                        }
                    }
                    Admin_ReadMail ar = new Admin_ReadMail(selectedMessage.Subject, selectedMessage.From.ToString(), selectedMessage.To.ToString(),
                            selectedMessage.HtmlBody ?? selectedMessage.TextBody ?? string.Empty, !string.IsNullOrEmpty(selectedMessage.HtmlBody));
                    ar.ShowDialog();
                }
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminForm.adf?.OpenSendMailForm();
        }
    }
}
