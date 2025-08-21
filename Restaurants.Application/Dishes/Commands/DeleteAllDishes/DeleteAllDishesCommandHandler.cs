using AutoMapper;
using MediatR;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteAllDishes
{
    public class DeleteAllDishesCommandHandler(IMapper mapper, IDishsRepository dishsRepository
    , IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteAllDishesCommand>
    {
        public async Task Handle(DeleteAllDishesCommand request, CancellationToken cancellationToken)
        {
           var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if(restaurant is null)
            {
                throw new ArgumentException($"Restaurant with id {request.RestaurantId} does not exist.");
            }
            await dishsRepository.DeleteAllDishesAsync(restaurant.Dishes);
        }
    }
}
