using MediatR;
using OperationResult;

namespace MeuProjeto.Application.Commands.Orders;

public sealed record ApproveOrderCommand(Guid OrderId): IRequest<Result>;
