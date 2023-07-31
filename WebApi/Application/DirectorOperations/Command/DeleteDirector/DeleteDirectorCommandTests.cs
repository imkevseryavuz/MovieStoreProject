using FluentAssertions;
using MovieStoreFinal.Application.DirectorOperations.Commands.DeleteDirector;
using MovieStoreFinal.DbOperations;
using MovieStoreFinal.Entities;
using System;
using System.Linq;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Command.DeleteDirector
{
    public class DeleteDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteDirectorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;

        }

        [Fact]
        public void WhenAlreadyExistBookIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange 
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);


            // act and asset 
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek yönetmen bulunamadı");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            //arrange
            var director = new Director() { FirstName="Chris",LastName="Coloumbs" };
            _context.Add(director);
            _context.SaveChanges();

            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = director.Id;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            director = _context.Directors.SingleOrDefault(x => x.Id == director.Id);
            director.Should().BeNull();
        }
    }
}
