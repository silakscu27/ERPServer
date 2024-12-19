using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Products.UpdateProduct;

internal sealed class UpdateProductCommandHandler(
    IProductRepository productRepository,
    IStockRepository stockRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateProductCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await productRepository.GetByExpressionWithTrackingAsync(
            p => p.Id == request.Id, cancellationToken);

        if (product is null)
        {
            return Result<string>.Failure("Ürün bulunamadı");
        }

        Stock? stock = await stockRepository.GetByIdAsync(request.StockId, cancellationToken);
        if (stock is null)
        {
            return Result<string>.Failure("Geçersiz stok ID");
        }

        mapper.Map(request, product);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Ürün başarıyla güncellendi";
    }
}