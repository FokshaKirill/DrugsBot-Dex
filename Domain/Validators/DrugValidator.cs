﻿using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator()
    {
        var ruleBuilderOptions =
            RuleFor(d => d.Name)
                .NotNull().WithMessage(ValidationMessage.NotNull)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
                .Length(2, 150).WithMessage(ValidationMessage.WrongLengthRange)
                .Matches("^[a-zа-я0-9]+$").WithMessage(ValidationMessage.SpecialSymbolsError);
            
        RuleFor(d => d.CountryCodeId)
            .Length(2).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[a-z\s]+$", RegexOptions.IgnoreCase);
    }
}