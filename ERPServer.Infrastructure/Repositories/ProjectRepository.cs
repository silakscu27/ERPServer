using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using ERPServer.Infrastructure.Context;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace ERPServer.Infrastructure.Repositories;
internal sealed class ProjectRepository : Repository<Project, ApplicationDbContext>, IProjectRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ProjectRepository(ApplicationDbContext context) : base(context)
    {
        _dbContext = context;
    }
    public async Task<Project?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Project>()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}
