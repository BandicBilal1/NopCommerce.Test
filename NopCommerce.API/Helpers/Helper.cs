using Newtonsoft.Json.Linq;

namespace NopCommerce.API.Helpers;
public static class Helper
{
    private static string AuthorizationInfo => "UserData/AuthorizationInfo.json";
    private static string UserLoginData => "UserData/UserLoginData.json";
    private static string UserCreateData => "UserData/UserDataCreate.json";


    public static string GetAuthorizationToken()
    {
        var json = Helper.ReadJson(AuthorizationInfo);
        var tokenJToken = JObject.Parse(json)["token"];
        var token = tokenJToken.ToString();

        return token;
    }

    public static JObject GetUserLoginDataInFormOfBody()
    {
        var json = Helper.ReadJson(UserLoginData);
        var jObject = JObject.Parse(json, new JsonLoadSettings());

        return jObject;
    }

    public static JObject GetUserCreateDataInFormOfBody()
    {
        var json = Helper.ReadJson(UserCreateData);
        var jObject = JObject.Parse(json, new JsonLoadSettings());
        jObject["email"].Replace($"{Helper.GenerateRandomString()}@gmail.com");

        return jObject;
    }

    private static string ReadJson(string jsonPath)
    {
        StreamReader streamReader = new StreamReader(jsonPath);
        string json = streamReader.ReadToEnd();
        return json;
    }

    private static string GenerateRandomString(int lengthOfTheString = 7)
    {
        var random = new Random();
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        return new string(Enumerable.Repeat(chars, lengthOfTheString)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

}