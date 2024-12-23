using FluentValidation;

namespace ERPServer.Application.Features.QualityChecks.CreateQualityCheck;

public sealed class CreateQualityCheckCommandValidator : AbstractValidator<CreateQualityCheckCommand>
{
    public CreateQualityCheckCommandValidator()
    {
        RuleFor(qc => qc.CheckDate)
            .NotEmpty().WithMessage("Kontrol tarihi boş bırakılamaz");

        RuleFor(qc => qc.ReportId)
            .NotEmpty().WithMessage("Rapor ID boş bırakılamaz");

        RuleFor(qc => qc.Checkpoint)
            .NotEmpty().WithMessage("Kontrol noktası boş bırakılamaz")
            .MaximumLength(100).WithMessage("Kontrol noktası 100 karakterden fazla olamaz");

        RuleFor(qc => qc.Result)
            .NotEmpty().WithMessage("Sonuç boş bırakılamaz")
            .MaximumLength(50).WithMessage("Sonuç 50 karakterden fazla olamaz");
    }
}
