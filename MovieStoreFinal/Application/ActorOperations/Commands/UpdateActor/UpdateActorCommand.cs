using AutoMapper;
using MovieStoreFinal.DbOperations;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public UpdateActorViewModel Model { get; set; }
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }


        public void Handle()
        {
            var actor = _dbContext.Directors.SingleOrDefault(x => x.Id == ActorId);
            if (actor == null)
            {
                throw new InvalidOperationException("Böyle bir aktör bulunamadı");
            }

            _mapper.Map(Model, actor);
            _dbContext.SaveChanges();
        }

    }
    public class UpdateActorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
