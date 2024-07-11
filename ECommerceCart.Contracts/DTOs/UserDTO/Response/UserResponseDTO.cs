namespace ECommerceCart.Contracts.DTOs.UserDTO.Response;

public record UserResponseDTO(
    Guid Id,
    string FullName,
    string PhoneNumber);