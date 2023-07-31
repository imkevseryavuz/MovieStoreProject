using FluentValidation;
using System;

namespace MovieStoreFinal.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator:AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(command => command.Model.MovieName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.ReleaseYear.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Price).GreaterThan(0);
            RuleFor(command => command.Model.DirectorId).GreaterThan(0);
            RuleFor(command => command.Model.ActorId).NotEmpty();
        }
    }
}
