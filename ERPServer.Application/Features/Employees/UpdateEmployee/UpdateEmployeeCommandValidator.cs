using FluentValidation;

namespace ERPServer.Application.Features.Employees.UpdateEmployee;

public sealed class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(e => e.FirstName)
            .NotEmpty().WithMessage("Çalışanın adı boş olamaz")
            .Length(2, 50).WithMessage("Çalışanın adı 2 ile 50 karakter arasında olmalıdır");

        RuleFor(e => e.LastName)
            .NotEmpty().WithMessage("Çalışanın soyadı boş olamaz")
            .Length(2, 50).WithMessage("Çalışanın soyadı 2 ile 50 karakter arasında olmalıdır");

        RuleFor(e => e.Position)
            .NotEmpty().WithMessage("Pozisyon boş olamaz")
            .Length(2, 100).WithMessage("Pozisyon 2 ile 100 karakter arasında olmalıdır");

        RuleFor(e => e.DepartmentId)
            .NotEmpty().WithMessage("Departman kimliği boş olamaz");

        RuleFor(e => e.HireDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("İşe alım tarihi bugünden sonraki bir tarih olamaz");

        RuleFor(e => e.Salary)
            .GreaterThan(0).WithMessage("Maaş 0'dan büyük olmalıdır");
    }
}
