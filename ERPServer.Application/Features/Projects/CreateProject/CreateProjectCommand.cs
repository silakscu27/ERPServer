using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Projects.CreateProject;

public sealed record CreateProjectCommand(
    string Name,
    string Description,
    DateTime StartDate,
    DateTime? EndDate,
    string Status) : IRequest<Result<string>>;
