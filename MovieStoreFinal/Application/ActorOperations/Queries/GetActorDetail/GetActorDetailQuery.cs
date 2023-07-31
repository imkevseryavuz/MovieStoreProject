using AutoMapper;
using MovieStoreFinal.DbOperations;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        public int ActorId { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public ActorDetailViewModel Handle()
        {
            var actor = _dbContext.Actors.Where(x => x.Id == ActorId).FirstOrDefault();
            if (actor == null)
            {
                throw new InvalidOperationException("Aranılan aktör bulunamadı");
            }

            ActorDetailViewModel vm = _mapper.Map<ActorDetailViewModel>(actor);

            return vm;
        }
    }
    public class ActorDetailViewModel
    {
        public string ActorFirstName { get; set; }
        public string ActorLastName { get; set; }
    }
}
