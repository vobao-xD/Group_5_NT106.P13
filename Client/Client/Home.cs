using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net.Http;

namespace Client
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        

        private void chkboxRoundtrip_CheckedChanged(object sender, EventArgs e)
        {
            ReturnDate.Enabled = true;
            ReturnTime.Enabled = true;
            if (chkboxRoundtrip.Checked == false) { ReturnDate.Enabled = false; ReturnTime.Enabled = false; }
        }
        public static string? response;
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string request = $"from={HttpUtility.UrlEncode(cmbBoxDeparture.Text)}&to={HttpUtility.UrlEncode(cmbBoxDestination.Text)}";
            string fromtime = $"&fromTime={DepartDate.Text}%20{HttpUtility.UrlEncode(DepartTime.Text)}";
            string totime = $"&toTime={ReturnDate.Text}%20{HttpUtility.UrlEncode(ReturnTime.Text)}";
            string param = "&isReturn=false&ticketCount=1";
            string encode = "/trips?" + request + fromtime + totime + param;
            MessageBox.Show(encode);
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000");
                //Báo cáo giữa kỳ nói dùng HTTPS
                //Vô đây phải dùng HTTP
                //Chuẩn bị tiền học lại NT106 thôi các ông ạ :(

                HttpResponseMessage res = await client.GetAsync(encode);

                response = await res.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                MessageBox.Show(response);
                ListTrip ins = new ListTrip();
                ins.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }

    
    
    
}
