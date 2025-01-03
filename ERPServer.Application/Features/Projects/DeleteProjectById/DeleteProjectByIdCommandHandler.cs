using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Projects.DeleteProjectById;

internal sealed class DeleteProjectByIdCommandHandler(
    IProjectRepository projectRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteProjectByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteProjectByIdCommand request, CancellationToken cancellationToken)
    {
        Project project = await projectRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

        if (project is null)
        {
            return Result<string>.Failure("Proje bulunamadı");
        }

        projectRepository.Delete(project);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Proje başarıyla silindi";
    }
}
