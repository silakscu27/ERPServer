using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Employees.DeleteEmployeeById;

public sealed record DeleteEmployeeByIdCommand(
    Guid Id) : IRequest<Result<string>>;
