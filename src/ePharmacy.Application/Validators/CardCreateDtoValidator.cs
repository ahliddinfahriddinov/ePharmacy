using ePharmacy.Application.Dtos.CardDtos;
using FluentValidation;

namespace ePharmacy.Application.Validators;

public class CardCreateDtoValidator : AbstractValidator<CreateCardDto>
{
    public CardCreateDtoValidator()
    {
        RuleFor(x => x.CardHolderName)
            .NotEmpty().WithMessage("Card holder name is required.")
            .MaximumLength(100).WithMessage("Card holder name must not exceed 100 characters.");

        RuleFor(x => x.CardNumber)
            .NotEmpty().WithMessage("Card number is required.")
            .CreditCard().WithMessage("Invalid card number format.");

        RuleFor(x => x.ExpiryMonth)
            .NotEmpty().WithMessage("Expiry month is required.")
            .Length(2).WithMessage("Expiry month must be 2 digits.")
            .Matches(@"^(0[1-9]|1[0-2])$").WithMessage("Expiry month must be between 01 and 12.");

        RuleFor(x => x.ExpiryYear)
            .NotEmpty().WithMessage("Expiry year is required.")
            .Length(4).WithMessage("Expiry year must be 4 digits.")
            .Must(year => int.TryParse(year, out int yearValue) && yearValue >= DateTime.Now.Year && yearValue <= DateTime.Now.Year + 10)
            .WithMessage("Expiry year must be between current year and next 10 years.");

        RuleFor(x => x.CardType)
            .IsInEnum().WithMessage("Invalid card type.");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("User ID must be greater than 0.");
    }
}

