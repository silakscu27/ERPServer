using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using ERPServer.Infrastructure.Context;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace ERPServer.Infrastructure.Repositories
{
    internal sealed class CustomerRepository : Repository<Customer, ApplicationDbContext>, ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<Customer>> GetByIdsAsync(List<Guid> customerIds, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers
                .Where(c => customerIds.Contains(c.Id))
                .ToListAsync(cancellationToken);
        }
    }
}
