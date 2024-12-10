using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities
{
    public sealed class OrderCustomer : Entity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
