using AutoMapper;
using MediatR;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler(IMapper mapper, IDishsRepository dishsRepository
    , IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateDishCommand , int>
{
   

    async Task<int> IRequestHandler<CreateDishCommand, int>.Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null)
        {
            throw new ArgumentException($"Restaurant with id {request.RestaurantId} does not exist.");
        }
        var dish = mapper.Map<Restaurants.Domain.Entities.Dish>(request);
       return await dishsRepository.CreateDish(dish);
    }
}
