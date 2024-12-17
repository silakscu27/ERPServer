using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Stocks.CreateStock;

public sealed record CreateStockCommand(
    string ProductName,
    Guid CategoryId,
    int Quantity,
    decimal Price) : IRequest<Result<string>>;
