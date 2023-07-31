using FluentAssertions;
using MovieStoreFinal.Application.ActorOperations.Queries.GetActorDetail;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Queries
{
    public class GetActorDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {

        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-10)]
        [Theory]
        public void WhenInvalidActorIdIsGiven_Validator_ShouldBeReturnErrors(int actorid)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(null,null);
            query.ActorId = actorid;

            GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [InlineData(1)]
        [InlineData(100)]
        [Theory]
        public void WhenInvalidGenreidIsGiven_Validator_ShouldNotBeReturnErrors(int actorid)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(null,null);
            query.ActorId = actorid;

            GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }


    }
}
