using FluentValidation;

namespace ERPServer.Application.Features.Milestones.UpdateMilestone;

public sealed class UpdateMilestoneCommandValidator : AbstractValidator<UpdateMilestoneCommand>
{
    public UpdateMilestoneCommandValidator()
    {
        RuleFor(m => m.MilestoneName)
            .NotEmpty().WithMessage("Aşama adı boş olamaz")
            .Length(2, 100).WithMessage("Aşama adı 2 ile 100 karakter arasında olmalıdır");

        RuleFor(m => m.Description)
            .NotEmpty().WithMessage("Açıklama boş olamaz")
            .Length(5, 500).WithMessage("Açıklama 5 ile 500 karakter arasında olmalıdır");

        RuleFor(m => m.StartDate)
            .LessThanOrEqualTo(m => m.EndDate).WithMessage("Başlangıç tarihi bitiş tarihinden sonra olamaz");

        RuleFor(m => m.EndDate)
            .GreaterThanOrEqualTo(m => m.StartDate).WithMessage("Bitiş tarihi başlangıç tarihinden önce olamaz");

        RuleFor(m => m.Budget)
            .GreaterThan(0).WithMessage("Bütçe 0'dan büyük olmalıdır");
    }
}
