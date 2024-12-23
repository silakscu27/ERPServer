using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Equipments.CreateEquipment;

internal sealed class CreateEquipmentCommandHandler(
    IEquipmentRepository equipmentRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateEquipmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
    {
        var existingEquipment = await equipmentRepository.FindAsync(e => e.SerialNumber == request.SerialNumber, cancellationToken);
        if (existingEquipment is not null)
        {
            return Result<string>.Failure("Bu seri numarasına sahip bir ekipman zaten mevcut.");
        }

        var equipment = mapper.Map<Equipment>(request);
        equipment.Id = Guid.NewGuid();

        await equipmentRepository.AddAsync(equipment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Ekipman başarıyla oluşturuldu.";
    }
}
