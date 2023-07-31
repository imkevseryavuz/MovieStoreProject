using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MovieStoreFinal.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMoviesDetailQueryValidator:AbstractValidator<GetMovieDetailQuery>
    {
        public GetMoviesDetailQueryValidator()
        {
            RuleFor(query => query.MovieId).GreaterThan(0);
        }
    }
}
