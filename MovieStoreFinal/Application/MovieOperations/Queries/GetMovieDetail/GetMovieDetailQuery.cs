using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreFinal.Application.ActorOperations.Queries.GetActors;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreFinal.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int MovieId { get; set; }
        public GetMovieDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public MovieDetailViewModel Handle()
        {
            var movie = _dbContext.Movies
                .Include(x => x.Genre)
                .Include(a => a.Director)
                .Include(a=>a.MovieActor).ThenInclude(a => a.Actor)
                .Where(movie => movie.Id == MovieId).SingleOrDefault();
            if (movie is null)
                throw new InvalidOperationException("Kitap bulunamadı!");

            MovieDetailViewModel wm = _mapper.Map<MovieDetailViewModel>(movie);
            return wm;
        }

    }

    public class MovieDetailViewModel
    {
        public string MovieName { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Director { get; set; }
        public List<ActorViewModel> Actors { get; set; }

    }
}

