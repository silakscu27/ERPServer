using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.Stocks.GetAllStock;

internal sealed class GetAllStockQueryHandler(
    IStockRepository stockRepository) : IRequestHandler<GetAllStockQuery, Result<List<Stock>>>
{
    public async Task<Result<List<Stock>>> Handle(GetAllStockQuery request, CancellationToken cancellationToken)
    {
        // Retrieve all stocks, order them by ProductName, and convert to a list
        List<Stock> stocks = await stockRepository.GetAll()
            .OrderBy(p => p.ProductName)
            .ToListAsync(cancellationToken);

        // Return stocks if found, otherwise return a failure message
        return stocks.Any()
            ? Result<List<Stock>>.Succeed(stocks)
            : Result<List<Stock>>.Failure("Stok bulunamadı");
    }
}
