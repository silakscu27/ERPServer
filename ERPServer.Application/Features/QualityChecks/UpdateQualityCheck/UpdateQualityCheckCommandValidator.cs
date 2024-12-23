using FluentValidation;

namespace ERPServer.Application.Features.QualityChecks.UpdateQualityCheck;

public sealed class UpdateQualityCheckCommandValidator : AbstractValidator<UpdateQualityCheckCommand>
{
    public UpdateQualityCheckCommandValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty().WithMessage("Kalite kontrol ID'si boş olamaz.");

        RuleFor(q => q.CheckDate)
            .NotEmpty().WithMessage("Kontrol tarihi boş olamaz.");

        RuleFor(q => q.ReportId)
            .NotEmpty().WithMessage("Rapor ID boş olamaz.");

        RuleFor(q => q.Checkpoint)
            .NotEmpty().WithMessage("Kontrol noktası boş olamaz.")
            .MaximumLength(100).WithMessage("Kontrol noktası 100 karakterden uzun olamaz.");

        RuleFor(q => q.Result)
            .NotEmpty().WithMessage("Sonuç boş olamaz.")
            .MaximumLength(200).WithMessage("Sonuç 200 karakterden uzun olamaz.");
    }
}
