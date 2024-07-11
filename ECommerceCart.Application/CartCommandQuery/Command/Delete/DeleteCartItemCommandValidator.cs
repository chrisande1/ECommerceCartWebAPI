using ECommerceCart.Application.CartCommandQuery.Command.Delete;
using FluentValidation;

namespace ECommerceCart.Application.CartCommandQuery.Command.Delete;

public class DeleteCartItemCommandValidator : AbstractValidator<DeleteCartItemCommand>
{
    public DeleteCartItemCommandValidator()
    {
        RuleFor(x => x.CartItemId).NotEmpty();
    }
}
