using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandValidator:AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(x=>x.Price).GreaterThanOrEqualTo(0)
            .WithMessage("Price must be greater than or equal to 0");   

        RuleFor(x=>x.KiloCalories).GreaterThanOrEqualTo(0)
            .WithMessage("KiloCalories must be greater than or equal to 0");    
    }
}
