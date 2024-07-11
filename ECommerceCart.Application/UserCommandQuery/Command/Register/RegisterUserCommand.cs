using ECommerceCart.Application.UserCommandQuery.Common;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.UserCommandQuery.Command.Register;

public record RegisterUserCommand(
    string FirstName,
    string LastName,
    string PhoneNumber) : IRequest<ErrorOr<UserResult>>;