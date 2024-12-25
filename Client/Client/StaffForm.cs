using Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class StaffForm : Form
    {
        private UserInfo _userInfo;
        private AuthToken _authToken;
        public StaffForm(UserInfo userInfo, AuthToken authToken)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _authToken = authToken;
        }
    }
}
