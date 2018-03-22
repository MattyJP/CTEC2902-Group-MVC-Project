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
                    Description = "Test123",
                    Genre = "Horror" },
        new Film { FilmId = 2,
                    Name = "Test 2",
                    Description = "Test456",
                    Genre = "SCIFI" },
        new Film { FilmId = 3,
                    Name = "Test 3",
                    Description = "Test789",
                    Genre = "Western" },
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

        // GET: Edit/id 
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpNotFoundResult();
            Film selectedFilm = _films.First(p => p.FilmId == id);
            if (selectedFilm == null) return new HttpNotFoundResult();
            return View(selectedFilm);
        }


        public ActionResult Create(int? id)
        {
            
            return View(_films);
        }
    }
}