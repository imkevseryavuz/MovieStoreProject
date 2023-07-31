
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;



namespace WebApi.UnitTests.TestSetup
{
    public static class Directors
    {
        public static void AddDirectors(this MovieStoreDbContext context)
        {
            context.Directors.AddRange(
                  new Director { FirstName = "Chris", LastName = "Columbus" },
                  new Director { FirstName = "Steven", LastName = "Spielberg" },
                  new Director { FirstName = "David", LastName = "Fincher" });
        }
    }
}
