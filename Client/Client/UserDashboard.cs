using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Model;

namespace Client
{
    public partial class UserDashboard : Form
    {
        Home? home;
        Support? support;
        TicketInfo? ticketInfor;

        private AuthToken _authToken;
        private UserInfo _userInfo;

        public UserDashboard(UserInfo userInfo, AuthToken authToken)
        {
            InitializeComponent();
            labelUsername.Text = $"Welcome, {userInfo.FullName}";
            labelUserEmail.Text = $"Your Email: {userInfo.UserEmail}";
            _userInfo = userInfo;
            _authToken = authToken;
            if (home == null)
            {
                home = new Home(_userInfo, _authToken);
                home.FormClosed += Home_FormClosed;
                home.MdiParent = this;
                home.Dock = DockStyle.Fill;
                home.Show();
            }
            else { home.Activate(); }
        }

        private void Home_FormClosed(object? sender, FormClosedEventArgs e)
        {
            home = null;
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            if (support == null)
            {
                support = new Support(_userInfo);
                support.FormClosed += Support_FormClosed;
                support.MdiParent = this;
                support.Dock = DockStyle.Fill;
                support.Show();
            }
            else { support.Activate(); }
        }

        private void Support_FormClosed(object? sender, FormClosedEventArgs e)
        {
            support = null;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (home == null)
            {
                home = new Home(_userInfo, _authToken);
                home.FormClosed += Home_FormClosed;
                home.MdiParent = this;
                home.Dock = DockStyle.Fill;
                home.Show();
            }
            else { home.Activate(); }
        }

        private void btnTicketSearch_Click(object sender, EventArgs e)
        {
            if (ticketInfor == null)
            {
                ticketInfor = new TicketInfo();
                ticketInfor.FormClosed += TicketInfor_FormClosed;
                ticketInfor.MdiParent = this;
                ticketInfor.Dock = DockStyle.Fill;
                ticketInfor.Show();
            }
            else { ticketInfor.Activate(); }
        }

        private void TicketInfor_FormClosed(object? sender, FormClosedEventArgs e)
        {
            ticketInfor = null;
        }

        private void UserDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
