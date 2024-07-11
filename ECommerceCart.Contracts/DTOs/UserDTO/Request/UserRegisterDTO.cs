namespace ECommerceCart.Contracts.DTOs.UserDTO.Request;

public record UserRegisterDTO(
    string FirstName,
    string LastName,
    string PhoneNumber);