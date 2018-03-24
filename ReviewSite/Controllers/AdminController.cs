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
        //Get the admin user role
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

        // GET: /Admin/Edit/TestUser 
        [Authorize(Roles = "Administrator")]
        #region public ActionResult EditUser(string UserName)
        public ActionResult EditUser(string UserName)
        {
            if (UserName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpandedUserViewModel objExpandedUserViewModel = GetUser(UserName);
            if (objExpandedUserViewModel == null)
            {
                return HttpNotFound();
            }
            return View(objExpandedUserViewModel);
        }
        #endregion

        // PUT: /Admin/EditUser
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        #region public ActionResult EditUser(ExpandedUserViewModel paramExpandedUserViewModel)
        public ActionResult EditUser(ExpandedUserViewModel paramExpandedUserViewModel)
        {
            try
            {
                if (paramExpandedUserViewModel == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ExpandedUserViewModel objExpandedUserViewModel = UpdateViewModelUser(paramExpandedUserViewModel);
                if (objExpandedUserViewModel == null)
                {
                    return HttpNotFound();
                }
                return Redirect("~/Admin");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error: " + ex);
                return View("EditUser", GetUser(paramExpandedUserViewModel.UserName));
            }
        }
        #endregion


        #region private ExpandedUserViewModel GetUser(string paramUserName)
        private ExpandedUserViewModel GetUser(string paramUserName)
        {
            ExpandedUserViewModel objExpandedUserViewModel = new ExpandedUserViewModel();

            var result = UserManager.FindByName(paramUserName);

            // If we could not find the user, throw an exception
            if (result == null) throw new Exception("Could not find the User");

            objExpandedUserViewModel.UserName = result.UserName;
            objExpandedUserViewModel.Email = result.Email;
            objExpandedUserViewModel.LockoutEndDateGMT = result.LockoutEndDateUtc;
            objExpandedUserViewModel.AccessFailedCount = result.AccessFailedCount;
            objExpandedUserViewModel.PhoneNumber = result.PhoneNumber;

            return objExpandedUserViewModel;
        }
        #endregion

        #region private ExpandedUserViewModel UpdateViewModelUser(ExpandedUserViewModel objExpandedUserViewModel)
        private ExpandedUserViewModel UpdateViewModelUser(ExpandedUserViewModel paramExpandedUserViewModel)
        {
            ApplicationUser result =
                UserManager.FindByName(paramExpandedUserViewModel.UserName);

            // If we could not find the user, throw an exception
            if (result == null)
            {
                throw new Exception("Could not find the User");
            }

            result.Email = paramExpandedUserViewModel.Email;

            // Lets check if the account needs to be unlocked
            if (UserManager.IsLockedOut(result.Id))
            {
                // Unlock user
                UserManager.ResetAccessFailedCountAsync(result.Id);
            }

            UserManager.Update(result);

            // Was a password sent across?
            if (!string.IsNullOrEmpty(paramExpandedUserViewModel.Password))
            {
                // Remove current password
                var removePassword = UserManager.RemovePassword(result.Id);
                if (removePassword.Succeeded)
                {
                    // Add new password
                    var AddPassword =
                        UserManager.AddPassword(
                            result.Id,
                            paramExpandedUserViewModel.Password
                            );

                    if (AddPassword.Errors.Count() > 0)
                    {
                        throw new Exception(AddPassword.Errors.FirstOrDefault());
                    }
                }
            }

            return paramExpandedUserViewModel;
        }
        #endregion
    }
}