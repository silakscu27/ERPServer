using ERPServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Products.GetProductById;

public sealed record GetProductByIdQuery(Guid Id) : IRequest<Result<Product>>;