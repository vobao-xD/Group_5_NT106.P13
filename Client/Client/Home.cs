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
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            try
            {
            string request = $"from={HttpUtility.UrlEncode(cmbBoxDeparture.Text)}&to={HttpUtility.UrlEncode(cmbBoxDestination.Text)}";
            string fromtime = $"&fromTime={DepartDate.Text}%20{HttpUtility.UrlEncode(DepartTime.Text)}";
            string totime = $"&toTime={ReturnDate.Text}%20{HttpUtility.UrlEncode(ReturnTime.Text)}";
            string param = $"&isReturn={chkboxRoundtrip.Checked}&ticketCount=1";
                string encode;
                if (chkboxRoundtrip.Checked == true) encode = "/trips?" + request + fromtime + totime + param;
                else encode = "/trips?" + request + fromtime + param;
            MessageBox.Show(encode);
            
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000");
                

                HttpResponseMessage res = await client.GetAsync(encode);

                response = await res.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


            if (response == null) { MessageBox.Show("Null response"); return; }
            try
            {
                List<Trips>? list = JsonConvert.DeserializeObject<List<Trips>>(response);
                if (list == null)
                {
                    MessageBox.Show("Không tìm thấy chuyến xe phù hợp");
                    return;
                }
                
                if (chkboxRoundtrip.Checked == true)
                {
                    if (list.Count == 1)
                    {
                        if (list[0].DepartLocation == cmbBoxDeparture.Text)
                        {
                            MessageBox.Show("Không tìm thấy chuyến về");
                            return;
                        }
                        else if (list[0].DepartLocation == cmbBoxDestination.Text)
                        {
                            MessageBox.Show("Không tìm thấy chuyến đi");
                            return;
                        }
                    }
                    else if (list.Count == 2)
                    {

                        MessageBox.Show("Mời bạn đặt vé cho chuyến đi:");
                        int ListId1 = list[0].TripId;
                        decimal Price = list[0].Price;
                        ReserveTicket ins1 = new(list[0],1);
                        ins1.ShowDialog();

                        MessageBox.Show("Mời bạn đặt vé cho chuyến về:");
                        int ListId2 = list[1].TripId;

                        ReserveTicket ins2 = new(list[1],1);
                        ins2.ShowDialog();

                    }
                    else { MessageBox.Show("WTF???"); }
                }
                else
                {
                    MessageBox.Show("Mời bạn đặt vé cho chuyến đi:");
                    int ListId = list[0].TripId;
                    decimal Price = list[0].Price;
                    ReserveTicket ins1 = new(list[0],1);
                    ins1.ShowDialog();
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
        public decimal Price { get; set; }
        public Trips(int tripId, string? tripName, string? departLocation, string? arrivalLocation, string? departureDate, int? status, string? plate, decimal price)
        {
            TripId = tripId;
            TripName = tripName;
            DepartLocation = departLocation;
            ArrivalLocation = arrivalLocation;
            DepartureDate = departureDate;
            Status = status;
            this.Plate = plate;
            this.Price = price;
        }
    }




}
