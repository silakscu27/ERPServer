using FluentValidation;

namespace ERPServer.Application.Features.Projects.UpdateProject;

public sealed class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Proje adı boş olamaz")
            .MaximumLength(200).WithMessage("Proje adı 200 karakterden fazla olamaz");

        RuleFor(p => p.StartDate)
            .NotEmpty().WithMessage("Başlangıç tarihi boş olamaz");

        RuleFor(p => p.EndDate)
            .NotEmpty().WithMessage("Bitiş tarihi boş olamaz")
            .GreaterThanOrEqualTo(p => p.StartDate)
            .WithMessage("Bitiş tarihi başlangıç tarihinden önce olamaz");

        RuleFor(p => p.Status)
            .NotEmpty().WithMessage("Durum bilgisi boş olamaz")
            .MaximumLength(100).WithMessage("Durum bilgisi 100 karakterden fazla olamaz");
    }
}
