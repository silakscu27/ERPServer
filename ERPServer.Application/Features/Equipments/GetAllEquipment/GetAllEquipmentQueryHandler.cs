using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.Equipments.GetAllEquipment;

internal sealed class GetAllEquipmentQueryHandler(
    IEquipmentRepository equipmentRepository) : IRequestHandler<GetAllEquipmentQuery, Result<List<Equipment>>>
{
    public async Task<Result<List<Equipment>>> Handle(GetAllEquipmentQuery request, CancellationToken cancellationToken)
    {
        List<Equipment> equipments = await equipmentRepository.GetAll()
            .OrderBy(e => e.Name) 
            .ToListAsync(cancellationToken);

        return equipments;
    }
}
