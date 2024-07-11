using ECommerceCart.Application.UserCommandQuery.Common;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.UserCommandQuery.Query.GetById;

public record GetUserByIdQuery(
    Guid Id) : IRequest<ErrorOr<UserResult>>;