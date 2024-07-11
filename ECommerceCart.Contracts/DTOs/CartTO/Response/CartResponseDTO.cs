namespace ECommerceCart.Contracts.DTOs.CartTO.Response;

public record CartResponseDTO(
    Guid CartItemId,
    Guid UserId,
    string ItemName,
    int Quantity,
    decimal UnitPrice);