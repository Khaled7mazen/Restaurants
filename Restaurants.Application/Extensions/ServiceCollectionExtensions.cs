using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurant;
using Restaurants.Application.Users;
using Restaurants.Domain.Repositories;
using System.Reflection;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
       // services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() })
            .AddFluentValidationAutoValidation();
        services.AddMediatR(cfg => 
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });

        services.AddHttpContextAccessor();
        services.AddScoped<IUserContext, UserContext>();
       
    }
}
