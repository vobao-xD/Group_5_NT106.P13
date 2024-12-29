using Client.Model;

namespace Client
{
    public partial class UserDashboard : Form
    {
        Home? home;
        Support? support;
        TicketInfo? ticketinfo;
        ReserveTicket? reserveticket;

        public static UserDashboard? udb;

        private AuthToken _authToken;
        private UserInfo _userInfo;

        public UserDashboard(UserInfo userInfo, AuthToken authToken)
        {
            InitializeComponent();
            udb = this;
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

        public void OpenReserseTicket(Trips trip, UserInfo userInfo, AuthToken authToken)
        {
            if (reserveticket == null)
            {
                reserveticket = new ReserveTicket(trip, userInfo, authToken);
                reserveticket.FormClosed += Reserveticket_FormClosed;
                reserveticket.MdiParent = this;
                reserveticket.Dock = DockStyle.Fill;
                reserveticket.Show();
            } else {  reserveticket.Activate(); }
        }

        private void Reserveticket_FormClosed(object? sender, FormClosedEventArgs e)
        {
            reserveticket = null;
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
            if (ticketinfo == null)
            {
                ticketinfo = new TicketInfo(_userInfo);
                ticketinfo.FormClosed += Ticketinfo_FormClosed;
                ticketinfo.MdiParent = this;
                ticketinfo.Dock = DockStyle.Fill;
                ticketinfo.Show();
            }
            else { ticketinfo.Activate(); }
        }

        private void Ticketinfo_FormClosed(object? sender, FormClosedEventArgs e)
        {
            ticketinfo = null;
        }

        private void UserDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
