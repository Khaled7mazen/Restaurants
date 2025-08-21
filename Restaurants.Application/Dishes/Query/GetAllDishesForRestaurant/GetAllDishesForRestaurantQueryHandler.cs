using AutoMapper;
using MediatR;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Query.GetAllDishesForRestaurant;

public class GetAllDishesForRestaurantQueryHandler(IDishsRepository  dishsRepository,
    IMapper mapper , IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllDishesForRestaurantQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetAllDishesForRestaurantQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null)
        {
            throw new ArgumentException($"Restaurant with id {request.RestaurantId} does not exist.");
        }
        var dishes = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);
        return dishes;
    }
}
