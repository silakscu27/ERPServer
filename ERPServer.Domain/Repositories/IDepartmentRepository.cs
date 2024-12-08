using ERPServer.Domain.Entities;
using GenericRepository;

namespace ERPServer.Domain.Repositories;

public interface IDepartmentRepository : IRepository<Department>
{
    Task<Department?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
