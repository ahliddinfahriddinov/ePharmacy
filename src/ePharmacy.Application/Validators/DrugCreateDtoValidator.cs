using ePharmacy.Application.Dtos.DrugDtos;
using FluentValidation;

namespace ePharmacy.Application.Validators;
public class DrugCreateDtoValidator : AbstractValidator<CreateDrugDto>
{
    public DrugCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Drug name is required.")
            .MaximumLength(200).WithMessage("Drug name must not exceed 200 characters.");

        RuleFor(x => x.GenericName)
            .NotEmpty().WithMessage("Generic name is required.")
            .MaximumLength(200).WithMessage("Generic name must not exceed 200 characters.");

        RuleFor(x => x.Manufacturer)
            .NotEmpty().WithMessage("Manufacturer is required.")
            .MaximumLength(100).WithMessage("Manufacturer must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");

        RuleFor(x => x.Category)
            .IsInEnum().WithMessage("Invalid drug category.");

        RuleFor(x => x.Dosage)
            .NotEmpty().WithMessage("Dosage is required.")
            .MaximumLength(100).WithMessage("Dosage must not exceed 100 characters.");

        RuleFor(x => x.ActiveIngredients)
            .NotEmpty().WithMessage("Active ingredients are required.")
            .MaximumLength(500).WithMessage("Active ingredients must not exceed 500 characters.");

        RuleFor(x => x.SideEffects)
            .MaximumLength(1000).WithMessage("Side effects must not exceed 1000 characters.");

        RuleFor(x => x.Contraindications)
            .MaximumLength(1000).WithMessage("Contraindications must not exceed 1000 characters.");

        RuleFor(x => x.ImageUrl)
            .MaximumLength(500).WithMessage("Image URL must not exceed 500 characters.")
            .Must(url => string.IsNullOrEmpty(url) || Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage("Invalid image URL format.");

        RuleFor(x => x.Barcode)
            .MaximumLength(50).WithMessage("Barcode must not exceed 50 characters.")
            .Matches(@"^[0-9A-Za-z]+$").WithMessage("Barcode must contain only alphanumeric characters.")
            .When(x => !string.IsNullOrEmpty(x.Barcode));
    }
}
