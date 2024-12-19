using FluentValidation;

namespace ERPServer.Application.Features.Products.CreateProduct;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Ürün adı boş bırakılamaz")
            .MaximumLength(100).WithMessage("Ürün adı 100 karakterden fazla olamaz");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Fiyat sıfırdan büyük olmalıdır");

        RuleFor(p => p.StockId)
            .NotEmpty().WithMessage("Stok ID boş bırakılamaz");
    }
}
