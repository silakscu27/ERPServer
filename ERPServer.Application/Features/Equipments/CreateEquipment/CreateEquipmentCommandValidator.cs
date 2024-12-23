using FluentValidation;

namespace ERPServer.Application.Features.Equipments.CreateEquipment;

public sealed class CreateEquipmentCommandValidator : AbstractValidator<CreateEquipmentCommand>
{
    public CreateEquipmentCommandValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty()
            .WithMessage("Ekipman adı boş bırakılamaz")
            .MaximumLength(100)
            .WithMessage("Ekipman adı 100 karakterden fazla olamaz");

        RuleFor(e => e.SerialNumber)
            .NotEmpty()
            .WithMessage("Seri numarası boş bırakılamaz")
            .MaximumLength(50)
            .WithMessage("Seri numarası 50 karakterden fazla olamaz");

        RuleFor(e => e.Type)
            .NotEmpty()
            .WithMessage("Ekipman türü boş bırakılamaz")
            .MaximumLength(50)
            .WithMessage("Ekipman türü 50 karakterden fazla olamaz");
    }
}
