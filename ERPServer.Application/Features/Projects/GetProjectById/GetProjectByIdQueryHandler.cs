using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Projects.GetProjectById;

internal sealed class GetProjectByIdQueryHandler(
    IProjectRepository projectRepository) : IRequestHandler<GetProjectByIdQuery, Result<Project>>
{
    public async Task<Result<Project>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        Project project = await projectRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

        if (project is null)
        {
            return Result<Project>.Failure("Proje bulunamadı");
        }

        return project;
    }
}
