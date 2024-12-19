using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Products.CreateProduct;

internal sealed class CreateProductCommandHandler(
    IProductRepository productRepository,
    IStockRepository stockRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateProductCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Check if the stock exists
        var stock = await stockRepository.GetByIdAsync(request.StockId, cancellationToken);
        if (stock is null)
        {
            return Result<string>.Failure("Geçersiz Stok ID");
        }

        // Map request to Product entity
        var product = mapper.Map<Product>(request);
        product.Id = Guid.NewGuid();

        // Save the product
        await productRepository.AddAsync(product, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Ürün başarıyla oluşturuldu");
    }
}
