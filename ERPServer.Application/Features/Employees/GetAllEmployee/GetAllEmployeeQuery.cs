using ERPServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Employees.GetAllEmployee;

public sealed record GetAllEmployeeQuery() : IRequest<Result<List<Employee>>>;
