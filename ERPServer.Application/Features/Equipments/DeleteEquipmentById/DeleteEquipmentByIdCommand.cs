using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Equipments.DeleteEquipmentById;

public sealed record DeleteEquipmentByIdCommand(
    Guid Id) : IRequest<Result<string>>;
