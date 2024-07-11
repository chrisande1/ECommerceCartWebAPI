using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.UserCommandQuery.Command.Delete;

public record DeleteUserCommand(
    Guid Id) : IRequest<ErrorOr<bool>>;