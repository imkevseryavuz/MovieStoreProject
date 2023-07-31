using AutoMapper;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreViewModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGenreCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.GenreName == Model.GenreName);
            if (genre != null)
            {
                throw new InvalidOperationException("Tür zaten mevcut");
            }

            genre = _mapper.Map<Genre>(Model);
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }
    }
    public class CreateGenreViewModel
    {
        public string GenreName { get; set; }
    }

}
