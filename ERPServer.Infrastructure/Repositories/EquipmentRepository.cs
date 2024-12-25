using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using ERPServer.Infrastructure.Context;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ERPServer.Infrastructure.Repositories;
internal sealed class EquipmentRepository : Repository<Equipment, ApplicationDbContext>, IEquipmentRepository
{
    private readonly ApplicationDbContext _dbContext;
    public EquipmentRepository(ApplicationDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public async Task<Equipment?> FindAsync(Expression<Func<Equipment, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Equipment>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<Equipment?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Equipment>().FindAsync(new object[] { id }, cancellationToken);
    }
}