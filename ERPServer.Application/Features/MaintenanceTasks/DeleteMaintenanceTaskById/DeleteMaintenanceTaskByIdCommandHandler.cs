using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.MaintenanceTasks.DeleteMaintenanceTaskById;

internal sealed class DeleteMaintenanceTaskByIdCommandHandler(
    IMaintenanceTaskRepository maintenanceTaskRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteMaintenanceTaskByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteMaintenanceTaskByIdCommand request, CancellationToken cancellationToken)
    {
        MaintenanceTask? maintenanceTask = await maintenanceTaskRepository.GetByExpressionAsync(
            mt => mt.Id == request.Id, cancellationToken);

        if (maintenanceTask is null)
        {
            return Result<string>.Failure("Bakım görevi bulunamadı");
        }

        maintenanceTaskRepository.Delete(maintenanceTask);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Bakım görevi başarıyla silindi";
    }
}
