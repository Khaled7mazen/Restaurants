namespace Restaurants.Application.Users;

public class CurrentUser(string Email , string Id , IEnumerable<string> Role)
{
    public bool IsInRole(string role) => Role.Contains(role);
}
