using FluentAssertions;
using MovieStoreFinal.Application.DirectorOperations.Queries.GetDirectorDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.DirectorOperations.Queries
{
    public class GetDirectorDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidDirectorIsGiven_Validator_ShouldBeReturnErrors(int directorid)
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(null, null);
            query.DirectorId = directorid;

            GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidBookidIsGiven_Validator_ShouldNotBeReturnErrors(int directorid)
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(null, null);
            query.DirectorId = directorid;

            GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}
