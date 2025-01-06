using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Milestones.CreateMilestone;

public sealed record CreateMilestoneCommand(
    Guid ProjectId,
    string MilestoneName,
    int EstimatedTime) : IRequest<Result<string>>;
