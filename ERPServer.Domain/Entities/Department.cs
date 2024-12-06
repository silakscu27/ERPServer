using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities;

public sealed class Department : Entity
{
    public new Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
