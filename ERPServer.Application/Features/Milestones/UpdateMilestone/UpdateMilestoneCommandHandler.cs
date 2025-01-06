using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Milestones.UpdateMilestone;

internal sealed class UpdateMilestoneCommandHandler(
    IMilestoneRepository milestoneRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateMilestoneCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateMilestoneCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the milestone by its ID with tracking
        Milestone milestone = await milestoneRepository.GetByExpressionWithTrackingAsync(
            m => m.Id == request.Id, cancellationToken);

        if (milestone is null)
        {
            return Result<string>.Failure("Aşama bulunamadı");
        }

        // Map the request properties to the milestone entity
        mapper.Map(request, milestone);

        // Save changes
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Aşama bilgileri başarıyla güncellendi";
    }
}
