using ERPServer.Domain.Entities;
using GenericRepository;

namespace ERPServer.Domain.Repositories;
public interface IProjectRepository : IRepository<Project>
{
    Task<Project?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}