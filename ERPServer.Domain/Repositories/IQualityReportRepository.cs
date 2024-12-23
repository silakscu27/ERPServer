using ERPServer.Domain.Entities;
using GenericRepository;

namespace ERPServer.Domain.Repositories;
public interface IQualityReportRepository : IRepository<QualityReport>
{
    Task<QualityReport?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}