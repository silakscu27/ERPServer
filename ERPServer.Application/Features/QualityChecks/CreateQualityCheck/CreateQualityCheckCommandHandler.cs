using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityChecks.CreateQualityCheck;

internal sealed class CreateQualityCheckCommandHandler(
    IQualityChecksRepository qualityCheckRepository,
    IQualityReportRepository qualityReportRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateQualityCheckCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateQualityCheckCommand request, CancellationToken cancellationToken)
    {
        // Check if the related QualityReport exists
        var qualityReport = await qualityReportRepository.GetByIdAsync(request.ReportId, cancellationToken);
        if (qualityReport is null)
        {
            return Result<string>.Failure("Geçersiz Rapor ID");
        }

        // Map request to QualityCheck entity
        var qualityCheck = mapper.Map<QualityCheck>(request);
        qualityCheck.Id = Guid.NewGuid();

        // Save the quality check
        await qualityCheckRepository.AddAsync(qualityCheck, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Kalite kontrol başarıyla oluşturuldu");
    }
}
