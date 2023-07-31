using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreFinal.Application.ActorOperations.Queries.GetActors;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreFinal.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMoviesQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MovieViewModel> Handle()
        {
            var movieList = _dbContext.Movies.Include(x => x.Genre)
                .Include(a => a.Director)
                .Include(a=> a.MovieActor)
                .ThenInclude(a=>a.Actor)
                .OrderBy(x => x.Id).ToList();
            List<MovieViewModel> wm = _mapper.Map<List<MovieViewModel>>(movieList);
            return wm;
        }
    }
    public class MovieViewModel
    {
        public string MovieName { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string DirectorFirstName { get; set; }
        public string DirectorLastName { get; set; }

        public List<ActorViewModel> Actor { get; set; }


    }
}
