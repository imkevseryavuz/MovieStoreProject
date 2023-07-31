using FluentValidation;
using System;
using System.Collections.Generic;

namespace MovieStoreFinal.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidator:AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(command => command.Model.MovieName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.ReleaseYear.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Price).GreaterThan(0);
            RuleFor(command => command.Model.DirectorId).GreaterThan(0);
         


        }
    }
}
