using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities;

public sealed class Equipment : Entity
{
    public new Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;

    public ICollection<MaintenanceTask> MaintenanceTasks { get; set; } = new List<MaintenanceTask>();
}
