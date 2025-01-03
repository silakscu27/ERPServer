using ERPServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Projects.GetProjectById;

public sealed record GetProjectByIdQuery(Guid Id) : IRequest<Result<Project>>;
