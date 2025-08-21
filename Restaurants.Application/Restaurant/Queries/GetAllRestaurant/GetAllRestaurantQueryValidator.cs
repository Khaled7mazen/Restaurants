using FluentValidation;
using Restaurants.Application.Restaurant.Dtos;

namespace Restaurants.Application.Restaurant.Queries.GetAllRestaurant;

public class GetAllRestaurantQueryValidator: AbstractValidator<GetAllRestaurantQuery>
{
    private int[] allowPageSizes = new[] { 5, 10, 20 };
    private string[] allowSortBy =[nameof(RestaurantDto.Name),
        nameof(RestaurantDto.Description),
    nameof(RestaurantDto.Category)] ;
    public GetAllRestaurantQueryValidator()
    {
        RuleFor(x => x.pageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage(" PAGE NUMBER must be greater or equal to  1.");

        RuleFor(x => x.pageSize)
            .Must(value => allowPageSizes.Contains(value))
            .WithMessage($"Page size must be 5 , 10 , 15");

        RuleFor(x => x.sortBy)
          .Must(value => allowSortBy.Contains(value))
          .When(c=>c.sortBy is not null)
          .WithMessage("sortBy is optional but  must be based on  Name ,Description , Category ");


    }
}
