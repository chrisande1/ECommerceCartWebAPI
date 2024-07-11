using ECommerceCart.Application.CartCommandQuery.Common;
using ECommerceCart.Application.Common.Interface.Persistence.UserInterface;
using ECommerceCart.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.CartCommandQuery.Command.AddToCart;

public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, ErrorOr<CartResult>>
{
    private readonly ICartRepository _cartRepository;

    public AddToCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<ErrorOr<CartResult>> Handle(AddToCartCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var existingCartItem = await _cartRepository.GetById(command.ItemId);

        if (existingCartItem == null)
        {
            return Errors.CartError.GetCartItemByIdNotFound;
        }

        existingCartItem.Quantity += command.Quantity;

        await _cartRepository.UpdateCart(existingCartItem);

        return new CartResult(existingCartItem);

    }
}