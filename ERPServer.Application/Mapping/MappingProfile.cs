using AutoMapper;
using ERPServer.Application.Features.Customers.CreateCustomer;
using ERPServer.Application.Features.Customers.UpdateCustomer;
using ERPServer.Application.Features.Depots.CreateDepot;
using ERPServer.Application.Features.Depots.UpdateDepot;
using ERPServer.Application.Features.Orders.CreateOrder;
using ERPServer.Application.Features.Orders.UpdateOrder;
using ERPServer.Domain.Entities;
namespace ERPServer.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();

            CreateMap<CreateDepotCommand, Depot>();
            CreateMap<UpdateDepotCommand, Depot>();

            CreateMap<CreateOrderCommand, Order>()
            .ForMember(member => member.Details,
            options =>
            options.MapFrom(p => p.Details.Select(s => new OrderDetail
            {
                Price = s.Price,
                ProductId = s.ProductId,
                Quantity = s.Quantity
            }).ToList()));

            CreateMap<UpdateOrderCommand, Order>()
                .ForMember(member =>
                member.Details,
                options => options.Ignore());
        }
    }
}
