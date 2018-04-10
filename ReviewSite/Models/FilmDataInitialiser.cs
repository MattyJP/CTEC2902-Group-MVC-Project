using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ReviewSite.Models
{
    public class FilmDataInitialiser : DropCreateDatabaseAlways<FilmContext>
    {
        protected override void Seed(FilmContext context)
        {
            Film film1 = new Film();
            film1.FilmId = 1;
            film1.Name = "Punch 3: Punch Harderer";
            film1.Description = "Why do they keep making these?";
            film1.Genre = "Action";
            context.Films.Add(film1);
            Film film2 = new Film();
            film2.FilmId = 2;
            film2.Name = "Are You With Me?";
            film2.Description = "The story of one man who antics enraged an entire academic cohort.";
            film2.Genre = "Documentary";
            context.Films.Add(film2);
            Film film3 = new Film();
            film3.FilmId = 3;
            film3.Name = "Punch: Origins";
            film3.Description = "Find out where the punching began!";
            film3.Genre = "Action";
            context.Films.Add(film3);
            Film film4 = new Film();
            film4.FilmId = 4;
            film4.Name = "Putin on the Ritz";
            film4.Description = "The wacky adventures of a cracker company executive who gets caught up in a plot to assassinate the President of Russia!";
            film4.Genre = "Comedy";
            context.Films.Add(film4);

            base.Seed(context);
        }


    }
}