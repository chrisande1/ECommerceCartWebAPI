namespace ECommerceCart.Contracts.DTOs.CartTO;

public record CreateCartRequestDTO(
    Guid UserId,
    string ItemName,
    int Quantity,
    decimal UnitPrice);
