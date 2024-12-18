using ERPServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Stocks.GetStockById;

public sealed record GetStockByIdQuery(Guid Id) : IRequest<Result<Stock>>;
