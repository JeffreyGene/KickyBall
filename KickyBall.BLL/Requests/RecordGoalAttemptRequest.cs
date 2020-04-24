using KickyBall.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KickyBall.BLL.Requests
{
    public class RecordGoalAttemptRequest
    {
        public int SecondsRemaining { get; set; }
        public GoalAttempt GoalAttempt { get; set; }
    }
}
