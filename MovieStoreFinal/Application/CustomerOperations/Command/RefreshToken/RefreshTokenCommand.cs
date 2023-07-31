using Microsoft.Extensions.Configuration;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.TokenOperations.Models;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.CustomerOperations.Command.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IMovieStoreDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public Token Handle()
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.RefresToken == RefreshToken && x.RefreshTokenExpDate > DateTime.Now);
            if (customer is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);

                customer.RefresToken = token.RefreshToken;
                customer.RefreshTokenExpDate = token.Expiration.AddMinutes(5);

                _dbContext.SaveChanges();
                return token;
            }
            else
            {
                throw new InvalidOperationException("Valid bir Refresh Token bulunamadı");
            }
        }
    }
}
