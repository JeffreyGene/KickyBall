using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KickyBall.DAL.Models
{
    [Table("RfCountToRouteAndGame", Schema = "KickyBall")]
    public class RfCountToRouteAndGame
    {
        public int RfCountToRouteAndGameId { get; set; }
        public double Value { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
