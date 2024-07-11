using ECommerceCart.Application.CartCommandQuery.Common;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.CartCommandQuery.Query.GetCartItemsByItemId;

public record GetCartItemsByItemIdQuery(Guid itemId) : IRequest<ErrorOr<CartResult>>;

