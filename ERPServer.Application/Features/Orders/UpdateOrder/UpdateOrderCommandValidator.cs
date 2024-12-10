using FluentValidation;

namespace ERPServer.Application.Features.Orders.UpdateOrder;

public sealed class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(o => o.CustomerId)
            .NotEmpty()
            .WithMessage("Müşteri kimliği boş olamaz");

        RuleFor(o => o.OrderDate)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Sipariş tarihi bugünden sonraki bir tarih olamaz");

        RuleFor(o => o.TotalAmount)
            .GreaterThan(0)
            .WithMessage("Toplam tutar 0'dan büyük olmalıdır");

        RuleFor(o => o.Status)
            .NotEmpty()
            .WithMessage("Sipariş durumu boş olamaz")
            .Length(2, 50)
            .WithMessage("Sipariş durumu 2 ile 50 karakter arasında olmalıdır");
    }
}
