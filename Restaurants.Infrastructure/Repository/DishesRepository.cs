using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Repository
{
    internal class DishesRepository(RestaurantsDbContext dbContext) : IDishsRepository
    {
        public async Task<int> CreateDish(Dish dish)
        {
           var diish =  dbContext.Dishes.Add(dish);
           await dbContext.SaveChangesAsync();
            return dish.Id;

        }

        public async Task DeleteAllDishesAsync(IEnumerable<Dish> dish)
        {
            dbContext.Dishes.RemoveRange(dish);
            await dbContext.SaveChangesAsync();
        }
    }
}
