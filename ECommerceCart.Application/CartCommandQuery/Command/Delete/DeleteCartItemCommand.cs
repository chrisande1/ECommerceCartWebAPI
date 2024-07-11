using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.CartCommandQuery.Command.Delete;

public record DeleteCartItemCommand(
    Guid CartItemId) : IRequest<ErrorOr<bool>>;