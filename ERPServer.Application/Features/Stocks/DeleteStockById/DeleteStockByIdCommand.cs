using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Stocks.DeleteStockById;

public sealed record DeleteStockByIdCommand(
    Guid Id) : IRequest<Result<string>>;
