
using FluentAssertions;
using MovieStoreFinal.Application.ActorOperations.Commands.DeleteActor;
using System.Linq;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteActorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidActorIdIsGiven_Validator_ShouldBeReturnErrors(int actorid)
        {
           
            DeleteActorCommand command = new DeleteActorCommand(null!);
            command.ActorId = actorid;

         
            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            var result = validator.Validate(command);

     
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Theory]
        [InlineData(200)]
        [InlineData(2)]
        public void WhenInvalidGenreIdisGiven_Validator_ShouldNotBeReturnError(int actorid)
        {
            DeleteActorCommand command = new DeleteActorCommand(null!);
            command.ActorId = actorid;

            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);

        }

    }
}
