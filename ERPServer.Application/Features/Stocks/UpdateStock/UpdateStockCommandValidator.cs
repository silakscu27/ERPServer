using FluentValidation;

namespace ERPServer.Application.Features.Stocks.UpdateStock;

public sealed class UpdateStockCommandValidator : AbstractValidator<UpdateStockCommand>
{
    public UpdateStockCommandValidator()
    {
        RuleFor(p => p.ProductName)
            .NotEmpty().WithMessage("Ürün adı boş olamaz")
            .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir");

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("Kategori ID boş olamaz");

        RuleFor(p => p.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("Miktar sıfırdan küçük olamaz");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Fiyat sıfırdan büyük olmalıdır");

        RuleFor(p => p.LastUpdatedDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Son güncelleme tarihi gelecek bir tarih olamaz");
    }
}
