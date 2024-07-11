using FluentValidation;

namespace ECommerceCart.Application.CartCommandQuery.Command.AddToCart;

public class AddToCartCommandValidator : AbstractValidator<AddToCartCommand>
{
    public AddToCartCommandValidator()
    {
        RuleFor(x => x.ItemId).NotEmpty();
        RuleFor(x => x.Quantity).NotEmpty();
    }
}