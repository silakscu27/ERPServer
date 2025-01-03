using FluentValidation;

namespace ERPServer.Application.Features.Projects.CreateProject;

public sealed class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Proje adı boş bırakılamaz")
            .MaximumLength(200).WithMessage("Proje adı 200 karakterden uzun olamaz");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Açıklama boş olamaz")
            .MaximumLength(500).WithMessage("Açıklama 500 karakterden uzun olamaz");

        RuleFor(p => p.StartDate)
            .NotEmpty().WithMessage("Başlangıç tarihi boş bırakılamaz");

        RuleFor(p => p.EndDate)
            .GreaterThanOrEqualTo(p => p.StartDate)
            .When(p => p.EndDate.HasValue)
            .WithMessage("Bitiş tarihi, başlangıç tarihinden önce olamaz");

        RuleFor(p => p.Status)
            .NotEmpty().WithMessage("Durum boş bırakılamaz")
            .MaximumLength(50).WithMessage("Durum 50 karakterden uzun olamaz");
    }
}
