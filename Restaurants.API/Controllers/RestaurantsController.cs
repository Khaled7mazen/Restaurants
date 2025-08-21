using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurant.Commands.CreateRestaurant;
using Restaurants.Application.Restaurant.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurant.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurant.Dtos;
using Restaurants.Application.Restaurant.Queries.GetAllRestaurant;
using Restaurants.Application.Restaurant.Queries.GetRestuarantById;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;

namespace Restaurants.API.Controllers;
//[Authorize]
[Route("api/restaurants")]
[ApiController]
public class RestaurantsController( IMediator mediator) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK,Type =  typeof(IEnumerable<RestaurantDto>))]
    public async Task<IActionResult> GetAll([FromQuery]GetAllRestaurantQuery query)
    {
        var restaurants = await mediator.Send(query);
        return Ok(restaurants);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RestaurantDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetRestuarantByIdQuery(id));
        if (restaurant is null)
        {
            return NotFound();
        }
        return Ok(restaurant);

    }
    [HttpPost]
    [Authorize(Roles = UserRole.RestaurantOwner)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateRestaurant( CreateRestaurantCommand createRestaurantCommand)
    {
        int id = await mediator.Send(createRestaurantCommand);
        return CreatedAtAction(nameof(GetById) , new {id } , null);
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
    {
        // Assuming you have a command to delete a restaurant
        var result = await mediator.Send(new DeleteRestaurantCommand(id));
        if (result)
        {
            return NoContent();
        }
        return NotFound();
    }
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, [FromBody] UpdateRestaurantCommand updateRestaurantCommand)
    {
        updateRestaurantCommand.Id = id; 
        var result = await mediator.Send(updateRestaurantCommand);
        if (result)
        {
            return NoContent();
        }
        return NotFound();
    }
}