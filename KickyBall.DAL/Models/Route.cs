using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KickyBall.DAL.Models
{
    [Table("Routes", Schema = "KickyBall")]
    public class Route
    {
        public int RouteId { get; set; }
        [Required]
        [StringLength(5)]
        public string Name { get; set; }
    }
}
