using ECommerceCart.Application.CartCommandQuery.Common;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.CartCommandQuery.Query.GetAllCartItems;

public record GetAllCartItemsQuery() : IRequest<ErrorOr<IEnumerable<CartResult>>>;