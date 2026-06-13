using System.Text.Json.Serialization;
using MediatR;
using MeuProjeto.Application.Responses.Orders;
using MeuProjeto.Domain.ValueObjects;
using MeuProjeto.SharedKernel.Validators;
using OperationResult;

namespace MeuProjeto.Application.Commands.Orders;

public record CreateOrderCommand(
    string Customer,
    decimal TotalAmount,
    string Street,
    string City,
    string State,
    string Cep)
: IRequest<Result<CreateOrderResponse>>, IValidatableRequest
{
    [JsonIgnore]
    public Address DeliveryAddress => new(Street, City, State, Cep);
}
