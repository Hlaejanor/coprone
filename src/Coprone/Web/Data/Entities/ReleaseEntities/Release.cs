using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Data
{
    public class Release
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Version { get; set; }

        [MaxLength(255)]
        public string Contributors { get; set; }

        public string Licence { get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedUtc { get; set; }
    }
}