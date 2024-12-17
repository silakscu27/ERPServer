using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Categories.UpdateCategory;

public sealed record UpdateCategoryCommand(
    Guid Id,
    string Name,
    string? Description) : IRequest<Result<string>>;
