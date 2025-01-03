using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Projects.CreateProject;

public sealed record CreateProjectCommand(
    string Name,
    DateTime StartDate,
    DateTime? EndDate,
    string Status) : IRequest<Result<string>>;
