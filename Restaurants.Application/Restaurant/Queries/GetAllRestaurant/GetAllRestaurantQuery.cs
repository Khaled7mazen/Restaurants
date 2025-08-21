using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurants.Domain.Constants;
using Restaurants.Infrastructure.Repository.common;

namespace Restaurants.Application.Restaurant.Queries.GetAllRestaurant;

public class GetAllRestaurantQuery: IRequest<PageResult<Restaurant.Dtos.RestaurantDto>> 
{
    public string? SearchPhrase { get; set; }
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    public string? sortBy { get; set; }
    public SortDirection sortDirection { get; set; }
}
