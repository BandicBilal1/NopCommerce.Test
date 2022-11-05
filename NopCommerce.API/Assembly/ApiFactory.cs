using NopCommerce.API.Models.Api.Users;

namespace NopCommerce.API.Assembly;
public  class ApiFactory
{
    public  UsersApiClient UsersApi => new UsersApiClient();
}
