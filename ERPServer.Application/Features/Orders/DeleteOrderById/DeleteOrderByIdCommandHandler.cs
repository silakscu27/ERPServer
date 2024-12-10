﻿using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Orders.DeleteOrderById;

internal sealed class DeleteOrderByIdCommandHandler(
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteOrderByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
    {
        // Retrieve order by ID
        Order order = await orderRepository.GetByExpressionAsync(o => o.Id == request.Id, cancellationToken);

        if (order is null)
        {
            return Result<string>.Failure("Sipariş bulunamadı");
        }

        // Delete order
        orderRepository.Delete(order);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Sipariş başarıyla silindi");
    }
}
