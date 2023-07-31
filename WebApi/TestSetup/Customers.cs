using MovieStoreFinal.Application.MovieOperations.Queries.GetMovies;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.TestSetup
{
    public static class Customers
    {
        public static void AddCustomers(this MovieStoreDbContext context)
        {
            context.Customers.AddRange(
                    new Customer { Name = "Kevser", Surname = "Yavuz", Email = "kevser@email.com", Password = "123456" },
                    new Customer { Name = "Büşra", Surname = "Sağır", Email = "busra@email.com", Password = "123456" },
                    new Customer { Name = "Test1", Surname = "Test1", Email = "test1@email.com", Password = "123456", }
                );

        }
    }
}
