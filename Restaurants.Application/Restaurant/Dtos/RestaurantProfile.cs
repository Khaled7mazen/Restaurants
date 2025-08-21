using AutoMapper;
using Microsoft.AspNetCore.Components.Server;
using Restaurants.Application.Restaurant.Commands.CreateRestaurant;
using Restaurants.Application.Restaurant.Commands.UpdateRestaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurant.Dtos
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<UpdateRestaurantCommand, Restaurants.Domain.Entities.Restaurant>();
               
            CreateMap< CreateRestaurantCommand , Restaurants.Domain.Entities.Restaurant>()
                .ForMember(dest => dest.Address , opt => opt.MapFrom(
                    scr => new Address
                    {
                        City = scr.City,
                        Street = scr.Street,
                        PostalCode = scr.PostalCode
                    }
                    ));
            CreateMap<Restaurants.Domain.Entities.Restaurant, RestaurantDto>()
                .ForMember(
                    dest => dest.City, opt => opt.MapFrom(src => src.Address != null ? src.Address.City : null))
                .ForMember(
                    dest => dest.Street, opt => opt.MapFrom(src => src.Address != null ? src.Address.Street : null))
                .ForMember(
                    dest => dest.PostalCode, opt => opt.MapFrom(src => src.Address != null ? src.Address.PostalCode : null)
                ).ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.Dishes));

        }
    }
}
