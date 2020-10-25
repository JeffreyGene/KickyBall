using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KickyBall.DAL.Models
{
    [Table("Games", Schema = "KickyBall")]
    public class Game
    {
        public int GameId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool Finished { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<Round> Rounds { get; set; }
        public List<RfCountToRouteAndGame> RfCountToRouteAndGameList { get; set; }
    }
}
