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
                .NotNull().WithMessage(ValidationMessage.NotNull)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
                .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.NegativeNumError)
                .LessThanOrEqualTo(10000).WithMessage(ValidationMessage.GreaterThanNumError);
    }
}