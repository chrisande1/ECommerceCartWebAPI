using ECommerceCart.Application.Common.Interface.Persistence.UserInterface;
using ECommerceCart.Domain.Model;
using ECommerceCart.Infrastructure.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;


namespace ECommerceCart.Infrastructure.Persistence.Repositories;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    public CartRepository(ApplicationDBContext dBContext) : base(dBContext)
    {

    }

    public async Task<IEnumerable<Cart>> GetAllCartItems()
    {
        return await _dBContext.Carts
            .Include(cart => cart.User)
            .Where(todo => todo.DeletedAt == null)
            .ToListAsync();
    }

    public async Task<Cart?> UpdateCart(Cart cart)
    {
        var existingCart = await _dBContext.Carts
            .Include(cart => cart.User)
            .FirstOrDefaultAsync(cart => cart.Id == cart.Id && cart.DeletedAt == null);

        if (existingCart == null)
        {
            return null;
        }

        // Update the cart properties here as needed
        existingCart.Quantity = cart.Quantity;

        await _dBContext.SaveChangesAsync();

        return existingCart;
    }

    public async Task<Cart?> GetCartByItemId(Guid itemId)
    {
        return await _dBContext.Carts
            .Include(cart => cart.User)
            .Where(c => c.DeletedAt == null && c.Id == itemId)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Cart>> GetCartItems(
        string? phoneNumber = null,
        DateTime? startTime = null,
        DateTime? endTime = null,
        int? minQuantity = null,
        Guid? itemId = null)
    {
        var query = _dBContext.Carts
            .Include(c => c.User)
            .Where(c => c.DeletedAt == null);

        if (!string.IsNullOrEmpty(phoneNumber))
        {
            query = query.Where(c => c.User.PhoneNumber == phoneNumber);
        }

        if (startTime.HasValue)
        {
            query = query.Where(c => c.CreatedAt >= startTime.Value);
        }

        if (endTime.HasValue)
        {
            query = query.Where(c => c.CreatedAt <= endTime.Value);
        }

        if (minQuantity.HasValue)
        {
            query = query.Where(c => c.Quantity >= minQuantity.Value);
        }

        if (itemId != Guid.Empty)
        {
            query = query.Where(c => c.Id == itemId);
        }

        return await query.ToListAsync();
    }

}
