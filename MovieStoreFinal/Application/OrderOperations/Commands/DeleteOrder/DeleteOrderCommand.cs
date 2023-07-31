using MovieStoreFinal.DbOperations;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommand
    {
        public int OrderId { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        public DeleteOrderCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var order = _dbContext.Orders.SingleOrDefault(x => x.Id == OrderId);
            if (order == null)
            {
                throw new InvalidOperationException("Silinecek satış bulunamadı");
            }


            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }
    }
}

