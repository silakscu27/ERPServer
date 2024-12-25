using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.MaintenanceTasks.DeleteMaintenanceTaskById;

public sealed record DeleteMaintenanceTaskByIdCommand(
    Guid Id) : IRequest<Result<string>>;
