
using FluentAssertions;
using MovieStoreFinal.Application.ActorOperations.Commands.DeleteActor;
using MovieStoreFinal.DbOperations;
using System;
using System.Linq;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public DeleteActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistActorIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = 100;

            // act and asset
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aranılan oyuncu bulunamadı");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeCreated()
        {
            //arrange
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = 1;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var actor = _context.Actors.SingleOrDefault(x => x.Id == command.ActorId);
            actor.Should().BeNull();

        }
    }
}
