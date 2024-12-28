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

namespace Client
{
    public partial class Schedule : Form
    {
        private readonly UserController _userController;
        private List<TripInfo> tripInfos;
        public Schedule()
        {
            InitializeComponent();
            _userController = new UserController(new HttpClient());
        }

        private async void LoadDataAsync()
        {
            if (string.IsNullOrWhiteSpace(cmbBoxDeparture.Text) || string.IsNullOrWhiteSpace(cmbBoxDestination.Text))
            {
                MessageBox.Show("Please enter both Depart Location and Arrive Location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var trips = await _userController.GetTripByLocationAsync(cmbBoxDeparture.Text.Trim(), cmbBoxDestination.Text.Trim());

                if (trips != null && trips.Count > 0)
                {
                    tripInfos = trips;
                    DisplayTrips();
                }
                else
                {
                    MessageBox.Show("No trips found for the specified locations.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading trip data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDataAsync();
        }

        private void DisplayTrips()
        {
            flowLayoutPanel_Trips.Controls.Clear();

            if (tripInfos != null && tripInfos.Count > 0)
            {
                foreach (var trip in tripInfos)
                {
                    var panel = AddInfoPanel(trip);
                    flowLayoutPanel_Trips.Controls.Add(panel);
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
                flowLayoutPanel_Trips.Controls.Add(lblNoData);
            }
        }

        private Panel AddInfoPanel(TripInfo trip)
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

            TableLayoutPanel innerPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 6,
                AutoSize = true
            };

            innerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            innerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            Label lblTripId = new Label
            {
                Text = "Trip ID: " + trip.TripId,
                AutoSize = true,
                ForeColor = Color.Orange,
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            innerPanel.Controls.Add(lblTripId, 0, 0);

            Label lblPlate = new Label
            {
                Text = "Plate Number: " + trip.Plate,
                AutoSize = true,
                ForeColor = Color.Green,
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            innerPanel.Controls.Add(lblPlate, 0, 1);

            Label lblDepartLocation = new Label
            {
                Text = "Depart Location: " + trip.DepartLocation,
                AutoSize = true,
                ForeColor = Color.Blue,
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            innerPanel.Controls.Add(lblDepartLocation, 0, 2);

            Label lblArriveLocation = new Label
            {
                Text = "Arrive Location: " + trip.ArriveLocation,
                AutoSize = true,
                ForeColor = Color.Purple,
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            innerPanel.Controls.Add(lblArriveLocation, 0, 3);

            Label lblDepartTime = new Label
            {
                Text = "Depart Time: " + trip.DepartTime.ToString("g"),
                AutoSize = true,
                ForeColor = Color.DarkRed,
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            innerPanel.Controls.Add(lblDepartTime, 0, 4);

            Label lblTripStatus = new Label
            {
                Text = "Status: " + trip.TripStatusName,
                AutoSize = true,
                ForeColor = Color.Teal,
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            innerPanel.Controls.Add(lblTripStatus, 0, 5);

            panel.Controls.Add(innerPanel);
            return panel;
        }

    }
}
