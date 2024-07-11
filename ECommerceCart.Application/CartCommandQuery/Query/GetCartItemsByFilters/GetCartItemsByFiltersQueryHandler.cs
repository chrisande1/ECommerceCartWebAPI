using ECommerceCart.Application.CartCommandQuery.Common;
using ECommerceCart.Application.Common.Interface.Persistence.UserInterface;
using ECommerceCart.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.CartCommandQuery.Query.GetCartItemsByFilters
{
    public class GetCartItemsByFiltersQueryHandler : IRequestHandler<GetCartItemsByFiltersQuery, ErrorOr<IEnumerable<CartResult>>>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartItemsByFiltersQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<ErrorOr<IEnumerable<CartResult>>> Handle(GetCartItemsByFiltersQuery query, CancellationToken cancellationToken)
        {
            // Fetch cart items based on the filters
            var cartItems = await _cartRepository.GetCartItems(
                phoneNumber: query.phoneNumber,
                startTime: query.startTime,
                endTime: query.endTime,
                minQuantity: query.minQuantity,
                itemId: query.itemId
            );

            // Check if any items are found
            if (cartItems == null || !cartItems.Any())
            {
                return Errors.CartError.NoCartItemsFound; 
            }

            // Map cart items to CartResult
            var cartResult = cartItems.Select(cart => new CartResult(cart)).ToList();

            return cartResult;
        }
    }
}
