using AutoMapper;
using MovieStoreFinal.DbOperations;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenreDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public GenreDetailViewModel Handle()
        {
            var genre = _dbContext.Genres.Where(x => x.Id == GenreId).FirstOrDefault();
            if (genre == null)
            {
                throw new InvalidOperationException("Aranılan film türü bulunamadı");
            }

            GenreDetailViewModel vm = _mapper.Map<GenreDetailViewModel>(genre);

            return vm;
        }
    }
    public class GenreDetailViewModel
    {
        public string GenreName { get; set; }
    }

}
