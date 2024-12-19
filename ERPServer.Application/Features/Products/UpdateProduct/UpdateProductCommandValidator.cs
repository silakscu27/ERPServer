using FluentValidation;

namespace ERPServer.Application.Features.Products.UpdateProduct;

public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Ürün kimliği boş olamaz");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Ürün adı boş olamaz")
            .Length(2, 100).WithMessage("Ürün adı 2 ile 100 karakter arasında olmalıdır");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Ürün fiyatı sıfırdan büyük olmalıdır");

        RuleFor(p => p.StockId)
            .NotEmpty().WithMessage("Stok kimliği boş olamaz");
    }
}
