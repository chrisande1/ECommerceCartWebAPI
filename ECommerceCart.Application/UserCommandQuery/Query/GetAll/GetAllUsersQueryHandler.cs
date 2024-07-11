using ECommerceCart.Application.Common.Interface.Persistence.UserInterface;
using ECommerceCart.Application.UserCommandQuery.Common;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.UserCommandQuery.Query.GetAll;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ErrorOr<IEnumerable<UserResult>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<IEnumerable<UserResult>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Fetch users from repository
        var allUsers = await _userRepository.GetAll();

        // If userModels is null, return an empty list as successful result
        if (allUsers == null)
        {
            return new List<UserResult>(); // Return an empty list directly
        }

        // Map UserModel to UserResult
        var userResult = allUsers
            .Where(user => user != null) // Ensure no null users are processed
            .Select(user => new UserResult(
                user
            )).ToList();

        // Return the mapped list wrapped in an ErrorOr type
        return userResult; // Return the list directly
    }

}