using FluentValidation;

namespace ERPServer.Application.Features.MaintenanceTasks.CreateMaintenanceTask;

public sealed class CreateMaintenanceTaskCommandValidator : AbstractValidator<CreateMaintenanceTaskCommand>
{
    public CreateMaintenanceTaskCommandValidator()
    {
        RuleFor(t => t.TaskName)
            .NotEmpty().WithMessage("Görev adı boş bırakılamaz")
            .MaximumLength(100).WithMessage("Görev adı 100 karakterden fazla olamaz");

        RuleFor(t => t.ScheduledDate)
            .GreaterThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Planlanan tarih bugünden küçük olamaz");

        RuleFor(t => t.EquipmentId)
            .NotEmpty().WithMessage("Ekipman ID boş bırakılamaz");

        RuleFor(t => t.Status)
            .MaximumLength(50).WithMessage("Durum 50 karakterden fazla olamaz");
    }
}
