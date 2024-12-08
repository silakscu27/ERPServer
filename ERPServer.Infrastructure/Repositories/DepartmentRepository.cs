using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using ERPServer.Infrastructure.Context;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace ERPServer.Infrastructure.Repositories;

internal sealed class DepartmentRepository : Repository<Department, ApplicationDbContext>, IDepartmentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public DepartmentRepository(ApplicationDbContext context) : base(context)
    {
        _dbContext = context; 
    }

    public async Task<Department?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Departments
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
    }
}
