using AutoMapper;
using MovieStoreFinal.DbOperations;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreFinal.Application.ActorOperations.Queries.GetActors
{
    public class GetActorsQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

      public List<ActorViewModel> Handle()
         {
             var actor = _dbContext.Actors.ToList();
             List<ActorViewModel> vm = _mapper.Map<List<ActorViewModel>>(actor);
             return vm;
         }
 
    }


    public class ActorViewModel
    {
        public string ActorFirstName { get; set; }
        public string ActorLastName { get; set; }
    }

}
