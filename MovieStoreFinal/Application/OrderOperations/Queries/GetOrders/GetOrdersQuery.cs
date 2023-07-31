using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStoreFinal.Application.OrderOperations.Queries.GetOrders
{
    public class GetOrdersQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetOrdersQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<OrderViewModel> Handle()
        {
            var movieList = _dbContext.Orders.Include(x => x.Customer).Include(a => a.Movie).OrderBy(x => x.Id).ToList();
            List<OrderViewModel> wm = _mapper.Map<List<OrderViewModel>>(movieList);
            return wm;
        }
    }

    public class OrderViewModel
    {     
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string MovieName { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
