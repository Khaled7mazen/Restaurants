using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Users.Commands;

public class UpdateUserCommandHandler(IUserContext userContext
   // IUserStore<User> userStore
    ) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        //var user = userContext.GetCurrentUser() ;
        //var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken).Result;

        //dbUser.Nationality = user.Nationality;
    }
}
