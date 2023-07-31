using FluentValidation;

namespace MovieStoreFinal.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator:AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(command => command.Model.ActorFirstName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.ActorLastName).NotEmpty().MinimumLength(3);
            
        }
    }
}
