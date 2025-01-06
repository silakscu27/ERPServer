using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Milestones.UpdateMilestone;

public sealed record UpdateMilestoneCommand(
    Guid Id,
    string MilestoneName,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    decimal Budget) : IRequest<Result<string>>;
