using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityChecks.UpdateQualityCheck;

internal sealed class UpdateQualityCheckCommandHandler(
    IQualityChecksRepository qualityCheckRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateQualityCheckCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateQualityCheckCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the QualityCheck by ID
        QualityCheck qualityCheck = await qualityCheckRepository.GetByExpressionAsync(q => q.Id == request.Id, cancellationToken);

        if (qualityCheck is null)
        {
            return Result<string>.Failure("Kalite kontrol kaydı bulunamadı.");
        }

        // Update QualityCheck properties
        qualityCheck.CheckDate = request.CheckDate;
        qualityCheck.ReportId = request.ReportId;
        qualityCheck.Checkpoint = request.Checkpoint;
        qualityCheck.Result = request.Result;

        // Save changes
        qualityCheckRepository.Update(qualityCheck);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Kalite kontrol başarıyla güncellendi.");
    }
}
