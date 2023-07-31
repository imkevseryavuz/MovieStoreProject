
using FluentAssertions;
using MovieStoreFinal.Application.ActorOperations.Commands.CreateActor;
using System.Linq;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateActorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(" ", " ")]
        [InlineData("","")]
        [InlineData("ab","ab")]
        [InlineData("abc","abc")]
        [InlineData("a","a")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string name,string surname)
        {
            //arrange
            CreateActorCommand command = new CreateActorCommand(null,null);
            command.Model = new CreateActorViewModel() { ActorFirstName = name,ActorLastName=surname};

            //act
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Theory]
        [InlineData("abcd ", "abcd ")]
        [InlineData("abcd", "abcd")]
        [InlineData("ab123","ab123")]
        [InlineData("12abc", "12abc")]
        [InlineData("    a", "    a")]
        public void WhenValidInputAreGiven_Validator_ShouldBeReturnErrors(string name,string surname)
        {
            //arrange
            CreateActorCommand command = new CreateActorCommand(null!, null!);
            command.Model = new CreateActorViewModel() 
            { 
                ActorFirstName = name,  
                ActorLastName=surname
            };

            //act
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);

        }

    }
}
