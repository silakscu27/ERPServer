using FluentValidation;

namespace ERPServer.Application.Features.QualityReports.UpdateQualityReports;

public sealed class UpdateQualityReportCommandValidator : AbstractValidator<UpdateQualityReportCommand>
{
    public UpdateQualityReportCommandValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty().WithMessage("Kalite raporu kimliği boş bırakılamaz");

        RuleFor(q => q.Name)
            .NotEmpty().WithMessage("Kalite raporu adı boş bırakılamaz")
            .MaximumLength(100).WithMessage("Kalite raporu adı en fazla 100 karakter olmalıdır");

        RuleFor(q => q.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olmalıdır");
    }
}
