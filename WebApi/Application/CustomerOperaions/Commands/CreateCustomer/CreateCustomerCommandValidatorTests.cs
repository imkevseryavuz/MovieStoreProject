using FluentAssertions;
using MovieStoreFinal.Application.ActorOperations.Commands.CreateActor;
using MovieStoreFinal.Application.DirectorOperations.Commands.CreateDirector;
using System;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Chris","Columbus")]
        [InlineData("Chri", "Columb")]
        [InlineData("Ch","Coloum")]
        [InlineData("","")]
        [InlineData(" "," ")]
        public void WhenInvalidInputsDirectprNameAreGiven_Validator_ShouldBeReturnErrors(string name, string surname)
        {
            //arrange
            CreateDirectorCommand command = new CreateDirectorCommand(null,null);
            command.Model = new CreateDirectorViewModel()
            {
                FirstName = name,
                LastName = surname
            };

            //act
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsCustomerNameAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateDirectorCommand command = new CreateDirectorCommand(null,null);
            command.Model = new CreateDirectorViewModel()
            {
                FirstName = "Chris",
                LastName="Columbs"
            };
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
