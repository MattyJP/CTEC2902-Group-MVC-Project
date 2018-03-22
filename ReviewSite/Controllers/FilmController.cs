using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ReviewSite.Controllers
{

    public class FilmController : Controller
    { 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(string name, string description, string genre)
        {
            var viewModel = new FilmViewModel
            {
                Name = "Test" + name,
                Description = "Test D",
                Genre = "Horror"
              
            };

            return View(viewModel);
        }

        public class FilmViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Genre { get; set; }
            public DateTime ReleaseDate { get; set; }
            public int Rating { get; set; }

        }
    }
      