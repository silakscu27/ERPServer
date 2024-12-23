using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Equipments.UpdateEquipment;

public sealed record UpdateEquipmentCommand(
    Guid Id,
    string Name,
    string SerialNumber,
    string Type) : IRequest<Result<string>>;
