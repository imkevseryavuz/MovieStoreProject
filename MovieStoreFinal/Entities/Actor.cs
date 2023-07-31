using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreFinal.Entities
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ActorFirstName { get; set; }
        public string ActorLastName { get; set; }

        public virtual List<MovieActor> MovieActor { get; set; }

    }
}
