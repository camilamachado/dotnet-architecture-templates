using MediatR;
using MeuProjeto.Application.Responses.Orders;
using MeuProjeto.SharedKernel.Validators;
using OperationResult;

namespace MeuProjeto.Application.Queries.Orders;

public record GetOrderByIdQuery(Guid Id) : IRequest<Result<GetOrderByIdResponse>>, IValidatableRequest
{
    public string? UserId { get; set; }
    public bool IsAdmin { get; set; }
}
