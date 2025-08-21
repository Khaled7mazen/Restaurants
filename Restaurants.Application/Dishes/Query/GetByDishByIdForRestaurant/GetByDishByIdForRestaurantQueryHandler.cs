using AutoMapper;
using MediatR;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Query.GetByDishByIdForRestaurant;

public class GetByDishByIdForRestaurantQueryHandler(IDishsRepository dishsRepository,
    IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetByDishByIdForRestaurantQuery, DishDto>
{
    public async Task<DishDto> Handle(GetByDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null)
        {
            throw new ArgumentException($"Restaurant with id {request.RestaurantId} does not exist.");
        }
       var dish = restaurant.Dishes.FirstOrDefault(x => x.Id == request.DishId);
        if (dish is null)
        {
            throw new ArgumentException($"Restaurant with id {request.DishId} does not exist.");
        }
        var result = mapper.Map<DishDto>(dish);
        return result;
    }
}
