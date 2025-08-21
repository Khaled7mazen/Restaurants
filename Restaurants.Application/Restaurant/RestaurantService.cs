//using AutoMapper;
//using Microsoft.Extensions.Logging;
//using Restaurants.Application.Restaurant.Dtos;
//using Restaurants.Domain.Entities;
//using Restaurants.Domain.Repositories;
//namespace Restaurants.Application.Restaurant
//{
//    internal class RestaurantService(
//        IRestaurantsRepository restaurantsRepository, ILogger<Restaurants.Domain.Entities.Restaurant> logger,
//        IMapper mapper
//        ) : IRestaurantService
//    {
//        //public async Task<int> CreateRestaurantAsync(CreateRestaurantDto createRestaurantDto)
//        //{
//        //    var restaurant = mapper.Map<Restaurants.Domain.Entities.Restaurant>(createRestaurantDto);
//        //   var id =await restaurantsRepository.CreateAsync(restaurant);
//        //    return id;

//        //}

//        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurantsAsync()
//        {
//            var restuarants = await restaurantsRepository.GetAllAsync();
//           // var restaurantDto = restuarants.Select(RestaurantDto.FromEntity);
//            var restaurantDto = mapper.Map<IEnumerable<RestaurantDto>>(restuarants);
//            return restaurantDto!;


//        }

//        public async Task<RestaurantDto?> GetRestaurantByIdAsync(int id)
//        {
//            var restaurant = await restaurantsRepository.GetByIdAsync(id);
//           // var restaurantDto = RestaurantDto.FromEntity(restaurant);
//            var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);

//            return restaurantDto;
//        }
//    }
//}
