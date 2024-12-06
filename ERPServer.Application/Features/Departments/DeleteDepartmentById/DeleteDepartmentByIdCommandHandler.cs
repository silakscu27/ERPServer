using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Departments.DeleteDepartmentById;

internal sealed class DeleteDepartmentByIdCommandHandler(
    IDepartmentRepository departmentRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteDepartmentByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteDepartmentByIdCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the department by its ID
        Department department = await departmentRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

        if (department is null)
        {
            return Result<string>.Failure("Departman bulunamadı");
        }

        // Delete the department
        departmentRepository.Delete(department);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Departman başarıyla silindi";
    }
}
