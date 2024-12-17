using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Stocks.DeleteStockById;

internal sealed class DeleteStockByIdCommandHandler(
    IStockRepository stockRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteStockByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteStockByIdCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the stock by its ID
        Stock stock = await stockRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

        // If the stock does not exist, return a failure result
        if (stock is null)
        {
            return Result<string>.Failure("Stok bulunamadı");
        }

        // Delete the stock
        stockRepository.Delete(stock);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        // Return a success message
        return "Stok başarıyla silindi";
    }
}
