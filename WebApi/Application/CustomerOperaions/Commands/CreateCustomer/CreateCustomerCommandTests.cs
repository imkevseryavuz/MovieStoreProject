
using AutoMapper;
using FluentAssertions;
using MovieStoreFinal.Application.CustomerOperations.Command.CreateCustomer;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Linq;
using WebApi.TestSetup;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;


        public CreateCustomerCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistCustomerNameIsGiven_InvalidOperationException_ShouldReturn()
        {
            //arrange
            var customer = new Customer() { Name = "WhenAlreadyExistCustomerNameIsGiven_InvalidOperationException_ShouldReturn",
                                           Surname = "WhenAlreadyExistCustomerSurNameIsGiven_InvalidOperationException_ShouldReturn",
                                           Email= "WhenAlreadyExistCustomerEmailIsGiven_InvalidOperationException_ShouldReturn",
                                           Password= "WhenAlreadyExistCustomerPasswordIsGiven_InvalidOperationException_ShouldReturn"};
            _context.Customers.Add(customer);
            _context.SaveChanges();

            CreateCustomerCommand command = new CreateCustomerCommand(_context,_mapper);
            command.Model = new CreateCustomerModel() { Name = customer.Name, Surname= customer.Surname, Email=customer.Email, Password=customer.Password };


            //act
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yönetmen zaten mevcut!");
        }

        //Çalıştırma ve doğrulama
        [Fact]
        public void WhenValidInputAreGiven_Book_ShouldBeCreated()
        {
            //arrange
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            CreateCustomerModel model = new CreateCustomerModel() { Name="Test1",Surname="test2",Email="test1@mail.com",Password="12345" };
            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var customer = _context.Customers.SingleOrDefault(customer => customer.Name == model.Name);
            customer.Should().NotBeNull();
            customer.Name.Should().Be(model.Name);
            customer.Surname.Should().Be(model.Surname);
            customer.Email.Should().Be(model.Email);
            customer.Password.Should().Be(model.Password);

        }
    }
}
