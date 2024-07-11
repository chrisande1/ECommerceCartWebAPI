using ECommerceCart.Application.CartCommandQuery.Common;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.CartCommandQuery.Command.AddToCart;

public record AddToCartCommand(
    Guid ItemId,
    int Quantity) : IRequest<ErrorOr<CartResult>>;