using ERPServer.Domain.Entities;
using GenericRepository;
using System.Linq.Expressions;

namespace ERPServer.Domain.Repositories;
public interface IEquipmentRepository : IRepository<Equipment>
{
    Task<Equipment?> FindAsync(Expression<Func<Equipment, bool>> predicate, CancellationToken cancellationToken);
}
