using System.Text.Json.Serialization;
using MediatR;
using MeuProjeto.Application.Responses.Orders;
using MeuProjeto.SharedKernel.Validators;
using OperationResult;

namespace MeuProjeto.Application.Commands.Orders;

public record UpdateDeliveryAddressCommand
    : IRequest<Result<UpdateDeliveryAddressResponse>>, IValidatableRequest
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public string Street { get; init; } = string.Empty;

    public string City { get; init; } = string.Empty;

    public string State { get; init; } = string.Empty;

    public string Cep { get; init; } = string.Empty;

    [JsonIgnore]
    public string? UserId { get; set; }

    [JsonIgnore]
    public bool IsAdmin { get; set; }
}
