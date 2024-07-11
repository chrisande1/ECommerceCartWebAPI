using ECommerceCart.Application.Common.Interface.Persistence.Common;
using ECommerceCart.Domain.Model;

namespace ECommerceCart.Application.Common.Interface.Persistence.UserInterface;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User?> GetUserByPhoneNumber(string phoneNumber);
}