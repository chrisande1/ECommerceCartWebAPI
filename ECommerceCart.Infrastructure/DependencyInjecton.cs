using ECommerceCart.Application.Common.Interface.Persistence.UserInterface;
using ECommerceCart.Infrastructure.Persistence;
using ECommerceCart.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceCart.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services
            .AddPersistence();

        
                
        return services; 
     }
 
    public static IServiceCollection AddPersistence(
        this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer( "Server=localhost;Database=ECommerceCartDB;User Id=sa;Password=Chr!s_@nde1;TrustServerCertificate=true"));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        

        return services;
    }
}