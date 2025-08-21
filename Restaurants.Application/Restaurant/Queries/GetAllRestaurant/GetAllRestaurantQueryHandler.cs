using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurants.Application.Restaurant.Dtos;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Repository.common;

namespace Restaurants.Application.Restaurant.Queries.GetAllRestaurant;

public class GetAllRestaurantQueryHandler(IMapper mapper , IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestaurantQuery, PageResult<RestaurantDto>>
{
    public async Task<PageResult<RestaurantDto>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
    {
        var (restuarants , totalCount) = await restaurantsRepository
            .GetAllMatchingAsync(request.SearchPhrase , 
            request.pageSize,
            request.pageNumber,
            request.sortBy,
            request.sortDirection 
            );
        // var restaurantDto = restuarants.Select(RestaurantDto.FromEntity);
        var restaurantDto = mapper.Map<IEnumerable<RestaurantDto>>(restuarants);

        var result = new PageResult<RestaurantDto>(restaurantDto , totalCount, request.pageSize , request.pageNumber);
        return result;
    }
}
