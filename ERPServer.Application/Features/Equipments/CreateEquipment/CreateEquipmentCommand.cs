using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Equipments.CreateEquipment;

public sealed record CreateEquipmentCommand(
    string Name,
    string SerialNumber,
    string Type) : IRequest<Result<string>>;
