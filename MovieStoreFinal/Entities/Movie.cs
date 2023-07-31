using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace MovieStoreFinal.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }

        //Director
        public int DirectorId { get; set; }
        public Director Director { get; set; }
     
        // Many-to-Many 
       public virtual List<MovieActor> MovieActor { get; set; }

    }
}
