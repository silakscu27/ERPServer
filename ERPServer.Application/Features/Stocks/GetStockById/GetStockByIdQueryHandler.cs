using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.Stocks.GetStockById;

internal sealed class GetStockByIdQueryHandler(
    IStockRepository stockRepository) : IRequestHandler<GetStockByIdQuery, Result<Stock>>
{
    public async Task<Result<Stock>> Handle(GetStockByIdQuery request, CancellationToken cancellationToken)
    {
        Stock? stock = await stockRepository.GetAll()
            .Include(s => s.Products) 
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

        if (stock is null)
        {
            return Result<Stock>.Failure("Stok bulunamadı.");
        }

        return Result<Stock>.Succeed(stock);
    }
}
