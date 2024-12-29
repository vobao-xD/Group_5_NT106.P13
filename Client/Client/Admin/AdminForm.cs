using Client.Model;
using Org.BouncyCastle.Asn1.X509;

namespace Client
{
    public partial class AdminForm : Form
    {
        public UserInfo _userInfo;
        public AuthToken _authToken;

        public static AdminForm? adf;
        Admin_Add_Trip_Bus? aats;
        Admin_BusAnalyse? aba;
        Admin_ListCustomer? alc;
        Admin_Email_Support? aes;
        Admin_ReadMail? arm;
        Admin_SeeSeatBooked? assb;
        Admin_Send_Email? ase;

        public AdminForm(UserInfo userInfo, AuthToken authToken)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _authToken = authToken;
            adf = this;
            if (aes == null)
            {
                aes = new Admin_Email_Support();
                aes.FormClosed += Aes_FormClosed;
                aes.MdiParent = this;
                aes.Dock = DockStyle.Fill;
                aes.Show();
            }
            else { aes.Activate(); }
        }

        public void OpenReadMailForm(string subject, string from, string to, string body, bool isHtml)
        {
            if (arm == null)
            {
                arm = new Admin_ReadMail(subject, from, to, body, isHtml);
                arm.FormClosed += Arm_FormClosed;
                arm.MdiParent = this;
                arm.Dock = DockStyle.Fill;
                arm.Show();
            }
            else { arm.Activate(); }
        }

        private void Arm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            arm = null;
        }

        public void OpenSendMailForm()
        {
            if (ase == null)
            {
                ase = new Admin_Send_Email();
                ase.FormClosed += Ase_FormClosed;
                ase.MdiParent = this;
                ase.Dock = DockStyle.Fill;
                ase.Show();
            }
            else { ase.Activate(); }
        }

        private void Ase_FormClosed(object? sender, FormClosedEventArgs e)
        {
            ase = null;
        }

        public void OpenSeeSeatBookForm(int busId)
        {
            if (assb == null)
            {
                assb = new Admin_SeeSeatBooked(busId);
                assb.FormClosed += Assb_FormClosed;
                assb.MdiParent = this;
                assb.Dock = DockStyle.Fill;
                assb.Show();
            }
            else { assb.Activate(); }
        }

        private void Assb_FormClosed(object? sender, FormClosedEventArgs e)
        {
            assb = null;
        }

        public void Aes_FormClosed(object? sender, FormClosedEventArgs e)
        {
            aes = null;
        }

        public void btnContact_Click(object sender, EventArgs e)
        {
            if (aes == null)
            {
                aes = new Admin_Email_Support();
                aes.FormClosed += Aes_FormClosed;
                aes.MdiParent = this;
                aes.Dock = DockStyle.Fill;
                aes.Show();
            }
            else { aes.Activate(); }
        }

        public void btnListCustomer_Click(object sender, EventArgs e)
        {
            if (alc == null)
            {
                alc = new Admin_ListCustomer();
                alc.FormClosed += Alc_FormClosed;
                alc.MdiParent = this;
                alc.Dock = DockStyle.Fill;
                alc.Show();
            }
            else { alc.Activate(); }
        }

        public void Alc_FormClosed(object? sender, FormClosedEventArgs e)
        {
            alc = null;
        }

        public void btnAddTrip_Click(object sender, EventArgs e)
        {
            if (aats == null)
            {
                aats = new Admin_Add_Trip_Bus();
                aats.FormClosed += Aats_FormClosed;
                aats.MdiParent = this;
                aats.Dock = DockStyle.Fill;
                aats.Show();
            }
            else { aats.Activate(); }
        }

        public void Aats_FormClosed(object? sender, FormClosedEventArgs e)
        {
            aats = null;
        }

        public void btnAnalyse_Click(object sender, EventArgs e)
        {
            if (aba == null)
            {
                aba = new Admin_BusAnalyse();
                aba.FormClosed += Aba_FormClosed;
                aba.MdiParent = this;
                aba.Dock = DockStyle.Fill;
                aba.Show();
            }
            else { aba.Activate(); }
        }

        public void Aba_FormClosed(object? sender, FormClosedEventArgs e)
        {
            aba = null;
        }
    }
}
