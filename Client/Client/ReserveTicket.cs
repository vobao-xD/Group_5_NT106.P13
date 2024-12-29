using Client.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Client
{
    public partial class ReserveTicket : Form
    {
        
        private Trips _trip;
        private UserInfo _userInfo;
        private AuthToken _authToken;
        public ReserveTicket(Trips trip, UserInfo userInfo, AuthToken authToken)
        {
            InitializeComponent();            
            plate = trip.Plate;
            _authToken = authToken;
            _userInfo = userInfo;
            _trip = trip;
            
        }
        List<Seat>? seatsList;
        List<string> items = new List<string>();
        List<string> selectedSeats = [];
        string? plate;

        private async void btnPay_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0) {
                MessageBox.Show("Please select a seat.","Notice",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            using HttpClient client = new();
            client.BaseAddress = new Uri($"http://127.0.0.1:8002/");
            var seatResponse = await client.GetAsync($"seats?busid={_trip.BusId}&isbook=0");
            string seats = await seatResponse.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            seatsList = JsonConvert.DeserializeObject<List<Seat>>(seats);
            selectedSeats.Clear();
            string BookedSeat = "";
            foreach (string sel in checkedListBox1.CheckedItems)
            {
                selectedSeats.Add(sel.ToString());
                BookedSeat += sel + " ";
            }
            items.Clear();
            foreach (Seat seat in seatsList)
            {
                if (seat.SeatName != null) items.Add(seat.SeatName);
            }
            checkedListBox1.Items.Clear();
            checkedListBox1.Items.AddRange(items.ToArray());
            foreach (var sel in selectedSeats)
            {
                if (!items.Contains(sel))
                {
                    MessageBox.Show($"Someone has chosen this seat [{sel}]. Please choose another seat");
                    return;
                }
            }
            
            try
            {
                var requestBody = new MomoRequest()
                {
                    trip_name = _trip.DepartLocation + " - " + _trip.ArrivalLocation,
                    booked_seat = BookedSeat,
                    trip_id = _trip.TripId,
                    user_id = _userInfo.UserId,
                    license_plate = _trip.Plate
                };
                string jsonRequestBody = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonRequestBody, System.Text.Encoding.UTF8, "application/json");
                string requestUri = $"create_payment";
                var paymentResponse = await client.PostAsync(requestUri, content);

                if (paymentResponse.IsSuccessStatusCode)
                {
                    var json = JObject.Parse(await paymentResponse.Content.ReadAsStringAsync());

                    if (json.ContainsKey("payUrl"))
                    {
                        string payUrl = json["payUrl"].ToString();
                        using (var process = new System.Diagnostics.Process())
                        {
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = payUrl,
                                UseShellExecute = true
                            };
                            process.Start();

                            // Chờ trình duyệt đóng
                            process.WaitForExit();
                        }

                        MessageBox.Show("Thanh toán thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Payment response received but no URL was provided.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại!\n" + await paymentResponse.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private async void ReserveTicket_Load(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new();
                client.BaseAddress = new Uri($"http://127.0.0.1:8002/");
                HttpResponseMessage response = await client.GetAsync($"seats?busid={_trip.BusId}&isbook=0");
                string seats = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                seatsList = JsonConvert.DeserializeObject<List<Seat>>(seats);
                foreach (Seat seat in seatsList)
                {
                    if (seat.SeatName != null) items.Add(seat.SeatName);
                }
                checkedListBox1.Items.Clear();
                checkedListBox1.Items.AddRange(items.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Undefined Error: {ex.Message}");
                
            }
        }
    }
    class Seat
    {
        public string? Plate;
        public string? SeatName;
        public bool IsBook;
        public int SeatID;
    }

    class MomoRequest
    {
        public string? trip_name { get; set; }
        public string? booked_seat { get; set; }
        public int? trip_id { get; set; }
        public int? user_id { get; set; }
        public string? license_plate { get; set; }
    }
}
