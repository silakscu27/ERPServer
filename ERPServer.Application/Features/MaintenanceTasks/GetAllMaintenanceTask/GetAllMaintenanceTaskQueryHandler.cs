using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.MaintenanceTasks.GetAllMaintenanceTask;

internal sealed class GetAllMaintenanceTaskQueryHandler(
    IMaintenanceTaskRepository maintenanceTaskRepository) : IRequestHandler<GetAllMaintenanceTaskQuery, Result<List<MaintenanceTask>>>
{
    public async Task<Result<List<MaintenanceTask>>> Handle(GetAllMaintenanceTaskQuery request, CancellationToken cancellationToken)
    {
        List<MaintenanceTask> maintenanceTasks = await maintenanceTaskRepository.GetAll()
            .OrderBy(mt => mt.ScheduledDate)
            .ToListAsync(cancellationToken);

        return maintenanceTasks;
    }
}
