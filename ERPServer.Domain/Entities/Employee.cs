using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities;

public sealed class Employee : Entity
{
    public new Guid Id { get; set; } 
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty; 
    public string Position { get; set; } = string.Empty; 
    public Guid DepartmentId { get; set; } 
    public DateTime HireDate { get; set; } 
    public decimal Salary { get; set; }

    public Department Department { get; set; } = null!;
}
