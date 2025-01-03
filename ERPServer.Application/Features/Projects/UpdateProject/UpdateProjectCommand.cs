using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Projects.UpdateProject;

public sealed record UpdateProjectCommand(
    Guid Id,
    string Name,
    DateTime StartDate,
    DateTime EndDate,
    string Status) : IRequest<Result<string>>;
