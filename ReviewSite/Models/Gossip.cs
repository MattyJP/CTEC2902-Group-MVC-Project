using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewSite.Models
{
    public class Category
    {
        public virtual int FilmId { get; set; }
        public virtual string FilmName { get; set; }
        public virtual string Genre { get; set; }
    }
    public class Gossip
    {
        public virtual int FilmId { get; set; }
        public virtual string FilmName { get; set; }
        public virtual string Genre { get; set; }
        public virtual string Gossip { get; set; }
    }
}