using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class AuthToken
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Message { get; set; }
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
    }
}
