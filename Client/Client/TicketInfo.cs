﻿using Client.Model;
using MimeKit.Cryptography;

namespace Client
{
    public partial class TicketInfo : Form
    {
        private readonly UserController _userController;
        private TicketInfoModel2 _ticketInfo;
        private UserInfo _userInfo;

        public TicketInfo(UserInfo userInfo)
        {
            InitializeComponent();
            _userController = new UserController(new HttpClient());
            _userInfo = userInfo;
        }

        private async void LoadDataAsync()
        {
            flowLayoutPanel_TicketInfo.Controls.Clear();
            if (string.IsNullOrWhiteSpace(txtTicketCode.Text))
            {
                MessageBox.Show("Please enter a valid Ticket Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtTicketCode.Text, out int ticketCode))
            {
                MessageBox.Show("Invalid Ticket Code format. Please enter a numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var response = await _userController.GetTicketInfoAsync(_userInfo.UserEmail, ticketCode);
                if (response != null)
                {
                    if (response.TicketId != -1)
                    {
                        _ticketInfo = response;
                        DisplayTicketInfo();
                    }
                    else
                    {
                        MessageBox.Show("Ticket not found or you don't have permission to access it", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Ticket not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading ticket data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDataAsync();
        }

        private void DisplayTicketInfo()
        {
            flowLayoutPanel_TicketInfo.Controls.Clear();

            if (_ticketInfo != null)
            {
                var panel = AddInfoPanel(_ticketInfo);
                flowLayoutPanel_TicketInfo.Controls.Add(panel);
            }
            else
            {
                var lblNoData = new Label
                {
                    Text = "No trips found.",
                    AutoSize = true,
                    ForeColor = Color.Red
                };
                flowLayoutPanel_TicketInfo.Controls.Add(lblNoData);
            }
        }

        private Panel AddInfoPanel(TicketInfoModel2 ticket)
        {
            Panel panel = new Panel
            {
                Size = new Size(447, 345),
                BackColor = Color.Bisque,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(75),
                Padding = new Padding(0),
                Cursor = Cursors.Hand
            };

            TableLayoutPanel innerPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 8,
                AutoSize = true,
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.None,
            };

            //innerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            //innerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            Label lblFullName = new Label
            {
                Text = "User Fullname: " + ticket.UserFullName,
                AutoSize = true,
                ForeColor = Color.Blue,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            innerPanel.Controls.Add(lblFullName, 0, 0);

            Label lblTicketId = new Label
            {
                Text = "Ticket ID: " + ticket.TicketId,
                AutoSize = true,
                ForeColor = Color.Orange,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            innerPanel.Controls.Add(lblTicketId, 0, 1);

            Label lblTripId = new Label
            {
                Text = "Trip ID: " + ticket.TripId,
                AutoSize = true,
                ForeColor = Color.Green,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            innerPanel.Controls.Add(lblTripId, 0, 2);

            Label lblPlateNumber = new Label
            {
                Text = "Plate Number: " + ticket.PlateNumber,
                AutoSize = true,
                ForeColor = Color.Purple,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            innerPanel.Controls.Add(lblPlateNumber, 0, 3);

            Label lblDepartLocation = new Label
            {
                Text = "Depart Location: " + ticket.DepartLocation,
                AutoSize = true,
                ForeColor = Color.DarkRed,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            innerPanel.Controls.Add(lblDepartLocation, 0, 4);

            Label lblArriveLocation = new Label
            {
                Text = "Arrive Location: " + ticket.ArriveLocation,
                AutoSize = true,
                ForeColor = Color.Brown,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            innerPanel.Controls.Add(lblArriveLocation, 0, 5);

            Label lblDepartTime = new Label
            {
                Text = "Depart Time: " + ticket.DepartTime.ToString("g"),
                AutoSize = true,
                ForeColor = Color.DarkMagenta,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            innerPanel.Controls.Add(lblDepartTime, 0, 6);

            string seatIds = ticket.SeatList != null && ticket.SeatList.Count > 0
                ? string.Join(", ", ticket.SeatList)
                : "N/A";
            Label lblSeatIds = new Label
            {
                Text = "Seat IDs: " + seatIds,
                AutoSize = true,
                ForeColor = Color.Teal,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            innerPanel.Controls.Add(lblSeatIds, 0, 7);

            panel.Controls.Add(innerPanel);
            flowLayoutPanel_TicketInfo.Controls.Add(panel);

            return panel;
        }
    }
}
