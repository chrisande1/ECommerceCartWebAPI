using ECommerceCart.Application.CartCommandQuery.Common;
using ECommerceCart.Application.Common.Interface.Persistence.UserInterface;
using ECommerceCart.Domain.Common.Errors;
using ECommerceCart.Domain.Model;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.CartCommandQuery.Command.CreateCart;

public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, ErrorOr<CartResult>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUserRepository _userRepository;

    public CreateCartCommandHandler(ICartRepository cartRepository, IUserRepository userRepository)
    {
        _cartRepository = cartRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CartResult>> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var user = await _userRepository.GetById(command.UserId);

        if (user == null)
        {
            return Errors.CartError.GetCartByUserIdNotFound;
        }

        var cart = new Cart
        {
            ItemName = command.ItemName,
            Quantity = command.Quantity,
            UnitPrice = command.UnitPrice,
            User = user
            
        };

        await _cartRepository.Add(cart);
        
        return new CartResult(
            cart
        );
    }
}