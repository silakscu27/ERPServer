using FluentValidation;

namespace ERPServer.Application.Features.Categories.UpdateCategory;

public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Kategori ID'si boş olamaz");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Kategori ismi boş olamaz")
            .MaximumLength(100).WithMessage("Kategori ismi en fazla 100 karakter olabilir");

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("Kategori açıklaması en fazla 500 karakter olabilir");
    }
}
