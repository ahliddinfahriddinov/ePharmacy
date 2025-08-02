﻿using ePharmacy.Application.Dtos.UserDtos;
using FluentValidation;

namespace ePharmacy.Application.Validators;

public class UserLoginValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("UserName is required")
            .Length(3, 20)
            .WithMessage("UserName must be between 3 and 20 characters long");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .Length(8, 20)
            .WithMessage("Password must be between 8 and 20 characters long");
    }
}
