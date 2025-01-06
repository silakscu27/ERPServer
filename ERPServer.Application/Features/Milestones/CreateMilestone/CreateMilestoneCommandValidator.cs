using FluentValidation;

namespace ERPServer.Application.Features.Milestones.CreateMilestone;

public sealed class CreateMilestoneCommandValidator : AbstractValidator<CreateMilestoneCommand>
{
    public CreateMilestoneCommandValidator()
    {
        RuleFor(m => m.ProjectId)
            .NotEmpty()
            .WithMessage("Proje ID boş bırakılamaz");

        RuleFor(m => m.MilestoneName)
            .NotEmpty()
            .WithMessage("Aşama adı boş bırakılamaz")
            .MaximumLength(100)
            .WithMessage("Aşama adı 100 karakterden fazla olamaz");

        RuleFor(m => m.EstimatedTime)
            .GreaterThan(0)
            .WithMessage("Tahmini süre sıfırdan büyük olmalıdır");
    }
}
