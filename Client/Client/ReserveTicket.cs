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
        static FileStream fs = new($"ReserveTicket_{DateTime.Now.ToString("dd-MM-yyyy_hh-MM-ss")}.log", FileMode.CreateNew);
        static StreamWriter sw = new(fs);
        public ReserveTicket(Trips trip, UserInfo userInfo, AuthToken authToken)
        {
            InitializeComponent();            
            this.plate = trip.Plate;
            _authToken = authToken; // dùng biến auth token này để tiếp tục làm việc
            _userInfo = userInfo;
            _trip = trip;
            
        }
        List<Seat>? seatsList;
        List<string> items;
        List<string> selectedSeats = [];
        string? plate;


        private void btnPay_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0) {
                MessageBox.Show("Please select a seat.","Notice",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            foreach (var sel in checkedListBox1.CheckedItems)
            {
                selectedSeats.Add(sel.ToString());
            }
            
            Payment pay = new(_trip, _userInfo, _authToken,selectedSeats);
            pay.ShowDialog();
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
                sw.WriteLine($"{DateTime.Now:[dd/MM/yyyy hh:MM:ss]} Create an instance of HttpClient");

                client.BaseAddress = new Uri($"http://127.0.0.1:8002/");
                sw.WriteLine($"{DateTime.Now:[dd/MM/yyyy hh:MM:ss]} Assigning BaseAddress: {client.BaseAddress.ToString()}");

                HttpResponseMessage response = await client.GetAsync($"seats?busid={_trip.BusId}&isbook=1");
                sw.WriteLine($"{DateTime.Now:[dd/MM/yyyy hh:MM:ss]} Waiting for response from server with busid {_trip.BusId}");

                string seats = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                sw.WriteLine($"{DateTime.Now:[dd/MM/yyyy hh:MM:ss]} Getting response from server with busid {_trip.BusId}");

                seatsList = JsonConvert.DeserializeObject<List<Seat>>(seats);
                sw.WriteLine($"{DateTime.Now:[dd/MM/yyyy hh:MM:ss]} Deserialize the response");

                foreach (Seat seat in seatsList)
                {
                    if (seat.SeatName != null) items.Remove(seat.SeatName);
                    sw.WriteLine($"{DateTime.Now:[dd/MM/yyyy hh:MM:ss]} Removed seatname: {seat.SeatName}");
                }

                checkedListBox1.Items.Clear();
                sw.WriteLine($"{DateTime.Now:[dd/MM/yyyy hh:MM:ss]} Cleared the check box");
                checkedListBox1.Items.AddRange(items.ToArray());
                sw.WriteLine($"{DateTime.Now:[dd/MM/yyyy hh:MM:ss]} Adding seat that is not reserved");
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Undefined Error: {ex.Message}");
                sw.WriteLine($"{DateTime.Now:[dd/MM/yyyy hh:MM:ss]} Undefined Error: {ex.Message}");
                sw.Close();
                
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
