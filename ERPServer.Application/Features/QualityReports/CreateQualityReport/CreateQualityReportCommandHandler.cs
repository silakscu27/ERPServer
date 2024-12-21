using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityReports.CreateQualityReports;

internal sealed class CreateQualityReportCommandHandler(
    IQualityReportRepository qualityReportRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateQualityReportCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateQualityReportCommand request, CancellationToken cancellationToken)
    {
        // Map request to QualityReport entity
        var qualityReport = mapper.Map<QualityReport>(request);
        qualityReport.Id = Guid.NewGuid();

        // Save the quality report
        await qualityReportRepository.AddAsync(qualityReport, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Kalite raporu başarıyla oluşturuldu");
    }
}
