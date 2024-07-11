using ECommerceCart.Application.CartCommandQuery.Common;
using ECommerceCart.Application.Common.Interface.Persistence.UserInterface;
using ECommerceCart.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.CartCommandQuery.Query.GetCartItemsByItemId;

public class GetCartItemsByItemIdQueryHandler : IRequestHandler<GetCartItemsByItemIdQuery, ErrorOr<CartResult>>
{
    private readonly ICartRepository _cartRepository;

    public GetCartItemsByItemIdQueryHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<ErrorOr<CartResult>> Handle(GetCartItemsByItemIdQuery command, CancellationToken cancellationToken)
    {
        var cartItem = await _cartRepository.GetCartByItemId(command.itemId);

        if (cartItem == null)
        {
            return Errors.CartError.GetCartItemByIdNotFound;
        }

        var cartResult = new CartResult(
            cartItem
        );

        return cartResult;
    }
}
