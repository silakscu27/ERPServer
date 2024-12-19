using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Products.UpdateProduct;

public sealed record UpdateProductCommand(
    Guid Id,
    string Name,
    decimal Price,
    Guid StockId) : IRequest<Result<string>>;