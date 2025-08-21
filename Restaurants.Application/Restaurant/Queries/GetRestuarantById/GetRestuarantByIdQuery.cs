using MediatR;
using Restaurants.Application.Restaurant.Dtos;

namespace Restaurants.Application.Restaurant.Queries.GetRestuarantById;

public class GetRestuarantByIdQuery: IRequest<RestaurantDto?>
{
    public int Id { get;  }
    public GetRestuarantByIdQuery(int id)
    {
        
        Id = id;
    }
}
