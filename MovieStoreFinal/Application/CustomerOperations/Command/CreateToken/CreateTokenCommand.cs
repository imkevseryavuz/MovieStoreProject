using Microsoft.Extensions.Configuration;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.TokenOperations.Models;
using System;
using System.Linq;

namespace MovieStoreFinal.Application.CustomerOperations.Command.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(IMovieStoreDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public Token Handle()
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
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
                throw new InvalidOperationException("Kullanıcı adı ve şifre hatalı");
            }
        }
    }
        public class CreateTokenModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
}
