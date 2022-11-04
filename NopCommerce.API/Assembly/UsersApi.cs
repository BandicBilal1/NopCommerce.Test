using NopCommerce.API.Models.Api.Users;

namespace NopCommerce.API.Assembly;
public class UsersApi
{
    public static T GetUsersApi<T>() where T : class

    {
        var page = (T)Activator.CreateInstance(typeof(T));
        return page;
    }

    public Users Users => GetUsersApi<Users>();
}
