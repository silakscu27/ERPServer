using ERPServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Departments.GetAllDepartment;

public sealed record GetAllDepartmentQuery() : IRequest<Result<List<Department>>>;
