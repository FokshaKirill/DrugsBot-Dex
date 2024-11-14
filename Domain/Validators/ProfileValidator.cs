using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class ProfileValidator : AbstractValidator<Profile>
{
    public ProfileValidator()
    { //938948763
        var ruleBuilderOptions =
            RuleFor(p => p.Email)
                .Length(2, 150).WithMessage(ValidationMessage.WrongLengthRange)
                .Matches("^[a-zа-я0-9]+$").WithMessage(ValidationMessage.SpecialSymbolsError);

    }
}