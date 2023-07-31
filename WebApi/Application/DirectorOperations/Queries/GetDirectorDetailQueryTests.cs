using AutoMapper;
using FluentAssertions;
using MovieStoreFinal.Application.DirectorOperations.Queries.GetDirectorDetail;
using MovieStoreFinal.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Queries
{
    public class GetDirectorDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDirectorDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenDirectorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetDirectorDetailQuery command = new GetDirectorDetailQuery(_context, _mapper);
            command.DirectorId = 0;


            FluentActions.Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yönetmen bulunamadı");
        }

        [Fact]
        public void WhenGivenDirectorIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetDirectorDetailQuery command = new GetDirectorDetailQuery(_context, _mapper);
            command.DirectorId = 1;


            FluentActions.Invoking(() => command.Handle()).Invoke();

            var director = _context.Directors.SingleOrDefault(director => director.Id == command.DirectorId);
            director.Should().NotBeNull();
        }
    }
}
