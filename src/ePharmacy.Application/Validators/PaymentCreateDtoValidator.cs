using ePharmacy.Application.Dtos.PaymentDtos;
using FluentValidation;

namespace ePharmacy.Application.Validators;
public class PaymentCreateDtoValidator : AbstractValidator<CreatePaymentDto>
{
    public PaymentCreateDtoValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than 0.");

        RuleFor(x => x.OrderId)
            .GreaterThan(0).WithMessage("Order ID must be greater than 0.");
    }
}
