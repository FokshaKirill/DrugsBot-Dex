using Domain.DomainEvents;
using Domain.Validators;
using FluentValidation;

namespace Domain.Validation.Validators;

public class DrugItemUpdatedEventValidator : AbstractValidator<DrugItemUpdatedEvent>
{
    public DrugItemUpdatedEventValidator()
    {
        var ruleBuilderOptions =
            RuleFor(di => di.NewCount)
                .NotNull().WithMessage(ValidationMessages.NotNull)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
                .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.NegativeNumError)
                .LessThanOrEqualTo(10000).WithMessage(ValidationMessages.GreaterThanNumError);
    }
}