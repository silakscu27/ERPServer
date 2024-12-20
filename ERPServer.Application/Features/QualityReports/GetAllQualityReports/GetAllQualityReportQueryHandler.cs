using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.QualityReports.GetAllQualityReports;

internal sealed class GetAllQualityReportQueryHandler(
    IQualityReportRepository qualityReportRepository) : IRequestHandler<GetAllQualityReportQuery, Result<List<QualityReport>>>
{
    public async Task<Result<List<QualityReport>>> Handle(GetAllQualityReportQuery request, CancellationToken cancellationToken)
    {
        // Fetch all quality reports and order them by CreatedDate
        List<QualityReport> qualityReports = await qualityReportRepository.GetAll()
            .OrderBy(q => q.CreatedDate)
            .ToListAsync(cancellationToken);

        return Result<List<QualityReport>>.Succeed(qualityReports);
    }
}