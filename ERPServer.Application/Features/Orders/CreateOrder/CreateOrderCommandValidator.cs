using FluentValidation;

namespace ERPServer.Application.Features.Orders.CreateOrder;

public sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(o => o.OrderDate).
            NotEmpty()
            .WithMessage("Sipariş tarihi boş bırakılamaz")
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Sipariş tarihi bugünden büyük olamaz");

        RuleFor(o => o.TotalAmount)
            .GreaterThan(0)
            .WithMessage("Toplam tutar sıfırdan büyük olmalıdır");

        RuleFor(o => o.Status)
            .NotEmpty()
            .WithMessage("Sipariş durumu boş bırakılamaz")
            .MaximumLength(50)
            .WithMessage("Sipariş durumu 50 karakterden fazla olamaz");

        RuleFor(o => o.CustomerIds)
            .NotEmpty()
            .WithMessage("Müşteri ID'leri boş bırakılamaz")
            .Must(ids => ids.Any())
            .WithMessage("En az bir müşteri seçilmelidir");
    }
}
