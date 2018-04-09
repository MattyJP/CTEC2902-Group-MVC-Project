using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ReviewSite.Models
{
    public class DirectorDataInitialiser : DropCreateDatabaseAlways<DirectorContext>
    {
        protected override void Seed(DirectorContext context)
        {
            Director dir1 = new Director();
            dir1.DirectorId = 1;
            dir1.Name = "Shlomo Eightiesberg";
            dir1.DateOfBirth = new DateTime(1966, 02, 03);
            dir1.DirectorSummary = "A man whose entire career is based on re-making the films he perfected decades ago. Known for drunken public outbursts, he now resides in a shack in the Australian outback rambling about friendly extraterrestrials.";
            context.Directors.Add(dir1);
            Director dir2 = new Director();
            dir2.DirectorId = 2;
            dir2.Name = "Karen Manslaughter";
            dir2.DateOfBirth = new DateTime(1975, 02, 05);
            dir2.DirectorSummary = "She silenced the world with stunning romantic dramas, but her foray into comedy is really what put the 'laughter' into Manslaughter.";
            context.Directors.Add(dir2);
            Director dir3 = new Director();
            dir3.DirectorId = 3;
            dir3.Name = "The Tyrone";
            dir3.DateOfBirth = new DateTime(1992, 09, 01);
            dir3.DirectorSummary = "An eccentric by directing standards, The Tyrone is responsible for numerous hard-hitting documentaries.";
            context.Directors.Add(dir3);

            base.Seed(context);
        }
    }
}