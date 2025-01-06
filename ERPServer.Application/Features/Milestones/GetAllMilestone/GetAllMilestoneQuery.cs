using ERPServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Milestones.GetAllMilestone;

public sealed record GetAllMilestoneQuery() : IRequest<Result<List<Milestone>>>;
