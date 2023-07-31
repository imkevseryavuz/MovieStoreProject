using AutoMapper;
using MovieStoreFinal.Application.GenreOperations.Commands.UpdateGenre;
using MovieStoreFinal.DbOperations;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public UpdateDirectorViewModel Model { get; set; }
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }


        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.Id == DirectorId);
            if (director == null)
            {
                throw new InvalidOperationException("Böyle bir yönetmen bulunamadı");
            }

            _mapper.Map(Model, director);
            _dbContext.SaveChanges();
        }

    }
    public class UpdateDirectorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
