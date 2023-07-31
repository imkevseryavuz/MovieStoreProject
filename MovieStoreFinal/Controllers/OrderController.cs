using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreFinal.Application.OrderOperations.Commands.CreateOrder;
using MovieStoreFinal.Application.OrderOperations.Commands.DeleteOrder;
using MovieStoreFinal.Application.OrderOperations.Commands.UpdateOrder;
using MovieStoreFinal.Application.OrderOperations.Queries.GetDetailOrder;
using MovieStoreFinal.Application.OrderOperations.Queries.GetOrders;
using MovieStoreFinal.DbOperations;

namespace MovieStoreFinal.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class OrderController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetOrder()
        {
            GetOrdersQuery query = new GetOrdersQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            GetDetailOrderQuery query = new GetDetailOrderQuery(_context, _mapper);
            query.OrderId = id;
            GetDetailOrderQueryValidator validator = new GetDetailOrderQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();

            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddOrder([FromBody] CreateOrderViewModel newOrder)
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = newOrder;
            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder([FromBody] UpdateOrderViewModel updatedOrder, int id)
        {
            UpdateOrderCommand command = new UpdateOrderCommand(_context, _mapper);
            command.OrderId = id;
            command.Model = updatedOrder;
            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteOrder(int id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.OrderId = id;
            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
