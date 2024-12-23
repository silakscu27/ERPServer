using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Equipments.UpdateEquipment;

internal sealed class UpdateEquipmentCommandHandler(
    IEquipmentRepository equipmentRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateEquipmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
    {
        Equipment equipment = await equipmentRepository.GetByExpressionWithTrackingAsync(
            e => e.Id == request.Id, cancellationToken);

        if (equipment is null)
        {
            return Result<string>.Failure("Ekipman bulunamadı");
        }

        mapper.Map(request, equipment);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Ekipman bilgileri başarıyla güncellendi";
    }
}
