using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Projects.DeleteProjectById;

public sealed record DeleteProjectByIdCommand(
    Guid Id) : IRequest<Result<string>>;
