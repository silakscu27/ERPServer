using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities;

public sealed class Order : Entity
{
    public new Guid Id { get; set; } 

    public Guid CustomerId { get; set; } 

    public DateTime OrderDate { get; set; } 

    public decimal TotalAmount { get; set; } 

    public string Status { get; set; } = string.Empty; 

    public Customer Customer { get; set; } = null!; 
}
