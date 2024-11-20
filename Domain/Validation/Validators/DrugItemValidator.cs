using Domain.Entities;
using Domain.Validators;
using FluentValidation;

namespace Domain.Validation.Validators;

public class DrugItemValidator : AbstractValidator<DrugItem>
{
    public DrugItemValidator()
    {
        var ruleBuilderOptions = 
            RuleFor(di => di.Cost)
            .GreaterThan(0).WithMessage(ValidationMessage.NegativeNumOrZeroError)
            .PrecisionScale(65, 2, true).WithMessage(ValidationMessage.WrongPrecisionScale);

        RuleFor(di => di.Count)
            .LessThanOrEqualTo(10000).WithMessage(ValidationMessage.GreaterThanNumError)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.NegativeNumError);  
    }
}