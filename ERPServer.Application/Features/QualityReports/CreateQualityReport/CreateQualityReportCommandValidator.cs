using FluentValidation;

namespace ERPServer.Application.Features.QualityReports.CreateQualityReports;

public sealed class CreateQualityReportCommandValidator : AbstractValidator<CreateQualityReportCommand>
{
    public CreateQualityReportCommandValidator()
    {
        RuleFor(q => q.Name)
            .NotEmpty().WithMessage("Rapor adı boş bırakılamaz")
            .MaximumLength(100).WithMessage("Rapor adı 100 karakterden fazla olamaz");

        RuleFor(q => q.CreatedDate)
            .NotEmpty().WithMessage("Oluşturulma tarihi boş bırakılamaz")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Oluşturulma tarihi bugünden ileri bir tarih olamaz");

        RuleFor(q => q.Description)
            .MaximumLength(500).WithMessage("Açıklama 500 karakterden fazla olamaz");
    }
}
