using ERPServer.Domain.Entities;
using GenericRepository;

namespace ERPServer.Domain.Repositories;
public interface ICustomerRepository : IRepository<Customer>
{
    Task<List<Customer>> GetByIdsAsync(List<Guid> customerIds, CancellationToken cancellationToken);
}
