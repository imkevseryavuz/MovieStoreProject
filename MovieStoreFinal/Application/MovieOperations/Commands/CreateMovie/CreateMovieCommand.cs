using AutoMapper;
using MovieStoreFinal.Application.ActorOperations.Queries.GetActors;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreFinal.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieViewModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.MovieName == Model.MovieName);
            if (movie != null)
            {
                throw new InvalidOperationException("Film zaten mevcut");
            }

            movie = _mapper.Map<Movie>(Model);
            movie.MovieActor = _dbContext.Actors.Where(p=> Model.ActorsId.Contains(p.Id))
                .Select(p => new MovieActor
                {
                    ActorId = p.Id,
                    Movie = movie
                }).ToList();
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }
    }
    public class CreateMovieViewModel
    {
        public string MovieName { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
        public int DirectorId { get; set; }

        public List<int> ActorsId { get; set; }
    }
}
