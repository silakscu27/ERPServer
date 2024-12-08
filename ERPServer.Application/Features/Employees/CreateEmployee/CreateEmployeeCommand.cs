using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Employees.CreateEmployee;

public sealed record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    string Position,
    Guid DepartmentId,
    DateTime HireDate,
    decimal Salary) : IRequest<Result<string>>;
