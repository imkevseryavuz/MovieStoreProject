
using AutoMapper;
using FluentAssertions;
using MovieStoreFinal.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStoreFinal.DbOperations;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Command.UpdateBook
{
    public class UpdateDirectorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateDirectorCommandValidatorTest(CommonTestFixture testFixture,IMapper mapper)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData("Chr","Cl")]
        [InlineData("Lord","Colum")]
        [InlineData("Chris","Col ")]

        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors( string name, string surname)
        {
            //arrange
            UpdateDirectorCommand command = new UpdateDirectorCommand(null,null);
            command.Model = new UpdateDirectorViewModel() { FirstName = name, LastName = surname };
            //act
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [InlineData("Chris","Coloumbs")]
        [Theory]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors(string name, string surname)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(null,null);
            command.Model = new UpdateDirectorViewModel()
            {
                FirstName = name,
                LastName = surname
            };

            UpdateDirectorCommandValidator validations = new UpdateDirectorCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

    }
}
