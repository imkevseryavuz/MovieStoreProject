using FluentValidation;

namespace MovieStoreFinal.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Model.GenreName).NotEmpty().MinimumLength(3);
        }
    }
}
