using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using ERPServer.Infrastructure.Context;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

internal sealed class ProductRepository : Repository<Product, ApplicationDbContext>, IProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Product>()
                             .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}