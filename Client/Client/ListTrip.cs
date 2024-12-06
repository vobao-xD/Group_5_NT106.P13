using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Client
{
    public partial class ListTrip : Form
    {
        public ListTrip()
        {
            InitializeComponent();
        }

        private void ListTrip_Load(object sender, EventArgs e)
        {
            MessageBox.Show(response);
            ProcessResponse(response);
        }
        public string? response = Home.response;
        public void ProcessResponse(string response)
        {
            MessageBox.Show(response);
            if (response == null) { return; }
            try
            {
                List<Trips>? list = JsonConvert.DeserializeObject<List<Trips>>(response);
                if (list == null) { return; }
                foreach (var trip in list) 
                {
                    string[] tripinfo = { trip.TripId.ToString(), trip.TripName, trip.DepartLocation, trip.ArrivalLocation, trip.DepartureDate, trip.Status.ToString(), trip.Plate.ToString() };
                    ListViewItem item = new ListViewItem(tripinfo);
                    ListViewItem a = listView1.Items.Add(item);
                    
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }

    

    public class Trips
    {
        public int TripId { get; set; }
        public string? TripName { get; set; }
        public string? DepartLocation { get; set; }
        public string? ArrivalLocation { get; set; }
        public string? DepartureDate { get; set; }
        public int? Status { get; set; }
        public string? Plate { get; set; }
        public Trips(int tripId, string? tripName, string? departLocation, string? arrivalLocation, string? departureDate, int? status, string? plate)
        {
            TripId = tripId;
            TripName = tripName;
            DepartLocation = departLocation;
            ArrivalLocation = arrivalLocation;
            DepartureDate = departureDate;
            Status = status;
            this.Plate = plate;
        }
    }
}
