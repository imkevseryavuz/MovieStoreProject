using AutoMapper;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        public CreateActorViewModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(x => x.ActorFirstName == Model.ActorLastName);
            if (actor != null)
            {
                throw new InvalidOperationException("Aktör zaten mevcut");
            }

            actor = _mapper.Map<Actor>(Model);
            _dbContext.Actors.Add(actor);
            _dbContext.SaveChanges();
        }
    }

    public class CreateActorViewModel
    {
        public string ActorFirstName { get; set; }
        public string ActorLastName { get; set; }
    }
}
