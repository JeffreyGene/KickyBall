using System;
using System.Collections.Generic;
using System.Text;

namespace KickyBall.BLL.DTOs
{
    public class AuthenticatedUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }
}
