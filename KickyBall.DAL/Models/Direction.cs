using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KickyBall.DAL.Models
{
    [Table("Directions", Schema = "KickyBall")]
    public class Direction
    {
        public int DirectionId { get; set; }
        [StringLength(10)]
        public string Name { get; set; }
    }
}
