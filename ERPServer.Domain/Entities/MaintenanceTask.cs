using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities;

public sealed class MaintenanceTask : Entity
{
    public new Guid Id { get; set; }
    public Guid EquipmentId { get; set; }
    public string TaskName { get; set; } = string.Empty;
    public DateTime ScheduledDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public Equipment Equipment { get; set; } = null!;

}
