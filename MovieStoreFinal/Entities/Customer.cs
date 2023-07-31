using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreFinal.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefresToken { get; set; }
        public DateTime RefreshTokenExpDate { get; set; }
        // Movies purchased by the customer (Many-to-Many relationship with Movie entity)
        public ICollection<Order> PurchasedMovies { get; set; }

        // Favorite genres of the customer (Many-to-Many relationship with Genre entity)


    }
}
