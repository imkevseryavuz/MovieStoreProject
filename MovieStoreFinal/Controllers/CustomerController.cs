using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieStoreFinal.Application.CustomerOperations.Command.CreateCustomer;
using MovieStoreFinal.Application.CustomerOperations.Command.CreateToken;
using MovieStoreFinal.Application.CustomerOperations.Command.RefreshToken;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.TokenOperations.Models;


namespace MovieStoreFinal.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public CustomerController(IMovieStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_dbContext, _mapper);
            command.Model = newCustomer;
            CreateCustomerCommandValidation validator = new CreateCustomerCommandValidation();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_dbContext, _configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }
        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_dbContext, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }
    }
}
