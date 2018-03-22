using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReviewSite_Views.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        
        public string Genre { get; set; }
    }
}