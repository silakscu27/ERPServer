using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities;

public sealed class Product : Entity
{
    public new Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Guid StockId { get; set; }

    public Stock Stock { get; set; } = null!;
}
