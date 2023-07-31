using AutoMapper;
using MovieStoreFinal.DbOperations;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreFinal.Application.CustomerOperations.Queries
{
    public class GetCustomersQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomersQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<CustomerViewModel> Handle()
        {
            var genres = _dbContext.Genres.ToList();
            List<CustomerViewModel> vm = _mapper.Map<List<CustomerViewModel>>(genres);
            return vm;
        }
    }

    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
