using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Stocks.UpdateStock;

internal sealed class UpdateStockCommandHandler(
    IStockRepository stockRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateStockCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
    {
        Stock stock = await stockRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if (stock is null)
        {
            return Result<string>.Failure("Stok bulunamadı");
        }

        mapper.Map(request, stock);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Stok başarıyla güncellendi");
    }
}
