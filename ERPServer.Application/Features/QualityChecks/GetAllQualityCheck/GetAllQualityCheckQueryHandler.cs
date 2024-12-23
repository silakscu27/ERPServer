using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.QualityChecks.GetAllQualityCheck;

internal sealed class GetAllQualityCheckQueryHandler(
    IQualityChecksRepository qualityCheckRepository) : IRequestHandler<GetAllQualityCheckQuery, Result<List<QualityCheck>>>
{
    public async Task<Result<List<QualityCheck>>> Handle(GetAllQualityCheckQuery request, CancellationToken cancellationToken)
    {
        // Fetch all QualityCheck entities and order them by CheckDate
        List<QualityCheck> qualityChecks = await qualityCheckRepository.GetAll()
            .OrderBy(q => q.CheckDate)
            .ToListAsync(cancellationToken);
     
        return qualityChecks;
    }
}
