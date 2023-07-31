using MovieStoreFinal.DbOperations;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        public int ActorId { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        public DeleteActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(x => x.Id == ActorId);
            if (actor == null)
            {
                throw new InvalidOperationException("Oyuncu bulunamadı");
            }


            _dbContext.Actors.Remove(actor);
            _dbContext.SaveChanges();
        }
    }
}
