using ErrorOr;

namespace ECommerceCart.Domain.Common.Errors;

public static partial class Errors
{
    public static class CartError
    {
        public static Error GetCartItemByIdNotFound => Error.NotFound(
            code: "Cart.GetCartItemByIdNotFound",
            description: "Cart Item does not exist");

        public static Error GetCartByUserIdNotFound=> Error.NotFound(
            code: "Cart.GetCartByUserIdNotFound",
            description: "User does not exist");

        public static Error GetCartByPhoneNumberNotFound => Error.NotFound(
            code: "Cart.GetCartByPhoneNumberNotFound",
            description: "PhoneNumber does not exist");


        // public static Error GetAllUsersFailed => Error.Failure(
        //     code: "User.GetAllUsersFailed",
        //     description: "Failed to retrieve users");

        public static Error DeleteCartItemFailed => Error.Failure(
            code: "Cart.DeleteCartItemFailed",
            description: "Failed to delete cart item");

        
        public static Error NoCartItemsFound => Error.NotFound(
            code: "Cart.NoCartItemsFound",
            description: "No cart items found with the provided filters.");
        

    }
}