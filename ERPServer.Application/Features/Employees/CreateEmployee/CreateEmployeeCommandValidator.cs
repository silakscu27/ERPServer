using FluentValidation;

namespace ERPServer.Application.Features.Employees.CreateEmployee;

public sealed class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(e => e.FirstName).NotEmpty().WithMessage("Ad boş bırakılamaz")
                                 .MaximumLength(50).WithMessage("Ad 50 karakterden fazla olamaz");

        RuleFor(e => e.LastName).NotEmpty().WithMessage("Soyad boş bırakılamaz")
                                .MaximumLength(50).WithMessage("Soyad 50 karakterden fazla olamaz");

        RuleFor(e => e.Position).NotEmpty().WithMessage("Pozisyon boş bırakılamaz");

        RuleFor(e => e.DepartmentId).NotEmpty().WithMessage("Departman ID boş bırakılamaz");

        RuleFor(e => e.HireDate).LessThanOrEqualTo(DateTime.UtcNow)
                                .WithMessage("İşe başlama tarihi bugünden büyük olamaz");

        RuleFor(e => e.Salary).GreaterThan(0).WithMessage("Maaş sıfırdan büyük olmalıdır");
    }
}
