using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.Employees.GetAllEmployee;

internal sealed class GetAllEmployeeQueryHandler(
    IEmployeeRepository employeeRepository) : IRequestHandler<GetAllEmployeeQuery, Result<List<Employee>>>
{
    public async Task<Result<List<Employee>>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        // Fetch all employees and order them by last name
        List<Employee> employees = await employeeRepository.GetAll()
            .OrderBy(e => e.LastName)
            .ToListAsync(cancellationToken);

        return employees;
    }
}
