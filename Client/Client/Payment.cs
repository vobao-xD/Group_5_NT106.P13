using Client.Model;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client
{
    public partial class Payment : Form
    {
        private Trips _trip;
        private UserInfo _userInfo;
        private AuthToken _authToken;
        private List<string> selectedSeats;
        private long price = 0;
        private int[] basePrice = {200000, 500000 };
        public Payment(Trips trip, UserInfo userInfo, AuthToken authToken, List<string> selectedSeat)
        {
            InitializeComponent();
            _authToken = authToken; // dùng biến auth token này để tiếp tục làm việc
            _userInfo = userInfo;
            _trip = trip;
            selectedSeats = selectedSeat;
            //Compute the price
            foreach (string seat in selectedSeats)
            {
                if (_trip.DepartLocation == "Hà Nội" || _trip.ArrivalLocation == "Hà Nội")
                {
                    price += basePrice[1];
                }
                else
                {
                    price += basePrice[0];
                }
            }
            

            PopulateInfo();
            
            
        }

        private void PopulateInfo()
        {
            try
            {
                string seats = string.Join(",", selectedSeats);
                var format = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
                format.NumberGroupSeparator = " ";

                //txtInfo.Nodes.Clear();
                TreeNode busNode = new TreeNode($"Bus: {_trip.Plate}");

                TreeNode tripNode = new TreeNode($"Trip: {_trip.DepartLocation} → {_trip.ArrivalLocation} at {_trip.DepartureDate}");
                tripNode.Nodes.Add(new TreeNode($"Seats: {seats}"));
                tripNode.Nodes.Add(new TreeNode($"Money: {price.ToString("N0",format)}đ"));

                busNode.Nodes.Add(tripNode);

                MessageBox.Show("Please remember this information");
                
                txtInfo.Nodes.Add(busNode);


                txtInfo.ExpandAll();

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Null Reference Error: {ex}");
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            //Đoạn này hơi khó rồi các ông giáo ạ
            //Momo cho doanh nghiệp cần nhiều thông tin lạ vãi chưởng
            //Có cái nào khác Momo ko anh em?
        }
    }
}
