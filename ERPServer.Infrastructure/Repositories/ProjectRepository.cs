using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using ERPServer.Infrastructure.Context;
using GenericRepository;

namespace ERPServer.Infrastructure.Repositories;
internal sealed class ProjectRepository : Repository<Project, ApplicationDbContext>, IProjectRepository
{
    public ProjectRepository(ApplicationDbContext context) : base(context)
    {
    }
}
