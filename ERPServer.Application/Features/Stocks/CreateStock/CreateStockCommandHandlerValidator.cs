using FluentValidation;

namespace ERPServer.Application.Features.Stocks.CreateStock;

public sealed class CreateStockCommandValidator : AbstractValidator<CreateStockCommand>
{
    public CreateStockCommandValidator()
    {
        RuleFor(p => p.ProductName)
            .NotEmpty().WithMessage("Ürün adı boş olamaz")
            .MaximumLength(150).WithMessage("Ürün adı en fazla 150 karakter olabilir");

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("Kategori ID'si boş olamaz");

        RuleFor(p => p.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("Miktar negatif olamaz");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Fiyat sıfırdan büyük olmalıdır");
    }
}
