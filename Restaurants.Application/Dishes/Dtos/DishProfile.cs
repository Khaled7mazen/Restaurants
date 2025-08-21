using AutoMapper;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Restaurant.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.Dtos
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
           
        CreateMap<Restaurants.Domain.Entities.Dish, DishDto>();
            CreateMap<CreateDishCommand, Restaurants.Domain.Entities.Dish>();
        }
    }
}
