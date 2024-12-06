using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.Departments.GetAllDepartment;

internal sealed class GetAllDepartmentQueryHandler(
    IDepartmentRepository departmentRepository) : IRequestHandler<GetAllDepartmentQuery, Result<List<Department>>>
{
    public async Task<Result<List<Department>>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
    {
        // Fetch all departments and order them by name
        List<Department> departments = await departmentRepository.GetAll()
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);

        return departments;
    }
}
