﻿using FluentValidation;

namespace MovieStoreFinal.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.Model.GenreName).NotEmpty().MinimumLength(3);
        }
    }
}
