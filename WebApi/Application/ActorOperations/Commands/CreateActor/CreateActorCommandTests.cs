using AutoMapper;
using FluentAssertions;
using MovieStoreFinal.Application.ActorOperations.Commands.CreateActor;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Linq;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
    
        [Fact]
        public void WhenAlreadyExistActorNameIsGiven_InvalidOperationException_ShouldReturn()
        {
            //arrange
            var actor = new Actor() { ActorFirstName = "WhenAlreadyExistActorFirstNameIsGiven_InvalidOperationException_ShouldReturn",  
                                        ActorLastName= "WhenAlreadyExistActorLastNameIsGiven_InvalidOperationException_ShouldReturn"};
            _context.Actors.Add(actor);
            _context.SaveChanges();

            CreateActorCommand command = new CreateActorCommand(_context,_mapper);
            command.Model = new CreateActorViewModel() { ActorFirstName = actor.ActorFirstName, ActorLastName=actor.ActorLastName };


            //act
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aktör zaten mevcut!");
        }

        //Çalıştırma ve doğrulama
        [Fact]
        public void WhenValidInputAreGiven_Actor_ShouldBeCreated()
        {
            //arrange
            CreateActorCommand command = new CreateActorCommand(_context,_mapper);
            CreateActorViewModel model = new CreateActorViewModel() { ActorFirstName = "Test1", ActorLastName = "Test2", };
            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var actor = _context.Actors.SingleOrDefault(actor => actor.ActorFirstName == model.ActorFirstName);
            actor.Should().NotBeNull();
            actor.ActorLastName.Should().Be(model.ActorLastName);

        }
    }

}

