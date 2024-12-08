using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Employees.CreateEmployee;

internal sealed class CreateEmployeeCommandHandler(
    IEmployeeRepository employeeRepository,
    IDepartmentRepository departmentRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateEmployeeCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var department = await departmentRepository.GetByIdAsync(request.DepartmentId, cancellationToken);
        if (department is null)
        {
            return Result<string>.Failure("Geçersiz Departman ID");
        }

        var employee = mapper.Map<Employee>(request);
        employee.Id = Guid.NewGuid(); 

        await employeeRepository.AddAsync(employee, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Çalışan başarıyla oluşturuldu";
    }
}
