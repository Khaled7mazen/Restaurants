using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteAllDishes;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Query.GetAllDishesForRestaurant;
using Restaurants.Application.Dishes.Query.GetByDishByIdForRestaurant;
using Restaurants.Domain.Repositories;

namespace Restaurants.API.Controllers;

[Route("api/restaurants/{retaurantId}/dish")]
[ApiController]
public class DishesController(  IMediator mediator) : ControllerBase
{
    [HttpPost()]
    public async Task<IActionResult> CreateDish([FromRoute] int retaurantId , CreateDishCommand command)
    {
        command.RestaurantId = retaurantId;
       var dishId =  await mediator.Send(command);
        return CreatedAtAction(nameof(GetByDishByIdForRestaurant) , new { retaurantId  , dishId } , null);
    }
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetAllDishesForRestaurant([FromRoute] int retaurantId)
    {
      var dishes=  await mediator.Send( new GetAllDishesForRestaurantQuery(retaurantId));
        return Ok(dishes);
    }
    [HttpGet("{dishId}")]
    public async Task<ActionResult<DishDto>> GetByDishByIdForRestaurant([FromRoute] int retaurantId , [FromRoute] int dishId)
    {
        var dish = await mediator.Send(new GetByDishByIdForRestaurantQuery(retaurantId , dishId));
        return Ok(dish);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAllDishes([FromRoute] int retaurantId)
    {
      await mediator.Send(new DeleteAllDishesCommand(retaurantId));
        
        return NoContent();
    }

}
