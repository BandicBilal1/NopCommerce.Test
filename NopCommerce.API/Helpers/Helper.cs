using Newtonsoft.Json.Linq;

namespace NopCommerce.API.Helpers;
public static class Helper
{
    private static string AuthorizationInfo => "UserData/AuthorizationInfo.json";
    private static string UserLoginData => "UserData/UserLoginData.json";
    private static string UserCreateData => "UserData/UserDataCreate.json";

    /// <summary>
    /// Extract user login data from UserLoginData json file
    /// </summary>
    /// <returns></returns>
    public static JObject GetUserLoginDataInFormOfBody()
    {
        var json = Helper.ReadJson(UserLoginData);
        var jObject = JObject.Parse(json, new JsonLoadSettings());

        return jObject;
    }

    /// <summary>
    /// Extract user data (email, name, location) from UserLoginData json file
    /// </summary>
    /// <returns></returns>
    public static JObject GetUserCreateDataInFormOfBody()
    {
        var json = Helper.ReadJson(UserCreateData);
        var jObject = JObject.Parse(json, new JsonLoadSettings());
        jObject["email"].Replace($"{Helper.GenerateRandomString()}@gmail.com");

        return jObject;
    }

    /// <summary>
    /// Read json file into string
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <returns></returns>
    private static string ReadJson(string jsonPath)
    {
        StreamReader streamReader = new StreamReader(jsonPath);
        string json = streamReader.ReadToEnd();
        return json;
    }

    /// <summary>
    /// Generate random string with length based on the parameter
    /// </summary>
    /// <param name="lengthOfTheString"></param>
    /// <returns></returns>
    public  static string GenerateRandomString(int lengthOfTheString = 7)
    {
        var random = new Random();
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        return new string(Enumerable.Repeat(chars, lengthOfTheString)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

}