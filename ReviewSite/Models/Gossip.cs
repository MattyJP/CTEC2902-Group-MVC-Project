using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewSite.Models
{
    public class Gossip
    {
        public virtual int GossipId { get; set; }
        public virtual string FilmName { get; set; }
        public virtual string Genre { get; set; }
        public virtual string GossipText { get; set; }

    }
}