using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Query.GetAllDishesForRestaurant;

public class GetAllDishesForRestaurantQuery : IRequest<IEnumerable<DishDto>>
{
    public int RestaurantId { get; set; }
    public GetAllDishesForRestaurantQuery(int restaurantId)
    {
        RestaurantId = restaurantId;
    }
}

