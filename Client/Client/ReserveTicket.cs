using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Client.Model;
using System.Diagnostics;

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
            this.plate = trip.Plate;
            _authToken = authToken; // dùng biến auth token này để tiếp tục làm việc
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

            HttpClient client2 = new();
            client2.BaseAddress = new Uri($"http://127.0.0.1:8002/");
            HttpResponseMessage response = await client2.GetAsync($"seats?busid={_trip.BusId}&isbook=0");
            string seats = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            seatsList = JsonConvert.DeserializeObject<List<Seat>>(seats);

            selectedSeats.Clear();
            foreach (var sel in checkedListBox1.CheckedItems)
            {
                selectedSeats.Add(sel.ToString());
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
            


            
            Payment pay = new(_trip, _userInfo, _authToken,selectedSeats);
            pay.ShowDialog();
            this.Close();
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
}
