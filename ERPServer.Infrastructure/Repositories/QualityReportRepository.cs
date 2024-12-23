using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using ERPServer.Infrastructure.Context;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace ERPServer.Infrastructure.Repositories;
internal sealed class QualityReportRepository : Repository<QualityReport, ApplicationDbContext>, IQualityReportRepository
{
    private readonly ApplicationDbContext _dbContext;
    public QualityReportRepository(ApplicationDbContext context) : base(context)
    {
        _dbContext = context;
    }
    public async Task<QualityReport?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<QualityReport>()
                             .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}
