using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Employees.UpdateEmployee;

public sealed record UpdateEmployeeCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Position,
    Guid DepartmentId,
    DateTime HireDate,
    decimal Salary) : IRequest<Result<string>>;
