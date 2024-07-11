using ECommerceCart.Application.CartCommandQuery.Common;
using ECommerceCart.Application.Common.Interface.Persistence.UserInterface;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.CartCommandQuery.Query.GetAllCartItems;

public class GetAllCartItemsQueryHandler : IRequestHandler<GetAllCartItemsQuery, ErrorOr<IEnumerable<CartResult>>>
{
    private readonly ICartRepository _cartRepository;

    public GetAllCartItemsQueryHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<ErrorOr<IEnumerable<CartResult>>> Handle(GetAllCartItemsQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var allCartItems = await _cartRepository.GetAllCartItems();

        if (allCartItems == null)
        {
            return new List<CartResult>();
        }

        var cartResult = allCartItems
            .Where(cart => cart != null) // Ensure no null users are processed
            .Select(cart => new CartResult(
                cart
            )).ToList();

        return cartResult;
    }
}