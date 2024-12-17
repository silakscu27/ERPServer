using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Stocks.UpdateStock;

public sealed record UpdateStockCommand(
    Guid Id,
    string ProductName,
    Guid CategoryId,
    int Quantity,
    decimal Price,
    DateTime LastUpdatedDate) : IRequest<Result<string>>;
