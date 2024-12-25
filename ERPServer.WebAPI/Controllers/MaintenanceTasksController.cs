using ERPServer.Application.Features.MaintenanceTasks.CreateMaintenanceTask;
using ERPServer.Application.Features.MaintenanceTasks.DeleteMaintenanceTaskById;
using ERPServer.Application.Features.MaintenanceTasks.GetAllMaintenanceTask;
using ERPServer.Application.Features.MaintenanceTasks.UpdateMaintenanceTask;
using ERPServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERPServer.WebAPI.Controllers;

public sealed class MaintenanceTasksController : ApiController
{
    public MaintenanceTasksController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(GetAllMaintenanceTaskQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateMaintenanceTaskCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteMaintenanceTaskByIdCommand(id);
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateMaintenanceTaskCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
