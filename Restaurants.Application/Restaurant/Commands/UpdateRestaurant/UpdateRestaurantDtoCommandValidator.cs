using FluentValidation;

namespace Restaurants.Application.Restaurant.Commands.UpdateRestaurant;

public class UpdateRestaurantDtoCommandValidator:AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantDtoCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Restaurant name is required.")
            .Length(3, 100);
    }
}
