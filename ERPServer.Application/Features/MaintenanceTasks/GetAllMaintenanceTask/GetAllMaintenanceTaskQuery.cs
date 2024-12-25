using ERPServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.MaintenanceTasks.GetAllMaintenanceTask;

public sealed record GetAllMaintenanceTaskQuery() : IRequest<Result<List<MaintenanceTask>>>;
