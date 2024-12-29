using Client.Model;

namespace Client
{
    public partial class AdminForm : Form
    {
        private UserInfo _userInfo;
        private AuthToken _authToken;
        public AdminForm(UserInfo userInfo, AuthToken authToken)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _authToken = authToken;
        }
        private void btnAddTrip_Click(object sender, EventArgs e)
        {
            Admin_Add_Trip_Bus admin_Add_Trip_Bus = new Admin_Add_Trip_Bus();
            admin_Add_Trip_Bus.ShowDialog();
        }

        private void btnListCustomer_Click(object sender, EventArgs e)
        {
            Admin_ListCustomer admin_ListCustomer = new Admin_ListCustomer();
            admin_ListCustomer.Show();
        }

        private void btnAnalyse_Click(object sender, EventArgs e)
        {
            Admin_BusAnalyse admin_BusAnalyse = new Admin_BusAnalyse();
            admin_BusAnalyse.Show();
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            Admin_Email_Support admin_Email_Support = new Admin_Email_Support();
            admin_Email_Support.Show();
        }
    }
}
