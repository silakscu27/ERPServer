using ERPServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Stocks.GetAllStock;

public sealed record GetAllStockQuery() : IRequest<Result<List<Stock>>>;
