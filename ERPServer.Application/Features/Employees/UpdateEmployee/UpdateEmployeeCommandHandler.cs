using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Employees.UpdateEmployee;

internal sealed class UpdateEmployeeCommandHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateEmployeeCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        Employee employee = await employeeRepository.GetByExpressionWithTrackingAsync(
            e => e.Id == request.Id, cancellationToken);

        if (employee is null)
        {
            return Result<string>.Failure("Çalışan bulunamadı");
        }

        mapper.Map(request, employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Çalışan bilgileri başarıyla güncellendi";
    }
}
