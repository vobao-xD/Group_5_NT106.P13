using Client.Controller;
using Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        private AuthToken _authToken;
        private UserInfo _userInfo;
        public Home(UserInfo userInfo, AuthToken authToken)
        {
            InitializeComponent();
            DisplayUserInfo(userInfo);
            _authToken = authToken; // dùng biến auth token này để tiếp tục làm việc
            _userInfo = userInfo;
        }
        private void DisplayUserInfo(UserInfo userInfo)
        {
            try
            {
                var username = userInfo.FullName;
                var email = userInfo.UserEmail;
                labelUsername.Text = $"Welcome, {username}";
                labelUserEmail.Text = $"Your Email: {email}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void labelLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged Out!");
            this.Close();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            Support support = new Support(_userInfo);
            support.ShowDialog();
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
                //MessageBox.Show(encode);

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8002");


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
                        ReserveTicket ins1 = new(list[0], _userInfo, _authToken);
                        ins1.ShowDialog();

                        MessageBox.Show("Mời bạn đặt vé cho chuyến về:");
                        int ListId2 = list[1].TripId;

                        ReserveTicket ins2 = new(list[1], _userInfo, _authToken);
                        ins2.ShowDialog();

                    }
                    else { MessageBox.Show("How???"); }
                }
                else
                {
                    MessageBox.Show("Mời bạn đặt vé cho chuyến đi:");
                    int ListId = list[0].TripId;
                    ReserveTicket ins1 = new(list[0], _userInfo, _authToken);
                    ins1.ShowDialog();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void DepartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnTicketSearch_Click(object sender, EventArgs e)
        {
            TicketInfor ticketInfor = new TicketInfor();
            ticketInfor.ShowDialog();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            Schedule schedule = new Schedule();
            schedule.ShowDialog();
        }

        private void btnContact_Click_1(object sender, EventArgs e)
        {
            Support support = new Support(_userInfo);
            support.ShowDialog();
        }
    }

    public class Trips
    {
        public int TripId { get; set; }
        public int? BusId { get; set; }
        public string? Plate { get; set; }
        public string? DepartLocation { get; set; }
        public string? ArrivalLocation { get; set; }
        public string? DepartureDate { get; set; }

        public Trips(int tripId, int busId, string? departLocation, string? arrivalLocation, string? departureDate, int? status, string? plate)
        {
            TripId = tripId;
            BusId = busId;
            DepartLocation = departLocation;
            ArrivalLocation = arrivalLocation;
            DepartureDate = departureDate;
            Plate = plate;
        }
    }




}
