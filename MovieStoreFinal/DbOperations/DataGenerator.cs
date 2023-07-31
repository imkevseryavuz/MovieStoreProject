using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStoreFinal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreFinal.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }
                
                //Türler
                context.AddRange(
                    new Genre { GenreName = "Fantastik" },
                    new Genre { GenreName = "Comedy" },
                    new Genre { GenreName = "Aksiyon" });

                //Yönetmenler
                context.AddRange(
                    new Director { FirstName = "Chris", LastName = "Columbus" },
                    new Director { FirstName = "Steven", LastName = "Spielberg" },
                    new Director { FirstName = "David", LastName = "Fincher" });

            
                //Filmler
                context.AddRange(
                    new Movie { DirectorId = 1,GenreId = 1, Price = 4990, MovieName = "Harry Potter ve Felsefe Taşı" },
                    new Movie { DirectorId = 1,GenreId = 2, Price = 4490, MovieName = "Evde Tek Başına" },
                    new Movie { DirectorId = 2,GenreId = 3, Price = 3490, MovieName = "G.I. Joe: Misilleme" });

                //Aktör
                context.AddRange(
                    new Actor { ActorFirstName = "Daniel", ActorLastName = "Radcliffe" },
                    new Actor { ActorFirstName = "Emma", ActorLastName = "Watson" },
                    new Actor { ActorFirstName = "Macaulay", ActorLastName = "Culkin" },
                    new Actor { ActorFirstName = "Kieran", ActorLastName = "Culkin" },
                    new Actor { ActorFirstName = "Dweyne", ActorLastName = "Johnson" },
                    new Actor { ActorFirstName = "Bruce", ActorLastName = "Wills" }
                    );

                //Filmde oynayan aktör listesi
                context.AddRange(
                    new MovieActor { ActorId = 1, MovieId = 1 },
                    new MovieActor { ActorId = 3, MovieId = 1 },
                    new MovieActor { ActorId = 2, MovieId = 3 },
                    new MovieActor { ActorId = 4, MovieId = 3 });
              
               //Müşteri
                context.AddRange(
                    new Customer {Name = "Kevser",Surname = "Yavuz", Email = "kevser@email.com",Password = "123456" },
                    new Customer { Name = "Büşra",Surname = "Sağır", Email = "busra@email.com", Password = "123456"},
                    new Customer{ Name = "Test1",Surname = "Test1", Email = "test1@email.com",Password = "123456",});

                //Satın alma işlemi
                context.AddRange(
                  new Order { CustomerId = 1, MovieId = 1, PurchaseDate = new DateTime(2022, 07, 06), IsActive = true },
                  new Order { CustomerId = 2, MovieId = 1, PurchaseDate = new DateTime(2022, 12, 05), IsActive = true },
                  new Order { CustomerId = 3, MovieId = 2, PurchaseDate = new DateTime(2022, 08, 25), IsActive = true });

                context.SaveChanges();
            }
        }
    }
}

