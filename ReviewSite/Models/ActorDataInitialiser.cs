using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ReviewSite.Models
{
    public class ActorDataInitialiser : DropCreateDatabaseAlways<ActorContext>
    {
        protected override void Seed(ActorContext context)
        {
            Actor act1 = new Actor();
            act1.ActorId = 1;
            act1.Name = "Johnson Johnson";
            act1.DateOfBirth = new DateTime(1984, 02, 05);
            act1.ActorSummary = "Mocked for years for his name's phallic connotations, Johnson vowed to 'Show them all' by pursuing an acting career.";
            context.Actors.Add(act1);
            Actor act2 = new Actor();
            act2.ActorId = 2;
            act2.Name = "Jenkins Wilkins";
            act2.DateOfBirth = new DateTime(1974, 02, 05);
            act2.ActorSummary = "Nobody believed this was his real name.";
            context.Actors.Add(act2);
            Actor act3 = new Actor();
            act3.ActorId = 3;
            act3.Name = "Alfie-G";
            act3.DateOfBirth = new DateTime(1990, 10, 20);
            act3.ActorSummary = "An inept lecturer-turned-rapper-turned actor, Alfie-G only wants support from his fans, asking 'Are you with me here?'.";
            context.Actors.Add(act3);

            base.Seed(context);
        }

    }
}