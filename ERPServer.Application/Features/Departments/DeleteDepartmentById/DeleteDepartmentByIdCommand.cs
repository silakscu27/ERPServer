using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Departments.DeleteDepartmentById;

public sealed record DeleteDepartmentByIdCommand(
    Guid Id) : IRequest<Result<string>>;
