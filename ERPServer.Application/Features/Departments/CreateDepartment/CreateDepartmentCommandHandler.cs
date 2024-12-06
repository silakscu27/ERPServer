using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Departments.CreateDepartment;

internal sealed class CreateDepartmentCommandHandler(
    IDepartmentRepository departmentRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateDepartmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        // Check if department with the same name already exists
        bool isDepartmentExists = await departmentRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

        if (isDepartmentExists)
        {
            return Result<string>.Failure("Departman adı zaten kayıtlı");
        }

        // Map request to Department entity
        Department department = mapper.Map<Department>(request);

        await departmentRepository.AddAsync(department, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Departman kaydı başarıyla tamamlandı";
    }
}
