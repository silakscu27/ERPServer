using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Projects.CreateProject;

internal sealed class CreateProjectCommandHandler(
    IProjectRepository projectRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateProjectCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        if (request.EndDate.HasValue && request.EndDate.Value < request.StartDate)
        {
            return Result<string>.Failure("Bitiş tarihi başlangıç tarihinden önce olamaz");
        }

        var project = mapper.Map<Project>(request);
        project.Id = Guid.NewGuid(); 

        await projectRepository.AddAsync(project, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Proje başarıyla oluşturuldu";
    }
}
