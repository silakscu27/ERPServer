using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities;

public sealed class QualityCheck : Entity
{
    public new Guid Id { get; set; }
    public DateTime CheckDate { get; set; }
    public Guid ReportId { get; set; }

    public string Checkpoint { get; set; } = string.Empty;
    public string Result { get; set; } = string.Empty;

    public QualityReport QualityReport { get; set; } = null!;
}
