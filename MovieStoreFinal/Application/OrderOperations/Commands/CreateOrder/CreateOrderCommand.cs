using AutoMapper;
using MovieStoreFinal.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreFinal.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderViewModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateOrderCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {

            var order = _mapper.Map<Order>(Model);
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
    }

    public class CreateOrderViewModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
