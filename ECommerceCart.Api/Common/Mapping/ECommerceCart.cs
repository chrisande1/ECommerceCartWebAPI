using ECommerceCart.Application.CartCommandQuery.Common;
using ECommerceCart.Application.UserCommandQuery.Common;
using ECommerceCart.Contracts.DTOs.CartTO.Response;
using ECommerceCart.Contracts.DTOs.UserDTO.Response;
using Mapster;

namespace ECommerceCart.Api.Common.Mapping;

public class CartItemMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // User mapping
        config.NewConfig<UserResult, UserResponseDTO>()
            .Map(dest => dest.Id, src => src.User.Id)
            .Map(dest => dest.FullName, src => src.User.FirstName + " " + src.User.LastName)
            .Map(dest => dest.PhoneNumber, src => src.User.PhoneNumber);

        config.NewConfig<CartResult, CartResponseDTO>()
            .Map(dest => dest.CartItemId, src => src.Cart.Id)
            .Map(dest => dest.UserId, src => src.Cart.User.Id)
            .Map(dest => dest.ItemName, src => src.Cart.ItemName)
            .Map(dest => dest.Quantity, src => src.Cart.Quantity)
            .Map(dest => dest.UnitPrice, src => src.Cart.UnitPrice);
    }
}
