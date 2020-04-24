using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KickyBall.DAL.Models
{
    [Table("Rounds", Schema = "KickyBall")]
    public class Round
    {
        public int RoundId { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int Ordinal { get; set; }
        public bool Finished { get; set; }
        public bool Practice { get; set; }
        public int SecondsRemaining { get; set; }
        public List<GoalAttempt> GoalAttempts { get; set; }
    }
}
