using FluentValidation;
using MeuProjeto.Application.Queries.Orders;
using MeuProjeto.SharedKernel.Validators;

namespace MeuProjeto.Application.Validators.Orders;

public class GetOrderByIdValidator : AbstractValidator<GetOrderByIdQuery>, IValidatableRequest
{
    public GetOrderByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
