using ePharmacy.Application.Dtos.PharmacyDtos;
using FluentValidation;

namespace ePharmacy.Application.Validators;
public class PharmacyCreateDtoValidator : AbstractValidator<CreatePharmacyDto>
{
    public PharmacyCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Pharmacy name is required.")
            .MaximumLength(200).WithMessage("Pharmacy name must not exceed 200 characters.");

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+?[1-9]\d{1,14}$")
            .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
            .WithMessage("Invalid phone number format");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

        RuleFor(x => x.OpeningTime)
            .NotEmpty().WithMessage("Opening time is required.");

        RuleFor(x => x.ClosingTime)
            .NotEmpty().WithMessage("Closing time is required.")
            .GreaterThan(x => x.OpeningTime).WithMessage("Closing time must be after opening time.");

        RuleFor(x => x.AddressId)
            .GreaterThan(0).WithMessage("Address ID must be greater than 0.");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("User ID must be greater than 0.");
    }
}
