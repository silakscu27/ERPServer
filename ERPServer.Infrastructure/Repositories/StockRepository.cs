using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using ERPServer.Infrastructure.Context;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

internal sealed class StockRepository : Repository<Stock, ApplicationDbContext>, IStockRepository
{
    private readonly ApplicationDbContext _dbContext;
    public StockRepository(ApplicationDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public async Task<Stock?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Stock>()
                             .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}