using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Orders.CreateOrder;

internal sealed class CreateOrderCommandHandler(
    IOrderRepository orderRepository,
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // Get customer information
        var customers = await customerRepository.GetByIdsAsync(request.CustomerIds.ToList(), cancellationToken);
        if (customers.Count() != request.CustomerIds.Count())
        {
            return Result<string>.Failure("Bazı müşteri ID'leri geçersiz.");
        }

        // Create an order
        var order = new Order
        {
            Id = Guid.NewGuid(),
            OrderDate = request.OrderDate,
            TotalAmount = request.TotalAmount,
            Status = request.Status,
            OrderCustomers = customers.Select(customer => new OrderCustomer
            {
                Customer = customer
            }).ToList()
        };

        // Save order
        await orderRepository.AddAsync(order, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Sipariş başarıyla oluşturuldu.");
    }
}
