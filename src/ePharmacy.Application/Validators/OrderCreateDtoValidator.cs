using ePharmacy.Application.Dtos.OrderDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ePharmacy.Application.Validators;
public class OrderCreateDtoValidator : AbstractValidator<CreatePaymentDto>
{
    public OrderCreateDtoValidator()
    {
        RuleFor(x => x.TotalAmount)
            .GreaterThan(0).WithMessage("Total amount must be greater than 0.");

        RuleFor(x => x.Notes)
            .MaximumLength(500).WithMessage("Notes must not exceed 500 characters.");

        RuleFor(x => x.PrescriptionImageUrl)
            .MaximumLength(500).WithMessage("Prescription image URL must not exceed 500 characters.")
            .Must(url => string.IsNullOrEmpty(url) || Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage("Invalid prescription image URL format.")
            .When(x => !string.IsNullOrEmpty(x.PrescriptionImageUrl));

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("User ID must be greater than 0.");

        RuleFor(x => x.PharmacyId)
            .GreaterThan(0).WithMessage("Pharmacy ID must be greater than 0.");

        RuleFor(x => x.AddressId)
            .GreaterThan(0).WithMessage("Address ID must be greater than 0.");

        RuleFor(x => x.PaymentId)
            .GreaterThan(0).WithMessage("Payment ID must be greater than 0.");
    }
}
k