using AutoMapper;
using FluentAssertions;
using MovieStoreFinal.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStoreFinal.DbOperations;
using System;
using System.Linq;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Command.UpdateBook
{
    public class UpdateDirectorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateDirectorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange 
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context,_mapper);
            command.DirectorId = 0;

            // act & asset 
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı");

        }

        [Fact]
        public void WhenGivenBookIdinDB_Book_ShouldBeUpdate()
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context,_mapper);

            UpdateDirectorViewModel model = new UpdateDirectorViewModel() 
            {    
                FirstName = "WhenGivenDirectorIdinDB_Movie_ShouldBeUpdate",
                LastName="Coloumbs" };
            command.Model = model;
            command.DirectorId = 1;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var director = _context.Directors.SingleOrDefault(director => director.Id == command.DirectorId);
            director.Should().NotBeNull();

        }

    }
}
