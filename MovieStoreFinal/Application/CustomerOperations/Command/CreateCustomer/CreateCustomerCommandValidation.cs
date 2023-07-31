using FluentValidation;

namespace MovieStoreFinal.Application.CustomerOperations.Command.CreateCustomer
{
    public class CreateCustomerCommandValidation: AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidation()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(3).MaximumLength(8);

        }
    }
}
