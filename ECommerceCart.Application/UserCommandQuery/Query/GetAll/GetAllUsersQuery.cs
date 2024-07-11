using ECommerceCart.Application.UserCommandQuery.Common;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.UserCommandQuery.Query.GetAll;

public record GetAllUsersQuery() : IRequest<ErrorOr<IEnumerable<UserResult>>>;

