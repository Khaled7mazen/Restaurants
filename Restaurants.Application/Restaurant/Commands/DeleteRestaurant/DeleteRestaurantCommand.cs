using MediatR;

namespace Restaurants.Application.Restaurant.Commands.DeleteRestaurant;

public class DeleteRestaurantCommand:IRequest<bool>
{
    public int Id { get; }
    public DeleteRestaurantCommand(int id)
    {
        Id = id;
    }
}

