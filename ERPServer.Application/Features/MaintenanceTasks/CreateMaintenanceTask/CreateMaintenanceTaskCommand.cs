using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.MaintenanceTasks.CreateMaintenanceTask;

public sealed record CreateMaintenanceTaskCommand(
    string TaskName,
    DateTime ScheduledDate,
    string? Status,
    Guid EquipmentId) : IRequest<Result<string>>;
