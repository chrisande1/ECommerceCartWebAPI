using ECommerceCart.Application.Common.Interface.Persistence.Common;
using ECommerceCart.Domain.Model;

namespace ECommerceCart.Application.Common.Interface.Persistence.UserInterface;

public interface ICartRepository : IGenericRepository<Cart>
{
    public Task<IEnumerable<Cart>> GetAllCartItems();
    public Task<Cart?> UpdateCart(Cart cart);
    public Task<IEnumerable<Cart>> GetCartItems(
            string? phoneNumber = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? minQuantity = null,
            Guid? itemId = null);
    
    public Task<Cart?> GetCartByItemId(Guid itemId);
}