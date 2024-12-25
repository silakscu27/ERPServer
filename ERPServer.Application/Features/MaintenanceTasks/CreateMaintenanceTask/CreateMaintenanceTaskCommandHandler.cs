using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.MaintenanceTasks.CreateMaintenanceTask;

internal sealed class CreateMaintenanceTaskCommandHandler(
    IMaintenanceTaskRepository maintenanceTaskRepository,
    IEquipmentRepository equipmentRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateMaintenanceTaskCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateMaintenanceTaskCommand request, CancellationToken cancellationToken)
    {
        var equipment = await equipmentRepository.GetByIdAsync(request.EquipmentId, cancellationToken);
        if (equipment is null)
        {
            return Result<string>.Failure("Geçersiz Ekipman ID");
        }

        var maintenanceTask = mapper.Map<MaintenanceTask>(request);
        maintenanceTask.Id = Guid.NewGuid();

        await maintenanceTaskRepository.AddAsync(maintenanceTask, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Bakım görevi başarıyla oluşturuldu";
    }
}
