using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Milestones.CreateMilestone;

internal sealed class CreateMilestoneCommandHandler(
    IMilestoneRepository milestoneRepository,
    IProjectRepository projectRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateMilestoneCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateMilestoneCommand request, CancellationToken cancellationToken)
    {
        // Check if Project exists
        var project = await projectRepository.GetByIdAsync(request.ProjectId, cancellationToken);
        if (project is null)
        {
            return Result<string>.Failure("Geçersiz Proje ID");
        }

        // Map request to Milestone entity
        var milestone = mapper.Map<Milestone>(request);
        milestone.Id = Guid.NewGuid();

        // Add to repository
        await milestoneRepository.AddAsync(milestone, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Aşama başarıyla oluşturuldu";
    }
}
