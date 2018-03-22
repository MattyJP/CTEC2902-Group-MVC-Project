using ReviewSite_Views.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewSite.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        public ActionResult Index()
        {
            return View();
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit(Film film)
        {
            if (ModelState.IsValid)
            {
                Debug.WriteLine(film.Name);
                Debug.WriteLine(film.Description);
                Debug.WriteLine(film.Genre);
                
                return RedirectToAction("Index");
            }
            else
            {
                return View(film);
            }
        }

    }
}