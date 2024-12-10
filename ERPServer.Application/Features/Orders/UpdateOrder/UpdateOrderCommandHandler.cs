using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Orders.UpdateOrder;

internal sealed class UpdateOrderCommandHandler(
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateOrderCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        // Siparişi ID'ye göre al
        Order order = await orderRepository.GetByExpressionWithTrackingAsync(
            o => o.Id == request.Id, cancellationToken);

        if (order is null)
        {
            return Result<string>.Failure("Sipariş bulunamadı");
        }

        // Siparişi güncelle
        mapper.Map(request, order);

        // Değişiklikleri kaydet
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Sipariş başarıyla güncellendi");
    }
}
