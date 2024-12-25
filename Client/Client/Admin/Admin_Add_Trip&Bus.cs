using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;
using Client.Admin;
using Client.Controller;
using Client.Model;

namespace Client.Admin
{
    public partial class Admin_Add_Trip_Bus : Form
    {
        private readonly BusController _busController;
        private readonly HttpClient _httpClient;
        public Admin_Add_Trip_Bus()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _busController = new BusController(_httpClient);
        }

        private async void btnAddTrip_Click(object sender, EventArgs e)
        {
            try
            {
                string plate = txtPlate.Text.Trim();
                int seatNum = int.Parse(txtSeatNum.Text.Trim());
                int busStatusId = 1;
                string departLocation = cmbBoxDeparture.SelectedItem?.ToString();
                string arriveLocation = cmbBoxDestination.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(departLocation) || string.IsNullOrEmpty(arriveLocation))
                {
                    MessageBox.Show("Vui lòng chọn điểm đi và điểm đến.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime departDate = DepartDate.Value.Date; // Lấy ngày từ DateTimePicker
                string departTime = DepartTime.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(departTime))
                {
                    MessageBox.Show("Vui lòng chọn giờ đi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime departDateTime = DateTime.Parse($"{departDate:yyyy-MM-dd} {departTime}");

                int tripStatusId = 1;

                var result = await _busController.CreateTripAsync(
                    plate: plate,
                    seatNum: seatNum,
                    busStatusId: busStatusId,
                    departLocation: departLocation,
                    arriveLocation: arriveLocation,
                    departTime: departDateTime,
                    tripStatusId: tripStatusId
                );

                MessageBox.Show($"Thành công: {result.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Số chỗ ngồi phải là một số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
