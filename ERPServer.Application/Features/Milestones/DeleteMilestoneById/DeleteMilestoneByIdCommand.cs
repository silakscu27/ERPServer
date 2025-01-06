using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Milestones.DeleteMilestoneById;

public sealed record DeleteMilestoneByIdCommand(
    Guid Id) : IRequest<Result<string>>;
