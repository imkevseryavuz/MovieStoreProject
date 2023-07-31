using AutoMapper;
using MovieStoreFinal.DbOperations;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQuery
    {
        public int DirectorId { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public DirectorDetailViewModel Handle()
        {
            var director = _dbContext.Directors.Where(x => x.Id == DirectorId).FirstOrDefault();
            if (director == null)
            {
                throw new InvalidOperationException("Aranılan yönetmen bulunamadı");
            }

            DirectorDetailViewModel vm = _mapper.Map<DirectorDetailViewModel>(director);

            return vm;
        }
    }
    public class DirectorDetailViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

