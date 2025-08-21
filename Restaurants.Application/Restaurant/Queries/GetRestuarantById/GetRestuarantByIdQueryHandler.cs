using AutoMapper;
using MediatR;
using Restaurants.Application.Restaurant.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurant.Queries.GetRestuarantById;

public class GetRestuarantByIdQueryHandler(IMapper mapper , IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestuarantByIdQuery, RestaurantDto?>
{
    public async Task<RestaurantDto?> Handle(GetRestuarantByIdQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
        // var restaurantDto = RestaurantDto.FromEntity(restaurant);
        var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);

        return restaurantDto;
    }
}
