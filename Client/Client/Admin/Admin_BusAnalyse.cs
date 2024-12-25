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
                if (_busList != null && _busList.Count > 0) { _busList.Clear(); }

                var resultRegular = _busController.GetAllBusAsync();
                _busList = await resultRegular;

                DisplayBusList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    // Code to upgrade customer to regular
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
    }
}
