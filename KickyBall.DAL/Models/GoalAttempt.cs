using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KickyBall.DAL.Models
{
    [Table("GoalAttempts", Schema = "KickyBall")]
    public class GoalAttempt
    {
        public int GoalAttemptId { get; set; }
        public int RoundId { get; set; }
        public Round Round { get; set; }
        public bool ScoredGoal { get; set; }
        public int Ordinal { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public List<Move> Moves { get; set; }
    }
}
