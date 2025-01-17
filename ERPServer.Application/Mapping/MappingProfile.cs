﻿using AutoMapper;
using ERPServer.Application.Features.Categories.CreateCategory;
using ERPServer.Application.Features.Categories.UpdateCategory;
using ERPServer.Application.Features.Customers.CreateCustomer;
using ERPServer.Application.Features.Customers.UpdateCustomer;
using ERPServer.Application.Features.Departments.CreateDepartment;
using ERPServer.Application.Features.Departments.UpdateDepartment;
using ERPServer.Application.Features.Employees.CreateEmployee;
using ERPServer.Application.Features.Employees.UpdateEmployee;
using ERPServer.Application.Features.Equipments.CreateEquipment;
using ERPServer.Application.Features.Equipments.UpdateEquipment;
using ERPServer.Application.Features.MaintenanceTasks.CreateMaintenanceTask;
using ERPServer.Application.Features.MaintenanceTasks.UpdateMaintenanceTask;
using ERPServer.Application.Features.Milestones.CreateMilestone;
using ERPServer.Application.Features.Milestones.UpdateMilestone;
using ERPServer.Application.Features.Orders.CreateOrder;
using ERPServer.Application.Features.Orders.UpdateOrder;
using ERPServer.Application.Features.Products.CreateProduct;
using ERPServer.Application.Features.Products.UpdateProduct;
using ERPServer.Application.Features.Projects.CreateProject;
using ERPServer.Application.Features.Projects.UpdateProject;
using ERPServer.Application.Features.QualityChecks.CreateQualityCheck;
using ERPServer.Application.Features.QualityChecks.UpdateQualityCheck;
using ERPServer.Application.Features.QualityReports.CreateQualityReports;
using ERPServer.Application.Features.QualityReports.UpdateQualityReports;
using ERPServer.Application.Features.Stocks.CreateStock;
using ERPServer.Application.Features.Stocks.UpdateStock;
using ERPServer.Domain.Entities;

namespace ERPServer.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Customer mappings
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();

            // Department mappings
            CreateMap<CreateDepartmentCommand, Department>();
            CreateMap<UpdateDepartmentCommand, Department>();

            // Employee mappings
            CreateMap<CreateEmployeeCommand, Employee>();
            CreateMap<UpdateEmployeeCommand, Employee>();

            // Order mappings
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<UpdateOrderCommand, Order>();

            // Stock mappings
            CreateMap<CreateStockCommand, Stock>();
            CreateMap<UpdateStockCommand, Stock>();

            // Category mappings
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();

            // Product mappings
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();

            // Quality Report mappings
            CreateMap<CreateQualityReportCommand, QualityReport>();
            CreateMap<UpdateQualityReportCommand, QualityReport>();

            // Quality Check mappings
            CreateMap<CreateQualityCheckCommand, QualityCheck>();
            CreateMap<UpdateQualityCheckCommand, QualityCheck>();

            // Equipment mappings
            CreateMap<CreateEquipmentCommand, Equipment>();
            CreateMap<UpdateEquipmentCommand, Equipment>();

            // MaintenanceTask mappings
            CreateMap<CreateMaintenanceTaskCommand, MaintenanceTask>();
            CreateMap<UpdateMaintenanceTaskCommand, MaintenanceTask>();

            // Project mappings
            CreateMap<CreateProjectCommand, Project>();
            CreateMap<UpdateProjectCommand, Project>();

            // Milestone mappings
            CreateMap<CreateMilestoneCommand, Milestone>();
            CreateMap<UpdateMilestoneCommand, Milestone>();
        }
    }
}
