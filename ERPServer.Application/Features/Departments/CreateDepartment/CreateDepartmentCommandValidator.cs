using FluentValidation;

namespace ERPServer.Application.Features.Departments.CreateDepartment;

public sealed class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Departman adı boş olamaz")
            .MaximumLength(100)
            .WithMessage("Departman adı 100 karakterden uzun olamaz");

        RuleFor(p => p.Description)
            .MaximumLength(250)
            .WithMessage("Açıklama 250 karakterden uzun olamaz");
    }
}
