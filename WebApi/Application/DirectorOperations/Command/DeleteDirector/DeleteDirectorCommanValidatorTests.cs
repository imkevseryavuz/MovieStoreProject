using FluentAssertions;
using MovieStoreFinal.Application.DirectorOperations.Commands.DeleteDirector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Command.DeleteDirector
{
    public class DeleteDirectorCommanValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidDirectorIsGiven_Validator_ShouldBeReturnErrors(int directorid)
        {
            //arrange
            DeleteDirectorCommand command = new DeleteDirectorCommand(null!);
            command.DirectorId = directorid;

            //act
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(200)]
        [InlineData(2)]
        public void WhenInvalidDirectorIdisGiven_Validator_ShouldNotBeReturnError(int directorid)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(null!);
            command.DirectorId = directorid;

            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);

        }
    }

 }
