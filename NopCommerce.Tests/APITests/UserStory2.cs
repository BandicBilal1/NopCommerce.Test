using NopCommerce.API.Assembly;
using NopCommerce.API.Models.Api.Users;
using NUnit.Allure.Core;

namespace NopCommerce.Tests.APITests;

[AllureNUnit]
public class UserStory2 : BaseApiTest
{
    
    [Test]
    [Property("ApiTest", "1")]
    public void TC_01_AC1_UnregisteredUserCannotGetAllUsers_ValidateResponse_401()
    {
        ApiFactory.UsersApi.SendGetAllUsersRequestAndValidateResponse();
    }

    [Test]
    [Property("ApiTest", "2")]
    public void TC_02_AC2_UserCanLogin_ValidateResponse_200()
    {
        ApiFactory.UsersApi.SendPostLoginUserRequestAndValidateResponse();
    }

    [Test]
    [Property("ApiTest", "3")]
    public void TC_03_AC2_CanCreateUser_ValidateResponse_200()
    {
        ApiFactory.UsersApi.SendPostUserRequestAndValidateResponse();
    }

    [Test]
    [Property("ApiTest", "4")]
    public void TC_04_AC2_GetUserById_ValidateResponse_200()
    {
        ApiFactory.UsersApi.SendGetUserByIdRequestAndValidateResponse();
    }

    [Test]
    [Property("ApiTest", "5")]
    public void TC_05_AC2_DeleteUserById_ValidateResponse_202()
    {
        ApiFactory.UsersApi.SendDeleteUserRequestAndValidateResponse();
    }

    [Test]
    [Property("ApiTest", "6")]
    public void TC_05_AC2_GetDeletedUserById_ValidateResponse_404()
    {
        ApiFactory.UsersApi.SendGetDeletedUserByIdAndValidateResponse();
    }

}
