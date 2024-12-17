using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Stocks.CreateStock;

internal sealed class CreateStockCommandHandler(
    IStockRepository stockRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateStockCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateStockCommand request, CancellationToken cancellationToken)
    {
        // Check if a stock with the same name already exists
        bool isStockExists = await stockRepository.AnyAsync(
            p => p.ProductName == request.ProductName && p.CategoryId == request.CategoryId,
            cancellationToken);

        if (isStockExists)
        {
            return Result<string>.Failure("Bu kategori altında aynı isimde bir stok zaten mevcut");
        }

        // Map command to entity
        Stock stock = mapper.Map<Stock>(request);
        stock.LastUpdatedDate = DateTime.UtcNow;

        // Add and save stock
        await stockRepository.AddAsync(stock, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Stok başarıyla eklendi");
    }
}
