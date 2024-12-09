using FluentValidation;

namespace ERPServer.Application.Features.Customers.CreateCustomer;

public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(p => p.FirstName)
            .NotEmpty().WithMessage("Ad boş olamaz")
            .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olabilir");

        RuleFor(p => p.LastName)
            .NotEmpty().WithMessage("Soyad boş olamaz")
            .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olabilir");

        RuleFor(p => p.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası boş olamaz")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Telefon numarası geçerli bir formatta olmalıdır");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("E-posta adresi boş olamaz")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi olmalıdır");

        RuleFor(p => p.TaxNumber)
            .NotEmpty().WithMessage("Vergi numarası boş olamaz")
            .Length(10, 11).WithMessage("Vergi numarası 10 veya 11 karakter olmalıdır");

        RuleFor(p => p.FullAddress)
            .MaximumLength(500).WithMessage("Adres en fazla 500 karakter olabilir");
    }
}
