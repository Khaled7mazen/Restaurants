using AutoMapper;
using MediatR;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurant.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(IMapper mapper , IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant =await restaurantsRepository.GetByIdAsync(request.Id);
        if (restaurant is null)
        {
            return false;
        }
        mapper.Map(request, restaurant);
        //restaurant.Name = request.Name;
        //restaurant.Description = request.Description;
        //restaurant.HasDelivery = request.HasDelivery;
        restaurantsRepository.SaveChanges();
        return true;
    }
}
