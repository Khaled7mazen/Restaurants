using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IDishsRepository
{
    Task<int> CreateDish(Dish dish);
    Task DeleteAllDishesAsync(IEnumerable<Dish> dish);

}
