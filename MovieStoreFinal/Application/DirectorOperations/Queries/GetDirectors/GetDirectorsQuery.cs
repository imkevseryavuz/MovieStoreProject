using AutoMapper;
using MovieStoreFinal.DbOperations;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreFinal.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<DirectorViewModel> Handle()
        {
            var directors = _dbContext.Directors.ToList();
            List<DirectorViewModel> vm = _mapper.Map<List<DirectorViewModel>>(directors);
            return vm;
        }
    }

    public class DirectorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

