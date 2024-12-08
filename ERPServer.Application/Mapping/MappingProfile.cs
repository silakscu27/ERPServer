﻿using AutoMapper;
using ERPServer.Application.Features.Customers.CreateCustomer;
using ERPServer.Application.Features.Customers.UpdateCustomer;
using ERPServer.Application.Features.Departments.CreateDepartment;
using ERPServer.Application.Features.Departments.UpdateDepartment;
using ERPServer.Application.Features.Employees.CreateEmployee;
using ERPServer.Application.Features.Employees.UpdateEmployee;
using ERPServer.Domain.Entities;
namespace ERPServer.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();

            CreateMap<CreateDepartmentCommand, Department>();
            CreateMap<UpdateDepartmentCommand, Department>();

            CreateMap<CreateEmployeeCommand, Employee>();
            CreateMap<UpdateEmployeeCommand, Employee>();
        }
    }
}
