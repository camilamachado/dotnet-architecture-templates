using MediatR;
using MeuProjeto.Application.Responses.Orders;
using MeuProjeto.SharedKernel.Responses;
using MeuProjeto.SharedKernel.Validators;
using OperationResult;

namespace MeuProjeto.Application.Queries.Orders;

public record GetOrdersQuery(int Page = 1, int PageSize = 10)
    : IRequest<Result<PagedResponse<GetOrdersResponse>>>, IValidatableRequest
{
    public string? UserId { get; set; }
    public bool IsAdmin { get; set; }
}
