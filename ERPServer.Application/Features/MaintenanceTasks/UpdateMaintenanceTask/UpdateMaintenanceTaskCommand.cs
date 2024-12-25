using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.MaintenanceTasks.UpdateMaintenanceTask;

public sealed record UpdateMaintenanceTaskCommand(
    Guid Id,
    string TaskName,
    string Description,
    DateTime ScheduledDate,
    bool IsCompleted) : IRequest<Result<string>>;
