using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Orders.CreateOrder;

public sealed record CreateOrderCommand(
    DateTime OrderDate,
    decimal TotalAmount,
    string Status,
    ICollection<Guid> CustomerIds) : IRequest<Result<string>>;
