using System;
using System.Collections.Generic;
using System.Text;

namespace KickyBall.BLL.DTOs
{
    public class AdminPageUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool GameFinished { get; set; }
    }
}
