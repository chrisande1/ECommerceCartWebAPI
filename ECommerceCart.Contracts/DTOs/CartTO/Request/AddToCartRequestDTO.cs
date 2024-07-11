namespace ECommerceCart.Contracts.DTOs.CartTO.Response;

public record AddToCartRequestDTO(
    Guid ItemId,
    int Quantity);