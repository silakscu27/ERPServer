using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Equipments.DeleteEquipmentById;

internal sealed class DeleteEquipmentByIdCommandHandler(
    IEquipmentRepository equipmentRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteEquipmentByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteEquipmentByIdCommand request, CancellationToken cancellationToken)
    {
        Equipment equipment = await equipmentRepository.GetByExpressionAsync(e => e.Id == request.Id, cancellationToken);

        if (equipment is null)
        {
            return Result<string>.Failure("Ekipman bulunamadı");
        }

        equipmentRepository.Delete(equipment);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Ekipman başarıyla silindi";
    }
}
