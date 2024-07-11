using ECommerceCart.Application.CartCommandQuery.Common;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.CartCommandQuery.Command.CreateCart;

public record CreateCartCommand(
    Guid UserId,
    string ItemName,
    int Quantity,
    decimal UnitPrice) : IRequest<ErrorOr<CartResult>>;