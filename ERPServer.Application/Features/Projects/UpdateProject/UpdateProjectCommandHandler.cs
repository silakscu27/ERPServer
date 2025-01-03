using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Projects.UpdateProject;

internal sealed class UpdateProjectCommandHandler(
    IProjectRepository projectRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateProjectCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {

        Project project = await projectRepository.GetByExpressionWithTrackingAsync(
            p => p.Id == request.Id, cancellationToken);

        if (project is null)
        {
            return Result<string>.Failure("Proje bulunamadı");
        }

        mapper.Map(request, project);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Proje başarıyla güncellendi";
    }
}
