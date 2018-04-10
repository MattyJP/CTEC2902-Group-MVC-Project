using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReviewSite.Models
{
    public class News
    {
        public virtual int NewsId { get; set; }
        [Required]
        //Display the date of birth in date format only
        [Display(Name = "Date of Publish")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime DateOfPublish { get; set; }
        [Required]
        [Display(Name = "Revated Film")]
        public virtual string RevatedFilm { get; set; }
        public virtual string Headline { get; set; }
        public virtual string Story { get; set; }
    }
}