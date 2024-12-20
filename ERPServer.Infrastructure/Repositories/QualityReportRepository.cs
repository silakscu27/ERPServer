using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using ERPServer.Infrastructure.Context;
using GenericRepository;

namespace ERPServer.Infrastructure.Repositories;
internal sealed class QualityReportRepository : Repository<QualityReport, ApplicationDbContext>, IQualityReportRepository
{
    public QualityReportRepository(ApplicationDbContext context) : base(context)
    {
    }
}
