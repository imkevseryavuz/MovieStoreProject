using AutoMapper;
using FluentAssertions;
using MovieStoreFinal.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Linq;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper    _mapper;

        public UpdateActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistActorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange
            UpdateActorCommand command = new UpdateActorCommand(_context,_mapper);
            command.ActorId = 0;

            // act & asset 
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aranılan oyuncu bulunamadı.");

        }

        [Fact]
        public void WhenGivenNameIsSameWithAnotherActor_InvalidOperationException_ShouldBeReturn()
        {
            var actor = new Actor() { ActorFirstName = "Poem", ActorLastName ="test" };
            _context.Actors.Add(actor);
            _context.SaveChanges();

            UpdateActorCommand command = new UpdateActorCommand(_context,_mapper);
            command.ActorId = 2;
            command.Model = new UpdateActorViewModel() { FirstName = "Poem",LastName="test" };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aynı isimde  mevcut oyuncu var.");
        }

        [Fact]
        public void WhenGivenBookIdinDB_Genre_ShouldBeUpdate()
        {
            UpdateActorCommand command = new UpdateActorCommand(_context,_mapper);

            UpdateActorViewModel model = new UpdateActorViewModel() { FirstName = "WhenGivenActorIdinDB_FirstName_ShouldBeUpdate",LastName= "WhenGivenActorIdinDB_LastName_ShouldBeUpdate" };
            command.Model = model;
            command.ActorId = 1;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var actor = _context.Actors.SingleOrDefault(actor => actor.Id == command.ActorId);
            actor.Should().NotBeNull();

        }
    }
}
