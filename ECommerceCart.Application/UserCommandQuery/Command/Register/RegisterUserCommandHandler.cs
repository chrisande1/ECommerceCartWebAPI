using ECommerceCart.Application.Common.Interface.Persistence.UserInterface;
using ECommerceCart.Application.UserCommandQuery.Common;
using ECommerceCart.Domain.Common.Errors;
using ECommerceCart.Domain.Model;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.UserCommandQuery.Command.Register;


public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ErrorOr<UserResult>>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserResult>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Validate if user doesn't exist
        if (await _userRepository.GetUserByPhoneNumber(command.PhoneNumber)!=null)
        {
            return Errors.UserError.DuplicatePhoneNumber;
        }

        //Create user & persist to DB
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            PhoneNumber = command.PhoneNumber
        };

        

        await _userRepository.Add(user);

        return new UserResult(
            user
        );
    }
}