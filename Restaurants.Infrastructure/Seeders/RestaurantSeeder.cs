using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Constants;
using Restaurants.Infrastructure.persistence;

namespace Restaurants.Infrastructure.Seeders
{
    internal class RestaurantSeeder(RestaurantsDbContext restaurantsDbContext) : IRestaurantSeeder
    {
        public async Task Seed()
        {
            if (!await restaurantsDbContext.Database.CanConnectAsync())
                return;

            // Seed Roles
            if (!restaurantsDbContext.Roles.Any())
            {
                var roles = GetRoles();
                await restaurantsDbContext.Roles.AddRangeAsync(roles);
                await restaurantsDbContext.SaveChangesAsync();
            }
        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            return new List<IdentityRole>
                {
                    new IdentityRole(UserRole.User),
                    new IdentityRole(UserRole.Admin),
                    new IdentityRole(UserRole.RestaurantOwner)
                };

        }
    }
}
