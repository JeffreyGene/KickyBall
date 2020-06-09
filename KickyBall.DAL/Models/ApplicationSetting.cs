using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KickyBall.DAL.Models
{
    [Table("ApplicationSettings", Schema = "KickyBall")]
    public class ApplicationSetting
    {
        [Key]
        [StringLength(10)]
        public string ApplicationSettingCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Value { get; set; }
        public bool Enabled { get; set; }
    }
}
