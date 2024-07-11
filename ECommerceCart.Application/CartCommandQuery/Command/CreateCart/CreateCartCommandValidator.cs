using FluentValidation;

namespace ECommerceCart.Application.CartCommandQuery.Command.CreateCart;

public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.ItemName).NotEmpty();
        RuleFor(x => x.Quantity).NotEmpty();
        RuleFor(x => x.UnitPrice).NotEmpty();
    }
}