using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewSite_Views.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }
}