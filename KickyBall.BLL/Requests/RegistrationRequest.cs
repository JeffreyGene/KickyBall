using System;
using System.Collections.Generic;
using System.Text;

namespace KickyBall.BLL.Requests
{
    public class RegistrationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RegistrationCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
