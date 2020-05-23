using System;
using System.Collections.Generic;
using System.Text;

namespace KickyBall.BLL.DTOs
{
    public class RoundStats
    {
        public int RoundId { get; set; }
        public bool Practice { get; set; }
        public IEnumerable<string> GoalAttemptRouteNames { get; set; }
    }
}
