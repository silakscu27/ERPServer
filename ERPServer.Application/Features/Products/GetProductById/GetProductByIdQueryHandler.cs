using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Products.GetProductById;

internal sealed class GetProductByIdQueryHandler(
    IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Result<Product>>
{
    public async Task<Result<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        Product? product = await productRepository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
        {
            return Result<Product>.Failure("Ürün bulunamadı");
        }

        return product;
    }
}
