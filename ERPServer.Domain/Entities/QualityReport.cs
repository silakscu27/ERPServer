using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities;

public sealed class QualityReport : Entity
{
    public new Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public string? Description { get; set; }

    public ICollection<QualityCheck> QualityChecks { get; set; } = new HashSet<QualityCheck>();
}