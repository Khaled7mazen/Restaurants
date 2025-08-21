using FluentValidation;
using Restaurants.Application.Restaurant.Dtos;

namespace Restaurants.Application.Restaurant.Commands.CreateRestaurant;

public class CreateRestaurantDtoCommandValidator:AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> _validCategories = new List<string> 
    {
        "Italian", "Chinese", "Indian", "Mexican", "American", "French", "Japanese", "Mediterranean"
    };
    public CreateRestaurantDtoCommandValidator()
    {
        RuleFor(x => x.Category).Must(category => _validCategories.Contains(category))
            .WithMessage($"Category must be one of the valid categories");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Restaurant name is required.")
            .Length(3 , 100).WithMessage("Restaurant name must not exceed 100 characters.");

        //RuleFor(x => x.Description).NotEmpty()
        //    .WithMessage("Restaurant description is required.");

        //RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required.");

        RuleFor(x => x.ContactEmail)
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.PostalCode).NotEmpty()
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid postal code format. It should be a valid phone number format.");





    }

}
