using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities;

public sealed class Milestone : Entity
{
    public new Guid Id { get; set; } 
    public Guid ProjectId { get; set; } 
    public string MilestoneName { get; set; } = string.Empty; 
    public int EstimatedTime { get; set; }

    public Project Project { get; set; } = default!; 
}
