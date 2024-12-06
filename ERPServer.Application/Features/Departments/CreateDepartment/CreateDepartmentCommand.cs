using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Departments.CreateDepartment;

public sealed record CreateDepartmentCommand(
    string Name,
    string? Description) : IRequest<Result<string>>;
