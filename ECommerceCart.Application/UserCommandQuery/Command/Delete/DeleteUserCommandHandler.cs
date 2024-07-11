using ECommerceCart.Application.Common.Interface.Persistence.UserInterface;
using ECommerceCart.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.UserCommandQuery.Command.Delete;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<bool>>
{

    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<bool>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var targetUser = await _userRepository.GetById(command.Id);

        if (targetUser == null)
        {
            return Errors.UserError.GetUserByIdNotFound;
        }

        await _userRepository.DeleteById(targetUser.Id);

        return true; // Indicating a successful operation
    }
}