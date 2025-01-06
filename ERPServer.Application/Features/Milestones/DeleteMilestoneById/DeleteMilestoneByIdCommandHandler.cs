using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Milestones.DeleteMilestoneById;

internal sealed class DeleteMilestoneByIdCommandHandler(
    IMilestoneRepository milestoneRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteMilestoneByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteMilestoneByIdCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the milestone by its ID
        Milestone? milestone = await milestoneRepository.GetByExpressionAsync(m => m.Id == request.Id, cancellationToken);

        if (milestone is null)
        {
            return Result<string>.Failure("Aşama bulunamadı");
        }

        // Delete the milestone
        milestoneRepository.Delete(milestone);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Aşama başarıyla silindi";
    }
}
