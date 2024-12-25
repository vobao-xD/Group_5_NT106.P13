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
        public int TripID = -1;
        public int UserID = -1;
        public int BusID = -1;
        private UserInfo _userInfo;
        private AuthToken _authToken;
        public ReserveTicket(Trips trip, UserInfo userInfo, AuthToken authToken)
        {
            InitializeComponent();
            //GET /seats?tripid={trip.TripID.ToString}
            TripID = trip.TripId;
            BusID = trip.BusId;
            this.plate = trip.Plate;
            _authToken = authToken; // dùng biến auth token này để tiếp tục làm việc
            _userInfo = userInfo;

        }
        List<Seat>? seatsList;
        List<string> items;
        string? plate;
        public async Task GetUnavailableSeat(string? plate)
        {
            HttpClient client = new();
            client.BaseAddress = new Uri($"http://127.0.0.1:8002/");
            MessageBox.Show($"http://127.0.0.1:8002/seats?busid={BusID}&isbook=1");
            HttpResponseMessage response = await client.GetAsync($"seats?busid={BusID}&isbook=1");
            string seats = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            MessageBox.Show(seats);
            seatsList = JsonConvert.DeserializeObject<List<Seat>>(seats);
            if (seatsList == null) { return; }
            List<string> unseat = [];
            foreach (Seat seat in seatsList)
            {
                unseat.Add(seat.GetSeatName());
            }
            foreach (string seat in unseat)
            {
                items.RemoveAll(seat => unseat.Contains(seat));
            }
            checkedListBox1.Items.AddRange(items.ToArray());

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            
        }

        private async void ReserveTicket_Load(object sender, EventArgs e)
        {
            items = new List<string>
            {
            "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10",
            "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10",
            "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10"
            };
            try
            {
                HttpClient client = new();
                client.BaseAddress = new Uri($"http://127.0.0.1:8002/");
                //MessageBox.Show($"http://127.0.0.1:8002/seats?busid={BusID}&isbook=1");
                HttpResponseMessage response = await client.GetAsync($"seats?busid={BusID}&isbook=1");
                string seats = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                MessageBox.Show(seats);
                seatsList = JsonConvert.DeserializeObject<List<Seat>>(seats);
                //foreach (Seat seat in seatsList) {
                //    unseat.Add(seat.GetSeatName());
                //}
                //items.RemoveAll(a => newSeatsList.Contains(a.ToString()));
                //List<string> toRemove = new List<string>();

                foreach (Seat seat in seatsList)
                {
                    if (seat.SeatName != null) items.Remove(seat.SeatName);
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
