using Microsoft.AspNetCore.Mvc.Infrastructure;
using User.Api.Common.Mapping;

namespace ECommerceCart.Api;


public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, ECommerceCartProblemDetails>();
        services.AddMappings();
        return services;
    }
}