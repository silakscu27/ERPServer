using FluentValidation;

namespace ERPServer.Application.Features.MaintenanceTasks.UpdateMaintenanceTask;

public sealed class UpdateMaintenanceTaskCommandValidator : AbstractValidator<UpdateMaintenanceTaskCommand>
{
    public UpdateMaintenanceTaskCommandValidator()
    {
        RuleFor(mt => mt.TaskName)
            .NotEmpty().WithMessage("Görev adı boş olamaz")
            .Length(2, 100).WithMessage("Görev adı 2 ile 100 karakter arasında olmalıdır");

        RuleFor(mt => mt.Description)
            .MaximumLength(500).WithMessage("Açıklama 500 karakterden fazla olamaz");

        RuleFor(mt => mt.ScheduledDate)
            .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Planlanan tarih geçmişte olamaz");

        RuleFor(mt => mt.IsCompleted)
            .NotNull().WithMessage("Tamamlanma durumu belirtilmelidir");
    }
}
