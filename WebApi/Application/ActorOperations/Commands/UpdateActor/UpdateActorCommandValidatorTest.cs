using AutoMapper;
using FluentAssertions;
using MovieStoreFinal.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreFinal.DbOperations;
using System.Linq;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateActorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateActorCommandValidatorTest(CommonTestFixture testFixture,IMapper mapper)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData("ad", "ad")]
        [InlineData("ad ", "ad ")]
        [InlineData(" a ", " a ")]
        [InlineData("abd", "abd")]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string name, string surname)
        {
            //arrange
            UpdateActorCommand command = new UpdateActorCommand(null,null);
            command.Model = new UpdateActorViewModel() { FirstName = name,LastName=surname };

            //act
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [InlineData("acde", "acde")]
        [InlineData("abd cef", "abd cef")]
        [Theory]
        public void WhenInvalidInputsAreGiven_Validator_ShouldNotBeReturnErrors(string name,string surname)
        {
            UpdateActorCommand command = new UpdateActorCommand(null,null);
            command.Model = new UpdateActorViewModel() { FirstName = name,LastName=surname };

            UpdateActorCommandValidator validations = new UpdateActorCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }


    }
}
