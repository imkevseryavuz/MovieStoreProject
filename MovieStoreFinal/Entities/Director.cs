using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreFinal.Entities
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Movies directed by the director (One-to-Many relationship with Movie entity)
       // public ICollection<Movie> MoviesDirected { get; set; }

    }
}
