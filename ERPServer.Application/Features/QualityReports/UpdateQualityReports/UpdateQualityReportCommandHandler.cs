using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityReports.UpdateQualityReports;

internal sealed class UpdateQualityReportCommandHandler(
    IQualityReportRepository qualityReportRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateQualityReportCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateQualityReportCommand request, CancellationToken cancellationToken)
    {
        // Fetch the QualityReport with tracking
        var qualityReport = await qualityReportRepository.GetByExpressionWithTrackingAsync(
            q => q.Id == request.Id, cancellationToken);

        if (qualityReport is null)
        {
            return Result<string>.Failure("Kalite raporu bulunamadı");
        }

        // Map the updated fields from the command to the entity
        mapper.Map(request, qualityReport);

        // Save changes
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Kalite raporu başarıyla güncellendi");
    }
}
