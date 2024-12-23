using FluentValidation;

namespace ERPServer.Application.Features.Equipments.UpdateEquipment;

public sealed class UpdateEquipmentCommandValidator : AbstractValidator<UpdateEquipmentCommand>
{
    public UpdateEquipmentCommandValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("Ekipman adı boş olamaz")
            .Length(2, 100).WithMessage("Ekipman adı 2 ile 100 karakter arasında olmalıdır");

        RuleFor(e => e.SerialNumber)
            .NotEmpty().WithMessage("Seri numarası boş olamaz")
            .Length(2, 50).WithMessage("Seri numarası 2 ile 50 karakter arasında olmalıdır");

        RuleFor(e => e.Type)
            .NotEmpty().WithMessage("Ekipman türü boş olamaz")
            .Length(2, 50).WithMessage("Ekipman türü 2 ile 50 karakter arasında olmalıdır");
    }
}
