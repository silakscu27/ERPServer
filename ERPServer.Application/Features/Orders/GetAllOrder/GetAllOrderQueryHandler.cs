using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.Orders.GetAllOrder;

internal sealed class GetAllOrderQueryHandler(
    IOrderRepository orderRepository) : IRequestHandler<GetAllOrderQuery, Result<List<Order>>>
{
    public async Task<Result<List<Order>>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        // Retrieve all orders and sort by order date
        List<Order> orders = await orderRepository.GetAll()
            .OrderBy(o => o.OrderDate)
            .ToListAsync(cancellationToken);

        return Result<List<Order>>.Succeed(orders);
    }
}