﻿using System;
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
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public List<Round> Rounds { get; set; }
    }
}