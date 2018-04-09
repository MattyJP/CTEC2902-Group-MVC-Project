using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReviewSite.Models
{
    public class ExpandedUserViewModel
    {
        //Creates a data transfer object to pass role data through the controller to the view
        [Key]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //Allows the end date of a lockout period to be identified after multiple failed login attempts by a user
        [Display(Name = "Lockout End Date GMT")]
        public DateTime? LockoutEndDateGMT { get; set; }
        public int AccessFailedCount { get; set; }
        public string PhoneNumber { get; set; }
        //Gets the role from the role view model
        public IEnumerable<UserRolesViewModel> Roles { get; set; }
    }

    public class UserRolesViewModel
    {
        //Passes the Role type to the view
        [Key]
        [Display(Name = "Role Type")]
    public string RoleType { get; set; }
    }

    public class UserRoleViewModel
    {
        //Passes the Username and Role type to the view
        [Key]
        [Display(Name = "Username")]
    public string UserName { get; set; }
        [Key]
        [Display(Name = "Role Type")]
    public string RoleType { get; set; }
    }

    public class RoleViewModel
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "Role Type")]
        public string RoleType { get; set; }
    }

    public class UserAndRolesViewModel
    {
        [Key]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        public List<UserRoleViewModel> colUserRoleViewModel { get; set; }
    }
}