using System;
using System.Collections.Generic;
using System.Text;

namespace KickyBall.BLL.DTOs
{
    public class UserGameStats
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool GameFinished { get; set; }
        public int PracticeGoals { get; set; }
        public int Goals { get; set; }
        public List<RoundStats> RoundStats { get; set; }
    }
}
