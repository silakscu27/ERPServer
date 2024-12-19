using ERPServer.Domain.Entities;
using GenericRepository;

namespace ERPServer.Domain.Repositories;
public interface IStockRepository : IRepository<Stock>
{
    Task<Stock?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}