using ECommerceCart.Application.CartCommandQuery.Common;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.CartCommandQuery.Query.GetCartItemsByFilters;

public record GetCartItemsByFiltersQuery(
    string phoneNumber,
    DateTime startTime,
    DateTime endTime,
    int minQuantity,
    Guid itemId) : IRequest<ErrorOr<IEnumerable<CartResult>>>;