using ECommerceCart.Application.CartCommandQuery.Command.Delete;
using ECommerceCart.Application.Common.Interface.Persistence.UserInterface;
using ECommerceCart.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ECommerceCart.Application.CartCommandQuery.Command.Delete;

public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, ErrorOr<bool>>
{

    private readonly ICartRepository _cartRepository;

    public DeleteCartItemCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<ErrorOr<bool>> Handle(DeleteCartItemCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var targetCartItem = await _cartRepository.GetById(command.CartItemId);

        if (targetCartItem == null)
        {
            return Errors.CartError.GetCartItemByIdNotFound;
        }

        await _cartRepository.DeleteById(targetCartItem.Id);

        return true; // Indicating a successful operation
    }

   
}