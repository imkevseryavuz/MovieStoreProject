using AutoMapper;
using MovieStoreFinal.Application.GenreOperations.Commands.CreateGenre;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        public CreateDirectorViewModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateDirectorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.FirstName == Model.FirstName);
            if (director != null)
            {
                throw new InvalidOperationException("Yönetmen zaten mevcut");
            }

            director = _mapper.Map<Director>(Model);
            _dbContext.Directors.Add(director);
            _dbContext.SaveChanges();
        }
    }

    public class CreateDirectorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

