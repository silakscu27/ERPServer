using FluentValidation;

namespace ERPServer.Application.Features.Customers.UpdateCustomer;

public sealed class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(p => p.TaxNumber).MinimumLength(10).MaximumLength(11);
        RuleFor(p => p.PhoneNumber).Matches(@"^\+?[0-9]{10,15}$").WithMessage("Geçerli bir telefon numarası girin");
        RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir e-posta adresi girin");
        RuleFor(p => p.FirstName).NotEmpty().WithMessage("Ad boş olamaz");
        RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyad boş olamaz");
    }
}
