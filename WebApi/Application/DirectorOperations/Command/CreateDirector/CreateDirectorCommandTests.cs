
using AutoMapper;
using FluentAssertions;
using MovieStoreFinal.Application.ActorOperations.Commands.CreateActor;
using MovieStoreFinal.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Linq;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Command.CreateDirector
{
    public class CreateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;


        public CreateDirectorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistActorNameIsGiven_InvalidOperationException_ShouldReturn()
        {
            //arrange
            var director = new Director() { FirstName = "WhenAlreadyExistDirectorNameIsGiven_InvalidOperationException_ShouldReturn",
                                           LastName = "WhenAlreadyExistDirectorSurNameIsGiven_InvalidOperationException_ShouldReturn",
                                     };
            _context.Directors.Add(director);
            _context.SaveChanges();

            CreateDirectorCommand command = new CreateDirectorCommand(_context,_mapper);
            command.Model = new CreateDirectorViewModel() { FirstName = director.FirstName, LastName=director.LastName };


            //act
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yönetmen zaten mevcut!");
        }

        //Çalıştırma ve doğrulama
        [Fact]
        public void WhenValidInputAreGiven_Book_ShouldBeCreated()
        {
            //arrange
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            CreateDirectorViewModel model = new CreateDirectorViewModel() { FirstName="Test1",LastName="test2" };
            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var director = _context.Directors.SingleOrDefault(director => director.FirstName == model.FirstName);
            director.Should().NotBeNull();
            director.LastName.Should().Be(model.LastName);

        }
    }
}
