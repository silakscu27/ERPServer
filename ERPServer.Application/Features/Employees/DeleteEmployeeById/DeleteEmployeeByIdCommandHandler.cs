using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Employees.DeleteEmployeeById;

internal sealed class DeleteEmployeeByIdCommandHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteEmployeeByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the employee by its ID
        Employee employee = await employeeRepository.GetByExpressionAsync(e => e.Id == request.Id, cancellationToken);

        if (employee is null)
        {
            return Result<string>.Failure("Çalışan bulunamadı");
        }

        // Delete the employee
        employeeRepository.Delete(employee);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Çalışan başarıyla silindi";
    }
}
