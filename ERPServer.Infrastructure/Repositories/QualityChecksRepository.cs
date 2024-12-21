using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using ERPServer.Infrastructure.Context;
using GenericRepository;

namespace ERPServer.Infrastructure.Repositories;
internal sealed class QualityChecksRepository : Repository<QualityChecks, ApplicationDbContext>, IQualityChecksRepository
{
    public QualityChecksRepository(ApplicationDbContext context) : base(context)
    {
    }
}
