using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReviewSite.Models
{
    public class Actor
    {
        public virtual int ActorId { get; set; }
        public virtual string Name { get; set; }
        [Required]
        //Display the date of birth in date format only
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Actor Summmary")]
        public virtual string ActorSummary { get; set; }
    }
}