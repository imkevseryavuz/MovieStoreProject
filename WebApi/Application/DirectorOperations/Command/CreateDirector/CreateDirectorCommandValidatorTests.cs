using FluentAssertions;
using MovieStoreFinal.Application.CustomerOperations.Command.CreateCustomer;
using MovieStoreFinal.Application.DirectorOperations.Commands.CreateDirector;
using System;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateDirectorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("test","test","aaaa","123")]
        [InlineData("avsc", "avdg","dddd","123456")]
        [InlineData("ab","abb","acvva","15895")]
        [InlineData("avbg","avff"," "," ")]
        [InlineData(" "," ","","")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, string email, string password)
        {
            //arrange
            CreateCustomerCommand command = new CreateCustomerCommand(null,null);
            command.Model = new CreateCustomerModel()
            {
                Name = name,
                Surname = surname,
                Email= email,
                Password=password
            };

            //act
            CreateCustomerCommandValidation validator = new CreateCustomerCommandValidation();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateCustomerCommand command = new CreateCustomerCommand(null,null);
            command.Model = new CreateCustomerModel()
            {
                Name = "Chris",
                Surname="Columbs",
                Email="test1@mail.com",
                Password="123456"
            };
            CreateCustomerCommandValidation validator = new CreateCustomerCommandValidation();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
