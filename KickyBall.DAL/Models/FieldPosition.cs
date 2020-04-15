using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KickyBall.DAL.Models
{
    [Table("FieldPositions", Schema = "KickyBall")]
    public class FieldPosition
    {
        public int FieldPositionId { get; set; }

        public int? LeftFieldPositionId { get; set; }

        public int? RightFieldPositionId { get; set; }
    }
}
