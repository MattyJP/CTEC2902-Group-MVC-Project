#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using ReviewSite.Models;
using PagedList;

#endregion Includes

namespace ReviewSite.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        // Controllers
        // GET: /Admin/
        [Authorize(Roles = "Administrator")]
        #region public ActionResult Index(string searchStringUserNameOrEmail)
        public ActionResult Index(string searchStringUserNameOrEmail, string currentFilter, int? page)
        {
            try
            {
                int intPage = 1;
                int intPageSize = 5;
                int intTotalPageCount = 0;
                if (searchStringUserNameOrEmail != null)
                {
                    intPage = 1;
                }
                else
                {
                    if (currentFilter != null)
                    {
                        searchStringUserNameOrEmail = currentFilter;
                        intPage = page ?? 1;
                    }
                    else
                    {
                        searchStringUserNameOrEmail = "";
                        intPage = page ?? 1;
                    }
                }
                ViewBag.CurrentFilter = searchStringUserNameOrEmail;

                List<ExpandedUserViewModel> col_UserViewModel = new List<ExpandedUserViewModel>();
                int intSkip = (intPage - 1) * intPageSize;
                intTotalPageCount = UserManager.Users
                    .Where(x => x.UserName.Contains(searchStringUserNameOrEmail))
                    .Count();
                var result = UserManager.Users
                    .Where(x => x.UserName.Contains(searchStringUserNameOrEmail))
                    .OrderBy(x => x.UserName)
                    .Skip(intSkip)
                    .Take(intPageSize)
                    .ToList();
                foreach (var item in result)
                {
                    ExpandedUserViewModel objUserViewModel = new ExpandedUserViewModel();
                    objUserViewModel.UserName = item.UserName;
                    objUserViewModel.Email = item.Email;
                    objUserViewModel.LockoutEndDateGMT = item.LockoutEndDateUtc;
                    col_UserViewModel.Add(objUserViewModel);
                }
                // Set the number of pages
                var _UserViewModelsIPagedList =
                    new StaticPagedList<ExpandedUserViewModel>
                    (
                        col_UserViewModel, intPage, intPageSize, intTotalPageCount
                        );
                return View(_UserViewModelsIPagedList);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error: " + ex);
                List<ExpandedUserViewModel> col_UserViewModel = new List<ExpandedUserViewModel>();
                return View(col_UserViewModel.ToPagedList(1, 25));
            }
        }
        #endregion

        // Utility
        #region public ApplicationUserManager UserManager
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ??
                    HttpContext.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

        #region public ApplicationRoleManager RoleManager
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ??
                    HttpContext.GetOwinContext()
                    .GetUserManager<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        #endregion
    }
}