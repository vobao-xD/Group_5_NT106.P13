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

        }

        private void btnListCustomer_Click(object sender, EventArgs e)
        {
            Admin_ListCustomer admin_ListCustomer = new Admin_ListCustomer();
            admin_ListCustomer.Show();
        }
    }
}
