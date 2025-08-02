using ePharmacy.Application.Dtos.CartDtos;
using FluentValidation;

namespace ePharmacy.Application.Validators;
public class CartItemCreateDtoValidator : AbstractValidator<CartItemCreateDto>
{
    public CartItemCreateDtoValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("User ID must be greater than 0.");

        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("Product ID must be greater than 0.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0.")
            .LessThanOrEqualTo(100)
            .WithMessage("Quantity cannot exceed 100 items.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.")
            .When(x => x.Price.HasValue);
    }
}
