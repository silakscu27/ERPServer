using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities;

public sealed class Customer : Entity
{
    public string FirstName { get; set; } = string.Empty; 
    public string LastName { get; set; } = string.Empty; 
    public string PhoneNumber { get; set; } = string.Empty; 
    public string Email { get; set; } = string.Empty; 
    public string TaxDepartment { get; set; } = string.Empty; 
    public string TaxNumber { get; set; } = string.Empty; 
    public string City { get; set; } = string.Empty; 
    public string Town { get; set; } = string.Empty; 
    public string FullAddress { get; set; } = string.Empty;
    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}
