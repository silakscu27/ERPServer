using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Departments.UpdateDepartment;

internal sealed class UpdateDepartmentCommandHandler(
    IDepartmentRepository departmentRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateDepartmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        Department department = await departmentRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if (department is null)
        {
            return Result<string>.Failure("Departman bulunamadı");
        }

        mapper.Map(request, department);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Departman bilgileri başarıyla güncellendi";
    }
}
