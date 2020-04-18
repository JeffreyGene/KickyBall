using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KickyBall.DAL.Models
{
    [Table("Moves", Schema = "KickyBall")]
    public class Move
    {
        public int MoveId { get; set; }
        public int GoalAttemptId { get; set; }
        public GoalAttempt GoalAttempt { get; set; }
        public int Ordinal { get; set; }
        public int DirectionId { get; set; }
        public Direction Direction { get; set; }
    }
}
