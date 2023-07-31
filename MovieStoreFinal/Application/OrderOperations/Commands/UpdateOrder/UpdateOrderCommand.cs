using AutoMapper;
using MovieStoreFinal.DbOperations;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {
        public UpdateOrderViewModel Model { get; set; }
        public int OrderId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }


        public void Handle()
        {
            var order = _dbContext.Orders.SingleOrDefault(x => x.Id == OrderId);
            if (order == null)
            {
                throw new InvalidOperationException("film bulunamadı");
            }

            _mapper.Map(Model, order);
            _dbContext.SaveChanges();
        }

    }
    public class UpdateOrderViewModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
