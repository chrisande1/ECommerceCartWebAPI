using ECommerceCart.Application.Common.Interface.Persistence.UserInterface;
using ECommerceCart.Domain.Model;
using ECommerceCart.Infrastructure.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;


namespace ECommerceCart.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDBContext dBContext) : base(dBContext)
    {

    }

    public async Task<User?> GetUserByPhoneNumber(string phoneNumber)
    {
        return await _dBContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
    }
}
