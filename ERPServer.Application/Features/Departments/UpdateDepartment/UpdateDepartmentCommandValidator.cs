using FluentValidation;

namespace ERPServer.Application.Features.Departments.UpdateDepartment;

public sealed class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Departman adı boş olamaz")
            .Length(3, 100).WithMessage("Departman adı 3 ile 100 karakter arasında olmalıdır");

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("Açıklama 500 karakteri geçemez");
    }
}
