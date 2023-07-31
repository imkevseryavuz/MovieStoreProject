using AutoMapper;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreFinal.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public UpdateMovieViewModel Model { get; set; }
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }


        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie == null)
            {
                throw new InvalidOperationException("film bulunamadı");
            }

            _mapper.Map(Model, movie);
            _dbContext.SaveChanges();
        }

    }
    public class UpdateMovieViewModel
    {
        public string MovieName { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
        public int DirectorId { get; set; }
        public List<int> ActorId { get; set; }
    }
}
