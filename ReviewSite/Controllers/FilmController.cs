using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReviewSite_Views.Models;

namespace ReviewSite.Controllers
{
    public class FilmController : Controller
    {
        private List<Film> _films = new List<Film>() {
        new Film { FilmId = 1,
                    Name = "Test 1",
                    Description = "",
                    Genre = "" },
        new Film { FilmId = 2,
                    Name = "Test 2",
                    Description = "",
                    Genre = "" },
        new Film { FilmId = 3,
                    Name = "Test 3",
                    Description = "",
                    Genre = "" },
        };

        // GET: Film
        public ActionResult Index()
        {
            return View(_films);
        }

        // GET: Details/id
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpNotFoundResult();

            Film selectedFilm = _films.First(p => p.FilmId == id);

            if (selectedFilm == null) return new HttpNotFoundResult();

            return View(selectedFilm);
        }

    }
}