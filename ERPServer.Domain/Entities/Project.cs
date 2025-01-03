using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities;

public sealed class Project : Entity
{
    public new Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; } 
    public string Status { get; set; } = string.Empty; 

}
