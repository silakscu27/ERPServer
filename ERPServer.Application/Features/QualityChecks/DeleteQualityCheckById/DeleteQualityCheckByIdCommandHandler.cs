using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.QualityChecks.DeleteQualityCheckById;

internal sealed class DeleteQualityCheckByIdCommandHandler(
    IQualityChecksRepository qualityCheckRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteQualityCheckByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteQualityCheckByIdCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the QualityCheck entity by its ID
        var qualityCheck = await qualityCheckRepository.GetByExpressionAsync(q => q.Id == request.Id, cancellationToken);

        if (qualityCheck is null)
        {
            return Result<string>.Failure("Kalite kontrol kaydı bulunamadı");
        }

        // Delete the QualityCheck entity
        qualityCheckRepository.Delete(qualityCheck);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Kalite kontrol kaydı başarıyla silindi";
    }
}
