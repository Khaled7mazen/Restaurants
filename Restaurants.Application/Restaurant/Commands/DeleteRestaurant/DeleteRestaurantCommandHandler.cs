using AutoMapper;
using MediatR;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurant.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(IMapper mapper , IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant =await restaurantsRepository.GetByIdAsync(request.Id);
        if (restaurant is null)
        {
            return false;
        }
        await restaurantsRepository.DeleteAsync(restaurant);
        return true;
    }
}
