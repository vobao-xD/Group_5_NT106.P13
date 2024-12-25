using Client.Controller;
using Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Admin
{
    public partial class Admin_BusAnalyse : Form
    {
        private HttpClient _httpClient;
        private BusController _busController;
        private List<BusInfo> _busList;
        private List<TripInfo> _tripList;
        public Admin_BusAnalyse()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _busController = new BusController(_httpClient);
            LoadDataAsync();
        }
        private async void LoadDataAsync()
        {
            try
            {
                if (_tripList != null) _tripList.Clear();
                if (_busList != null) _busList.Clear();

                var tripTask = _busController.GetAllTripsAsync();
                var busTask = _busController.GetAllBusAsync();

                _tripList = await tripTask;
                _busList = await busTask;

                DisplayTripList();
                DisplayBusList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private Panel CreateBusPanel(BusInfo busInfo)
        {
            Panel panel = new Panel();
            panel.Size = new Size(500, 100);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(10, 10, 10, 10);
            panel.Padding = new Padding(10, 10, 10, 10);
            panel.Cursor = Cursors.Hand;
            panel.Click += (sender, e) =>
            {
                var result = MessageBox.Show($"Bạn có muốn xem thông tin ghế của: {busInfo.LicensePlate} hay không?", "Analyse Number of Seats is booked", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    AnalyseNumOfSeat(busInfo.BusId);
                }
            };
            Label lblBusId = new Label
            {
                Text = "Bus ID: " + busInfo.BusId,
                Location = new Point(10, 10),
                AutoSize = true,
                ForeColor = Color.Blue
            };
            panel.Controls.Add(lblBusId);

            Label lblLicensePlate = new Label
            {
                Text = "License Plate: " + busInfo.LicensePlate,
                Location = new Point(10, 40),
                AutoSize = true,
                ForeColor = Color.Orange
            };
            panel.Controls.Add(lblLicensePlate);
             
            Label lblSeatNum = new Label
            {
                Text = "Number of Seats: " + busInfo.SeatNum,
                Location = new Point(10, 70),
                AutoSize = true,
                ForeColor = Color.Green
            };
            panel.Controls.Add(lblSeatNum);

            return panel;
        }

        private Panel CreateTripPanel(TripInfo tripInfo)
        {
            Panel panel = new Panel
            {
                Size = new Size(500, 200), 
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                Padding = new Padding(10),
                Cursor = Cursors.Hand
            };

            Label lblTripId = new Label
            {
                Text = "Trip ID: " + tripInfo.TripId,
                Location = new Point(10, 10),
                AutoSize = true,
                ForeColor = Color.MidnightBlue, 
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            panel.Controls.Add(lblTripId);

            Label lblDepartLocation = new Label
            {
                Text = "Depart Location: " + tripInfo.DepartLocation,
                Location = new Point(10, 40),
                AutoSize = true,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Arial", 9)
            };
            panel.Controls.Add(lblDepartLocation);

            Label lblArriveLocation = new Label
            {
                Text = "Arrive Location: " + tripInfo.ArriveLocation,
                Location = new Point(10, 70),
                AutoSize = true,
                ForeColor = Color.Teal,
                Font = new Font("Arial", 9)
            };
            panel.Controls.Add(lblArriveLocation);

            Label lblDepartTime = new Label
            {
                Text = "Depart Time: " + tripInfo.DepartTime.ToString("yyyy-MM-dd HH:mm"),
                Location = new Point(10, 100),
                AutoSize = true,
                ForeColor = Color.DarkGreen,
                Font = new Font("Arial", 9)
            };
            panel.Controls.Add(lblDepartTime);

            Label lblTripStatusId = new Label
            {
                Text = "Trip Status ID: " + tripInfo.TripStatusId,
                Location = new Point(10, 130),
                AutoSize = true,
                ForeColor = Color.Indigo,
                Font = new Font("Arial", 9)
            };
            panel.Controls.Add(lblTripStatusId);

            Label lblTripStatusName = new Label
            {
                Text = "Trip Status Name: " + tripInfo.TripStatusName,
                Location = new Point(10, 160),
                AutoSize = true,
                ForeColor = Color.SteelBlue,
                Font = new Font("Arial", 9)
            };
            panel.Controls.Add(lblTripStatusName);

            return panel;
        }



        private void AnalyseNumOfSeat(int busId)
        {
            Admin_SeeSeatBooked admin_SeeSeatBooked = new Admin_SeeSeatBooked(busId);
            admin_SeeSeatBooked.Show();
        }

        private void DisplayBusList()
        {
            try
            {
                flowLayoutPanelBus.Controls.Clear();

                if (_busList != null && _busList.Count > 0)
                {
                    foreach (BusInfo busInfo in _busList)
                    {
                        Panel panel = CreateBusPanel(busInfo);
                        flowLayoutPanelBus.Controls.Add(panel);
                    }
                }
                else
                {
                    Label lblNoData = new Label
                    {
                        Text = "No buses found.",
                        AutoSize = true,
                        ForeColor = Color.Red
                    };
                    
                    flowLayoutPanelBus.Controls.Add(lblNoData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DisplayTripList()
        {
            flowLayoutPanelTrip.Controls.Clear();

            if (_tripList != null && _tripList.Count > 0)
            {
                foreach (var trip in _tripList)
                {
                    var panel = CreateTripPanel(trip);
                    flowLayoutPanelTrip.Controls.Add(panel);
                }
            }
            else
            {
                var lblNoData = new Label
                {
                    Text = "No trips found.",
                    AutoSize = true,
                    ForeColor = Color.Red
                };
                flowLayoutPanelTrip.Controls.Add(lblNoData);
            }
        }
    }
}
