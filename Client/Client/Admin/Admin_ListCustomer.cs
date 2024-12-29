using Client.Model;

namespace Client
{
    public partial class Admin_ListCustomer : Form
    {
        private HttpClient _httpClient;
        private UserController _userController;
        private List<CustomerInfo> _customerRegularList;
        private List<CustomerInfo> _customerVIPList;
        public Admin_ListCustomer()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _userController = new UserController(_httpClient);
            LoadDataAsync();
        }
        private async void LoadDataAsync()
        {
            try
            {
                if (_customerRegularList != null && _customerRegularList.Count > 0) { _customerRegularList.Clear(); }
                if (_customerVIPList != null && _customerVIPList.Count > 0) { _customerVIPList.Clear(); }

                var resultRegular = _userController.CustomerInfoAsync(3);
                _customerRegularList = await resultRegular;

                var resultVIP = _userController.CustomerInfoAsync(4);
                _customerVIPList = await resultVIP;
                DisplayCustomerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private Panel CreateCustomerPanelVIP(CustomerInfo customerInfo)
        {
            Panel panel = new Panel();
            panel.Size = new Size(500, 125);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(10, 10, 10, 10);
            panel.Padding = new Padding(10, 10, 10, 10);
            panel.Cursor = Cursors.Hand;
            panel.Click += (sender, e) =>
            {
                var result = MessageBox.Show($"Bạn có muốn thay đổi khách hàng: {customerInfo.FullName} trở thành Regular hay không?", "Upgrade to VIP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Code to upgrade customer to regular
                    UpgradeCustomerToRegular(customerInfo.UserId);
                }
            };
            Label lblUserId = new Label
            {
                Text = "Customer ID: " + customerInfo.UserId,
                Location = new Point(10, 10),
                AutoSize = true,
                ForeColor = Color.Blue
            };
            panel.Controls.Add(lblUserId);
            Label lblName = new Label
            {
                Text = "Name: " + customerInfo.FullName,
                Location = new Point(10, 40),
                AutoSize = true,
                ForeColor = Color.Orange
            };
            panel.Controls.Add(lblName);
            Label lblEmail = new Label
            {
                Text = "Email: " + customerInfo.UserEmail,
                Location = new Point(10, 70),
                AutoSize = true,
                ForeColor = Color.Green
            };
            panel.Controls.Add(lblEmail);
            return panel;
        }

        private async void UpgradeCustomerToRegular(int userId)
        {
            var result = await _userController.UpdateCustomerRegularAsync(userId);
            if (result.Id == 1)
            {
                MessageBox.Show("Chuyển đổi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataAsync();
            }
            else
            {
                MessageBox.Show("Chuyển đổi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateCustomerPanelRegular(CustomerInfo customerInfo)
        {
            Panel panel = new Panel();
            panel.Size = new Size(500, 125);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(10, 10, 10, 10);
            panel.Padding = new Padding(10, 10, 10, 10);
            panel.Cursor = Cursors.Hand;
            panel.Click += (sender, e) =>
            {
                var result = MessageBox.Show($"Bạn có muốn nâng cấp khách hàng: {customerInfo.FullName} lên VIP hay không?", "Upgrade to VIP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Code to upgrade customer to VIP
                    UpgradeCustomerToVIP(customerInfo.UserId);
                }
            };
            Label lblUserId = new Label
            {
                Text = "Customer ID: " + customerInfo.UserId,
                Location = new Point(10, 10),
                AutoSize = true,
                ForeColor = Color.Blue
            };
            panel.Controls.Add(lblUserId);
            Label lblName = new Label
            {
                Text = "Name: " + customerInfo.FullName,
                Location = new Point(10, 40),
                AutoSize = true,
                ForeColor = Color.Orange
            };
            panel.Controls.Add(lblName);
            Label lblEmail = new Label
            {
                Text = "Email: " + customerInfo.UserEmail,
                Location = new Point(10, 70),
                AutoSize = true,
                ForeColor = Color.Green
            };
            panel.Controls.Add(lblEmail);
            return panel;
        }

        private async void UpgradeCustomerToVIP(int userId)
        {
            var result = await _userController.UpdateCustomerVIPAsync(userId);
            if (result.Id == 1)
            {
                MessageBox.Show("Nâng cấp khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataAsync();
            }
            else
            {
                MessageBox.Show("Nâng cấp khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCustomerList()
        {
            try
            {
                flowLayoutPanelRegular.Controls.Clear();
                flowLayoutPanelVIP.Controls.Clear();

                if (_customerRegularList != null && _customerRegularList.Count > 0)
                {
                    foreach (CustomerInfo customerInfo in _customerRegularList)
                    {
                        Panel panel = CreateCustomerPanelRegular(customerInfo);
                        flowLayoutPanelRegular.Controls.Add(panel);
                    }
                }
                else
                {
                    Label lblNoData = new Label
                    {
                        Text = "No regular customers found.",
                        AutoSize = true,
                        ForeColor = Color.Red
                    };
                    flowLayoutPanelRegular.Controls.Add(lblNoData);
                }

                if (_customerVIPList != null && _customerVIPList.Count > 0)
                {
                    foreach (CustomerInfo customerInfo in _customerVIPList)
                    {
                        Panel panel = CreateCustomerPanelVIP(customerInfo);
                        flowLayoutPanelVIP.Controls.Add(panel);
                    }
                }
                else
                {
                    Label lblNoData = new Label
                    {
                        Text = "No VIP customers found.",
                        AutoSize = true,
                        ForeColor = Color.Red
                    };
                    flowLayoutPanelVIP.Controls.Add(lblNoData);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
