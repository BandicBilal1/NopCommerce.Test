namespace NopCommerce.Tests.APITests;
public class UserStory2 : BaseTest
{
    [Test]
    [Property("Test", "1")]
    public void TC_01_AC1_UnregisteredUserCannotGetAllUsers_ValidateResponse_401()
    {
        UsersApi.Users.SendGetAllUsersRequestAndValidateResponse();
    }

    [Test]
    [Property("Test", "2")]
    public void TC_02_AC2_UserCanLogin_ValidateResponse_200()
    {
        UsersApi.Users.SendPostLoginUserRequestAndValidateResponse();
    }

    [Test]
    [Property("Test", "3")]
    public void TC_03_AC2_CanCreateUser_ValidateResponse_200()
    {
        UsersApi.Users.SendPostUserRequestAndValidateResponse();
    }

    [Test]
    [Property("Test", "4")]
    public void TC_04_AC2_GetUserById_ValidateResponse_200()
    {
        UsersApi.Users.SendGetUserByIdRequestAndValidateResponse();
    }

    [Test]
    [Property("Test", "5")]
    public void TC_05_AC2_DeleteUserById_ValidateResponse_202()
    {
        UsersApi.Users.SendDeleteUserRequestAndValidateResponse();
    }

    [Test]
    [Property("Test", "6")]
    public void TC_05_AC2_GetDeletedUserById_ValidateResponse_404()
    {
        UsersApi.Users.SendGetDeletedUserByIdAndValidateResponse();
    }

}
