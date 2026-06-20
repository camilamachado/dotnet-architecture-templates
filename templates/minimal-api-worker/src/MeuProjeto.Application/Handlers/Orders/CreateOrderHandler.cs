using MediatR;
using MeuProjeto.Application.Commands.Orders;
using MeuProjeto.Application.Mappers;
using MeuProjeto.Application.Responses.Orders;
using MeuProjeto.Domain.Repositories.Orders;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace MeuProjeto.Application.Handlers.Orders;

public sealed partial class CreateOrderHandler(
    IOrderRepository orderRepository,
    ILogger<CreateOrderHandler> logger)
: IRequestHandler<CreateOrderCommand, Result<CreateOrderResponse>>
{
    public async Task<Result<CreateOrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        LogOrderCreationStarted(logger, request.Customer, request.TotalAmount);

        var order = request.ToEntity();

        orderRepository.Add(order);

        await orderRepository.SaveChangesAsync();

        LogOrderCreated(logger, order.Id, order.Customer);

        return Result.Success(order.ToCreateOrderResponse());
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Iniciando a criação do pedido para o cliente '{Customer}' com valor total de {TotalAmount}")]
    private static partial void LogOrderCreationStarted(ILogger logger, string customer, decimal totalAmount);

    [LoggerMessage(Level = LogLevel.Information, Message = "Pedido '{OrderId}' criado e persistido com sucesso para o cliente '{Customer}'")]
    private static partial void LogOrderCreated(ILogger logger, Guid orderId, string customer);
}
