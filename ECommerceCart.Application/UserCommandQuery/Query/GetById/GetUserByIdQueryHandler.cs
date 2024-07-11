using ECommerceCart.Application.Common.Interface.Persistence.UserInterface;
using ECommerceCart.Application.UserCommandQuery.Common;
using ErrorOr;
using MediatR;
using ECommerceCart.Domain.Common.Errors;

namespace ECommerceCart.Application.UserCommandQuery.Query.GetById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ErrorOr<UserResult>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<UserResult>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // Fetch user from repository based on user ID
            var user = await _userRepository.GetById(query.Id);

            // If userModel is null, return an error
            if (user == null)
            {
                return Errors.UserError.GetUserByIdNotFound;
            }

            // Map UserModel to UserResult
            var userResult = new UserResult(
                user);
                

            // Return the mapped user result
            return userResult; // Return the UserResult directly
        }
    }

