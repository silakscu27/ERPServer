using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Departments.UpdateDepartment;

public sealed record UpdateDepartmentCommand(
    Guid Id,
    string Name,
    string? Description) : IRequest<Result<string>>;
