
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Actors
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
            context.Actors.AddRange(
                  new Actor { ActorFirstName = "Daniel", ActorLastName = "Radcliffe" },
                  new Actor { ActorFirstName = "Emma", ActorLastName = "Watson" },
                  new Actor { ActorFirstName = "Macaulay", ActorLastName = "Culkin" },
                  new Actor { ActorFirstName = "Kieran", ActorLastName = "Culkin" },
                  new Actor { ActorFirstName = "Dweyne", ActorLastName = "Johnson" },
                  new Actor { ActorFirstName = "Bruce", ActorLastName = "Wills" }
                      );

        }
    }
}
