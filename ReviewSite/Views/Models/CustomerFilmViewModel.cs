using ReviewSite_Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewSite.Models
{
    public class CustomerFilmViewModel
    {
        public Film Film { get; set; }
        public Customer Customer { get; set; }

    }
}