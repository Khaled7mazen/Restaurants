using AutoMapper;
using MediatR;
using Restaurants.Application.Restaurant.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurant.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(IMapper mapper , IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = mapper.Map<Restaurants.Domain.Entities.Restaurant>(request);
        var id = await restaurantsRepository.CreateAsync(restaurant);
        return id;
    }
}
