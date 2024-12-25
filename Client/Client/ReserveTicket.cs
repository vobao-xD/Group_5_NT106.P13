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

namespace Client
{
    public partial class ReserveTicket : Form
    {
        public int TripID = -1;
        public int UserID = -1;
        public ReserveTicket()
        {
            InitializeComponent();
        }
        public ReserveTicket(Trips trip, int UserID)
        {
            //Task.Run(() => GetUnavailableSeat(trip.Plate));
            InitializeComponent();
            //GET /seats?tripid={trip.TripID.ToString}
            TripID = trip.TripId;
            this.UserID = UserID;
            //this.Enabled = false;
            this.plate = trip.Plate;




        }
        List<string>? seatsList;
        List<string> items = new List<string>
        {
            "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10",
            "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10",
            "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10"
        };
        string? plate;
        public async Task GetUnavailableSeat(string? plate)
        {
            HttpClient client = new();
            client.BaseAddress = new Uri($"http://127.0.0.1:8000/");
            MessageBox.Show($"http://127.0.0.1:8000/seats?plate={plate}");
            HttpResponseMessage response = await client.GetAsync($"seats?plate={plate}");
            string seats = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            MessageBox.Show(seats);
            seatsList = JsonConvert.DeserializeObject<List<string>>(seats);
            if (seatsList == null) { return; }
            items.RemoveAll(seats => seatsList.Contains(seats));
            checkedListBox1.Items.AddRange(items.ToArray());

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            
        }

        private async void ReserveTicket_Load(object sender, EventArgs e)
        {
            HttpClient client = new();
            client.BaseAddress = new Uri($"http://127.0.0.1:8000/");
            MessageBox.Show($"http://127.0.0.1:8000/seats?plate={plate}");
            HttpResponseMessage response = await client.GetAsync($"seats?plate={plate}");
            string seats = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            MessageBox.Show(seats);
            seatsList = JsonConvert.DeserializeObject<List<string>>(seats);
            if (seatsList == null) { return; }
            items.RemoveAll(seats => seatsList.Contains(seats));
            checkedListBox1.Items.AddRange(items.ToArray());
        }
    }
}
