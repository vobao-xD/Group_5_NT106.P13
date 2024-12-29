using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;



namespace Client
{ 
    public partial class Admin_ReadMail : Form
    {
        private SplitContainer splitContainer;
        private ListView emailListView;
        public Admin_ReadMail(string subject, string from, string to, string body, bool isHtml )
        {
            InitializeComponent();
            DisplayEmailContent(subject, from, to, body, isHtml);  
            //InitializeWebView2();
        }
        //private void InitializeWebView2()
        //{
        //    webView = new WebView2
        //    {
        //        Dock = DockStyle.Fill,
        //        Name = "webViewContent"
        //    };
        //    Controls.Add(webView);
        //}

        public async void DisplayEmailContent(string subject, string from, string date, string body, bool isHtml)
        {
            string htmlContent;
            if (!isHtml)
            {
                body = $"<pre>{System.Net.WebUtility.HtmlEncode(body)}</pre>";
            }

            htmlContent = $"<html><body>" +
                          $"<h1>Subject: {System.Net.WebUtility.HtmlEncode(subject)}</h1>" +
                          $"<p>From: {System.Net.WebUtility.HtmlEncode(from)}</p>" +
                          $"<p>Date: {System.Net.WebUtility.HtmlEncode(date)}</p>" +
                          $"{body}</body></html>";

            await webView21.EnsureCoreWebView2Async();
            webView21.CoreWebView2.NavigateToString(htmlContent);
        }
    }
}
