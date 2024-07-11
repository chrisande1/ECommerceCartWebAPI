using ErrorOr;

namespace ECommerceCart.Domain.Common.Errors;

public static partial class Errors
{
    public static class UserError
    {
        public static Error DuplicatePhoneNumber => Error.Conflict(
            code: "User.DuplicatePhoneNumber",
            description: "PhoneNumber is already in use");

        public static Error GetUserByIdNotFound => Error.NotFound(
            code: "Auth.GetUserByIdNotFound",
            description: "User not found");

        public static Error GetAllUsersFailed => Error.Failure(
                code: "Auth.GetAllUsersFailed",
                description: "Failed to retrieve users");

    }
}