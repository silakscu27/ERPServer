using ERPServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Equipments.GetAllEquipment;

public sealed record GetAllEquipmentQuery() : IRequest<Result<List<Equipment>>>;
