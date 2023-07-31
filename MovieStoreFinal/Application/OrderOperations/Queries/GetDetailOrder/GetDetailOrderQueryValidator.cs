using FluentValidation;

namespace MovieStoreFinal.Application.OrderOperations.Queries.GetDetailOrder
{
    public class GetDetailOrderQueryValidator:AbstractValidator<GetDetailOrderQuery>
    {
        public GetDetailOrderQueryValidator()
        {
            RuleFor(query => query.OrderId).GreaterThan(0);
        }
    }
}
