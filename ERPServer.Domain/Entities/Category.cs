using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities;

public sealed class Category : Entity
{
    public new Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } 

    public ICollection<Stock> Stocks { get; set; } = new HashSet<Stock>();
}
