using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.persistence;
using System.Linq.Expressions;

namespace Restaurants.Infrastructure.Repository
{
    internal class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantsRepository
    {
        public async Task<int> CreateAsync(Restaurant restaurant)
        {
           var CreatedRestaurant = dbContext.Restaurants.Add(restaurant);
               await dbContext.SaveChangesAsync();
            return restaurant.Id;
        }

        public async Task DeleteAsync(Restaurant restaurant)
        {
            dbContext.Restaurants.Remove(restaurant);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await dbContext.Restaurants.Include(r => r.Dishes).ToListAsync();
            return restaurants;
        }
        public async Task<(IEnumerable<Restaurant>, int) > GetAllMatchingAsync(string? searchPhase,
            int pageSize, int PageNumber, string? sortBy, SortDirection sortDirection)
        {
            var searchPhaseLower = searchPhase?.ToLower() ;

            var baseQuery =  dbContext.Restaurants
                .Where(c => searchPhase == null || (c.Name.ToLower().Contains(searchPhaseLower) || c.Description.ToLower().Contains(searchPhaseLower)));
                
                var totalCount = await baseQuery.CountAsync();

               if(sortBy != null)
                {
                    var columnsSelector = new Dictionary<string, Expression<Func<Restaurant, object>>>
                    {                   
                            { nameof(Restaurant.Name),        r => r.Name },
                            { nameof(Restaurant.Description), r => r.Description },
                            { nameof(Restaurant.Category),    r => r.Category }
                    };

                     var selectedColumn = columnsSelector[sortBy];

                        baseQuery = sortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
                }

            var restaurants =await baseQuery.Skip((PageNumber - 1) * pageSize).Take(pageSize)
                    .Include(r => r.Dishes).ToListAsync();

            return (restaurants , totalCount);
        }

        public async Task<Restaurants.Domain.Entities.Restaurant?> GetByIdAsync(int id)
        {
            var restuarant =await dbContext.Restaurants.Include(r => r.Dishes).FirstOrDefaultAsync(r => r.Id == id);
            return restuarant;

        }

        public Task SaveChanges()
        {
           return dbContext.SaveChangesAsync();
        }
    }
}
