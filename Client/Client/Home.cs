using System.Globalization;
using System.Web;
using Client.Model;
using Newtonsoft.Json;

namespace Client
{
    public partial class Home : Form
    {
        private AuthToken _authToken;
        private UserInfo _userInfo;
        private string url = "http://127.0.0.1:8002";
        public static string? response;

        public Home(UserInfo userInfo, AuthToken authToken)
        {
            InitializeComponent();
            _authToken = authToken;
            _userInfo = userInfo;
        }

        private string ConvertDate(string s)
        {
            var date = DateTime.ParseExact(s, "dd-MM-yyyy",
                                   CultureInfo.InvariantCulture);
            return date.ToString("yyyy-MM-dd");
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBoxDeparture.Text == cmbBoxDestination.Text)
                {
                    MessageBox.Show("Điểm đi và điểm đến không được trùng nhau.");
                    return;
                }
                if (DepartTime.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập giờ khởi hành");
                    return;
                }
                string request = $"from={HttpUtility.UrlEncode(cmbBoxDeparture.Text)}&to={HttpUtility.UrlEncode(cmbBoxDestination.Text)}";
                string fromtime = $"&fromTime={ConvertDate(DepartDate.Text)}%20{HttpUtility.UrlEncode(DepartTime.Text)}";
                string encode;
                encode = "/trips?" + request + fromtime;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                HttpResponseMessage res = await client.GetAsync(encode);
                response = await res.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return;  }

            if (response == null) { MessageBox.Show("Null response"); return; }
            try
            {
                List<Trips>? list = JsonConvert.DeserializeObject<List<Trips>>(response);
                if (list == null)
                {
                    MessageBox.Show("Không tìm thấy chuyến xe phù hợp");
                    return;
                }
                MessageBox.Show("Tìm thấy chuyến xe! Mời bạn đặt vé cho chuyến đi!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int ListId = list[0].TripId;
                ReserveTicket ins1 = new(list[0], _userInfo, _authToken);
                ins1.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }   
    
    }

    public class Trips
    {
        public int TripId { get; set; }
        public int BusId { get; set; }
        public string? Plate { get; set; }
        public string? DepartLocation { get; set; }
        public string? ArrivalLocation { get; set; }
        public string? DepartureDate { get; set; }
    }

}