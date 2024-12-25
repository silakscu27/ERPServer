using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.MaintenanceTasks.UpdateMaintenanceTask;

internal sealed class UpdateMaintenanceTaskCommandHandler(
    IMaintenanceTaskRepository maintenanceTaskRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateMaintenanceTaskCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateMaintenanceTaskCommand request, CancellationToken cancellationToken)
    {
        MaintenanceTask maintenanceTask = await maintenanceTaskRepository.GetByExpressionWithTrackingAsync(
            mt => mt.Id == request.Id, cancellationToken);

        if (maintenanceTask is null)
        {
            return Result<string>.Failure("Bakım görevi bulunamadı");
        }

        // Gelen komutun verilerini mevcut entity'ye uygula
        mapper.Map(request, maintenanceTask);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Bakım görevi başarıyla güncellendi";
    }
}
