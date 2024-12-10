using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Orders.UpdateOrder;

public sealed record UpdateOrderCommand(
    Guid Id,
    Guid CustomerId,
    DateTime OrderDate,
    decimal TotalAmount,
    string Status) : IRequest<Result<string>>;
