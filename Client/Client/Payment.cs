using Client.Model;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Principal;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;

namespace Client
{
    public partial class Payment : Form
    {
        private Trips _trip;
        private UserInfo _userInfo;
        private AuthToken _authToken;
        private List<string> selectedSeats;
        private long price = 0;
        private int[] basePrice = {200000, 500000 };
        public Payment(Trips trip, UserInfo userInfo, AuthToken authToken, List<string> selectedSeat)
        {
            InitializeComponent();
            _authToken = authToken;
            _userInfo = userInfo;
            _trip = trip;
            selectedSeats = selectedSeat;
            foreach (string seat in selectedSeats)
            {
                if (_trip.DepartLocation == "Hà Nội" || _trip.ArrivalLocation == "Hà Nội")
                {
                    price += basePrice[1];
                }
                else
                {
                    price += basePrice[0];
                }
            }
            PopulateInfo();
            
            
        }

        private async Task PostSelectedSeat()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8002/");
                int i = 0;
                foreach (string seat in selectedSeats)
                {
                    SelSeat s = new(seat, _trip.Plate);
                    string req = JsonConvert.SerializeObject(s, Formatting.Indented);
                    StringContent content = new(req, Encoding.UTF8, "application/json");
                    HttpResponseMessage res = await client.PostAsync("updateSeatToBooked", content);
                    res.EnsureSuccessStatusCode();
                    var jsonResponse = await res.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<Response>(jsonResponse);
                    ++i;
                    
                }
                if (i == selectedSeats.Count)
                {
                    MessageBox.Show("Mời bạn đến phần thanh toán");
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
                this.Close(); //Continue payment here
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void PopulateInfo()
        {
            try
            {
                string seats = string.Join(",", selectedSeats);
                var format = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
                format.NumberGroupSeparator = " ";

                //txtInfo.Nodes.Clear();
                TreeNode busNode = new TreeNode($"Bus: {_trip.Plate}");

                TreeNode tripNode = new TreeNode($"Trip: {_trip.DepartLocation} → {_trip.ArrivalLocation} at {_trip.DepartureDate}");
                tripNode.Nodes.Add(new TreeNode($"Seats: {seats}"));
                tripNode.Nodes.Add(new TreeNode($"Money: {price.ToString("N0",format)}đ"));

                busNode.Nodes.Add(tripNode);

                
                txtInfo.Nodes.Add(busNode);


                txtInfo.ExpandAll();

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Null Reference Error: {ex}");
            }
        }

        private async void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                string apiUrl = "http://127.0.0.1:8002";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);

                    string requestUri = "create_payment?order_info=ABD&order_amount=10000";

                    HttpResponseMessage response = await client.PostAsync(requestUri, null);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = JObject.Parse(await response.Content.ReadAsStringAsync());

                        if (json.ContainsKey("payUrl"))
                        {
                            string payUrl = json["payUrl"].ToString();
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = payUrl,
                                UseShellExecute = true
                            });
                        }
                        else
                        {
                            MessageBox.Show("Payment response received but no URL was provided.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán thất bại!\n" + await response.Content.ReadAsStringAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }
    }
}

class SelSeat
{
    public string? seat;
    public string? plate;
    public SelSeat(string? seat, string? plate)
    {
        this.seat = seat;
        this.plate = plate;
    }
}

class Response
{
    public string? Id;
    public string? Message;
}


