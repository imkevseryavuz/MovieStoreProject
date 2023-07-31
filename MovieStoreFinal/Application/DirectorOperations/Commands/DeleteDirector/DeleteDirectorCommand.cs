using MovieStoreFinal.DbOperations;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        public DeleteDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.Id == DirectorId);
            if (director == null)
            {
                throw new InvalidOperationException("Böyle bir film türü bulunamadı");
            }


            _dbContext.Directors.Remove(director);
            _dbContext.SaveChanges();
        }
    }
}
