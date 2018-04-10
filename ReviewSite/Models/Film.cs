using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewSite.Models
{
    public class Film
    {
        public virtual int FilmId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Genre { get; set; }
        public virtual int Rating { get; set; }
    }
}