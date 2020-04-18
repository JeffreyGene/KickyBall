using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KickyBall.DAL.Models
{
    [Table("Persons", Schema = "KickyBall")]
    public class Person
    {
        public int PersonId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public List<Game> Games { get; set; }
    }
}
