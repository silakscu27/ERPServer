using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.Milestones.GetAllMilestone;

internal sealed class GetAllMilestoneQueryHandler(
    IMilestoneRepository milestoneRepository) : IRequestHandler<GetAllMilestoneQuery, Result<List<Milestone>>>
{
    public async Task<Result<List<Milestone>>> Handle(GetAllMilestoneQuery request, CancellationToken cancellationToken)
    {
        // Fetch all milestones and order them by name
        List<Milestone> milestones = await milestoneRepository.GetAll()
            .OrderBy(m => m.MilestoneName)
            .ToListAsync(cancellationToken);

        return milestones;
    }
}
