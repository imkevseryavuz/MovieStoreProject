using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreFinal.Application.MovieOperations.Queries.GetMovieDetail;
using MovieStoreFinal.DbOperations;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.OrderOperations.Queries.GetDetailOrder
{
    public class GetDetailOrderQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int OrderId { get; set; }
        public GetDetailOrderQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public OrderDetailViewModel Handle()
        {
            var movie = _dbContext.Orders.Include(x => x.Customer).Include(a => a.Movie).Where(movie => movie.Id == OrderId).SingleOrDefault();
            if (movie is null)
                throw new InvalidOperationException("Kitap bulunamadı!");

            OrderDetailViewModel wm = _mapper.Map<OrderDetailViewModel>(movie);
            return wm;
        }

    }
    public class OrderDetailViewModel
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string MovieName { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
