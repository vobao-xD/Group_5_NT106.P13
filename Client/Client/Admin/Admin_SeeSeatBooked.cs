using Client.Model;

namespace Client
{
    public partial class Admin_SeeSeatBooked : Form
    {
        private int _busId;
        private HttpClient _httpClient;
        private BusController _busController;
        private List<GetSeatBookedModel> _getSeatBooked;
        private List<GetSeatBookedModel> _getSeatNotBooked;
        public Admin_SeeSeatBooked(int busId)
        {
            InitializeComponent();
            _busId = busId;
            _httpClient = new HttpClient();
            _busController = new BusController(_httpClient);
            LoadDataAsync();
        }
        private async void LoadDataAsync()
        {
            try
            {
                if (_getSeatBooked != null && _getSeatBooked.Count > 0) { _getSeatBooked.Clear(); }
                if (_getSeatNotBooked != null && _getSeatNotBooked.Count > 0) { _getSeatNotBooked.Clear(); }

                var resultBooked = _busController.GetSeatBookedsAsync(_busId, 1);
                _getSeatBooked = await resultBooked;

                var resultNotBooked = _busController.GetSeatBookedsAsync(_busId, 0);
                _getSeatNotBooked = await resultNotBooked;
                DisplaySeat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DisplaySeat()
        {
            try
            {
                flowLayoutPanelBooked.Controls.Clear();
                flowLayoutPanelNotBook.Controls.Clear();

                //booked
                if (_getSeatBooked != null && _getSeatBooked.Count > 0)
                {
                    foreach (GetSeatBookedModel getSeatBookedModel in _getSeatBooked)
                    {
                        Panel panel = CreateSeatBookedPanel(getSeatBookedModel);
                        flowLayoutPanelBooked.Controls.Add(panel);
                    }
                }
                else
                {
                    Label lblNoData = new Label
                    {
                        Text = "No booked Seat found",
                        AutoSize = true,
                        ForeColor = Color.Red
                    };
                    flowLayoutPanelBooked.Controls.Add(lblNoData);
                }

                // haven't booked yet
                if (_getSeatNotBooked != null && _getSeatNotBooked.Count > 0)
                {
                    foreach (GetSeatBookedModel getSeatBookedModel in _getSeatNotBooked)
                    {
                        Panel panel = CreateSeatNotBookedPanel(getSeatBookedModel);
                        flowLayoutPanelNotBook.Controls.Add(panel);
                    }
                }
                else
                {
                    Label lblNoData = new Label
                    {
                        Text = "No Seat found",
                        AutoSize = true,
                        ForeColor = Color.Red
                    };
                    flowLayoutPanelNotBook.Controls.Add(lblNoData);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Panel CreateSeatBookedPanel(GetSeatBookedModel getSeatBookedModel)
        {
            Panel panel = new Panel();
            panel.Size = new Size(500, 100);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(10, 10, 10, 10);
            panel.Padding = new Padding(10, 10, 10, 10);
            panel.Cursor = Cursors.Hand;
            Label lblLicensePlate = new Label
            {
                Text = "License Plate: " + getSeatBookedModel.LicensePlate,
                Location = new Point(10, 10),
                AutoSize = true,
                ForeColor = Color.Blue
            };
            panel.Controls.Add(lblLicensePlate);
            Label lblSeatNum = new Label
            {
                Text = "Seatname: " + getSeatBookedModel.SeatName,
                Location = new Point(10, 40),
                AutoSize = true,
                ForeColor = Color.Orange
            };
            panel.Controls.Add(lblSeatNum);

            Label lblIsBooked = new Label
            {
                Text = "Ghế này đã được đặt",
                Location = new Point(10, 70),
                AutoSize = true,
                ForeColor = Color.Green
            };
            panel.Controls.Add(lblIsBooked);

            return panel;
        }
        private Panel CreateSeatNotBookedPanel(GetSeatBookedModel getSeatBookedModel)
        {
            Panel panel = new Panel();
            panel.Size = new Size(500, 100);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(10, 10, 10, 10);
            panel.Padding = new Padding(10, 10, 10, 10);
            panel.Cursor = Cursors.Hand;
            Label lblLicensePlate = new Label
            {
                Text = "License Plate: " + getSeatBookedModel.LicensePlate,
                Location = new Point(10, 10),
                AutoSize = true,
                ForeColor = Color.Blue
            };
            panel.Controls.Add(lblLicensePlate);
            Label lblSeatNum = new Label
            {
                Text = "Seatname: " + getSeatBookedModel.SeatName,
                Location = new Point(10, 40),
                AutoSize = true,
                ForeColor = Color.Orange
            };
            panel.Controls.Add(lblSeatNum);

            Label lblIsBooked = new Label
            {
                Text = "Ghế này còn trống!",
                Location = new Point(10, 70),
                AutoSize = true,
                ForeColor = Color.Red
            };
            panel.Controls.Add(lblIsBooked);

            return panel;
        }
    }
}
