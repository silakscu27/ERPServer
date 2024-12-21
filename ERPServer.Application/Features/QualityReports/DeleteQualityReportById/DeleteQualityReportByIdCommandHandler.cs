using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityReports.DeleteQualityReportsById;

internal sealed class DeleteQualityReportsByIdCommandHandler(
    IQualityReportRepository qualityReportRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteQualityReportByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteQualityReportByIdCommand request, CancellationToken cancellationToken)
    {
        // Check if the quality report exists
        var qualityReport = await qualityReportRepository.GetByExpressionAsync(q => q.Id == request.Id, cancellationToken);

        if (qualityReport is null)
        {
            return Result<string>.Failure("Kalite raporu bulunamadı");
        }

        // Delete the quality report
        qualityReportRepository.Delete(qualityReport);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Kalite raporu başarıyla silindi");
    }
}
