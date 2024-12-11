using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities;

public sealed class Stock : Entity
{
    public new Guid Id { get; set; }
    public string ProductName { get; set; } = string.Empty; 
    public Guid CategoryId { get; set; } 
    public int Quantity { get; set; } 
    public decimal Price { get; set; }
    public DateTime LastUpdatedDate { get; set; } 

    public Category Category { get; set; } = null!; 
