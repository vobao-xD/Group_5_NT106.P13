namespace Client
{
    public partial class BrowserForPayment : Form
    {
        public BrowserForPayment(string URL)
        {
            InitializeComponent();
            InitializeWebView(URL);
        }
        private async void InitializeWebView(string URL)
        {
            try
            {
                // Ensure WebView2 is initialized
                await webView21.EnsureCoreWebView2Async(null);

                // Set the source URL for the WebView2 control
                webView21.Source = new Uri(URL);

                // Optionally, handle navigation completion for custom actions
                webView21.NavigationCompleted += webView21_NavigationCompleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load WebView2: {ex.Message}");
            }
        }

        private void webView21_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                string currentUrl = webView21.Source.ToString();
                if (currentUrl.Contains("/payment/success"))
                {
                    this.Close();
                    MessageBox.Show("Thanh toán thành công!");
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Navigation failed: {e.WebErrorStatus}");
            }
        }
    }
}
