using ErrorOr;

namespace ECommerceCart.Domain.Common.Errors;

public static partial class Errors
{
    public static class CartItemError
    {
        public static Error GetCartItemByIdNotFound => Error.NotFound(
            code: "Auth.GetCartByIdNotFound",
            description: "Cart Item not found");

        public static Error GetCartItemByPhoneNumberNotFound => Error.NotFound(
            code: "Auth.GetUserByIdNotFound",
            description: "PhoneNumber does not exist");

        public static Error GetAllUsersFailed => Error.Failure(
                code: "Auth.GetAllUsersFailed",
                description: "Failed to retrieve users");

    }
}