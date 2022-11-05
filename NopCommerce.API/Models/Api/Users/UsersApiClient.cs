using System.Diagnostics;
using System.Net;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NopCommerce.API.Helpers;
using NUnit.Framework;
using RestSharp;

namespace NopCommerce.API.Models.Api.Users;
public class UsersApiClient
{
    private string Token { get; set; }
    private string CreatedUserId { get; set; }
    private string ErrorMessage { get; set; }
    private string ResponseContent { get; set; }
    private static RestClient RestClient { get; set; }
    private static RestResponse Response { get; set; }
    private static RestRequest RestRequest { get; set; }

    /// <summary>
    /// Set BaseUrl for client
    /// </summary>
    /// <returns></returns>
    private void InitializeEndpoint()
    {
        var endpointUri = new Uri("http://restapi.adequateshop.com/");
        RestClient = new RestClient(endpointUri);
    }

    /// <summary>
    /// Execute GET/api/users, get all users endpoint of api
    /// </summary>
    /// <returns></returns>
    private void SendGetAllUsersRequest()
    {
        RestRequest = new RestRequest("api/users/", Method.Get);
        Response = RestClient.Execute(RestRequest);
        ErrorMessage = JsonConvert.SerializeObject(Response.Content, Formatting.Indented);
    }

    /// <summary>
    /// Execute POST/api/authaccount/login, user login endpoint of api
    /// </summary>
    /// <returns></returns>
    private void SendPostLoginUserRequest()
    {
        var jsonBody = JsonConvert.SerializeObject(Helper.GetUserLoginDataInFormOfBody());

        RestRequest = new RestRequest("api/authaccount/login", Method.Post);
        RestRequest.RequestFormat = DataFormat.Json;
        RestRequest.AddParameter("application/json", jsonBody,  ParameterType.RequestBody);
        Response = RestClient.Execute(RestRequest);

        var responseJObject = (JObject)JsonConvert.DeserializeObject(Response.Content);
        Token = $"Bearer {responseJObject["data"]["Token"].ToString()}";

    }

    /// <summary>
    /// Execute POST/api/users, create user endpoint of api
    /// </summary>
    /// <returns></returns>
    private void SendPostUserRequest()
    {
        var jsonBody = JsonConvert.SerializeObject(Helper.GetUserCreateDataInFormOfBody());

        RestRequest = new RestRequest("api/users", Method.Post);
        RestRequest.AddHeader("Authorization", Token);
        RestRequest.RequestFormat = DataFormat.Json;
        RestRequest.AddParameter("application/json", jsonBody,  ParameterType.RequestBody);
        Response = RestClient.Execute(RestRequest);

        var responseJObject = (JObject)JsonConvert.DeserializeObject(Response.Content);
        CreatedUserId = responseJObject["id"].ToString();
    }

    /// <summary>
    /// Execute GET/api/users/{id}, get user by id endpoint of api
    /// </summary>
    /// <returns></returns>
    private void SendGetUserById()
    {
        var path = $"api/users/{CreatedUserId}";
        RestRequest = new RestRequest(path, Method.Get);
        RestRequest.AddHeader("Authorization", Token);
        Response = RestClient.Execute(RestRequest);
    }

    /// <summary>
    /// Execute DELETE/api/users/{id}, delete user by id endpoint of api
    /// </summary>
    /// <returns></returns>
    private void SendDeleteUserById()
    {
        var path = $"api/users/{CreatedUserId}";
        RestRequest = new RestRequest(path, Method.Delete);
        RestRequest.AddHeader("Authorization", Token);
        Response = RestClient.Execute(RestRequest);
    }

    /// <summary>
    /// Validate unauthorized response for get all users endpoint
    /// </summary>
    /// <returns></returns>
    private void ValidateGetAllUsersUnauthorizedResponse()
    {
        Assert.AreEqual(HttpStatusCode.Unauthorized, Response.StatusCode);
        ErrorMessage.Contains("please send bearer token in header,'Authorization':'bearer your_token'").Should().BeTrue();
    }

    /// <summary>
    /// Validate OK response for user login endpoint
    /// </summary>
    /// <returns></returns>
    private void ValidatePostLoginUserOKResponse()
    {
        Assert.AreEqual(HttpStatusCode.OK, Response.StatusCode);
    }

    /// <summary>
    /// Validate Created response for create a user endpoint
    /// </summary>
    /// <returns></returns>
    private void ValidatePostUserOKResponse()
    {
        Assert.AreEqual(HttpStatusCode.Created, Response.StatusCode);
    }

    /// <summary>
    /// Validate OK response for get a user by id endpoint
    /// </summary>
    /// <returns></returns>
    private void ValidateGetUserByIdOKResponse()
    {
        Assert.AreEqual(HttpStatusCode.OK, Response.StatusCode);
    }

    /// <summary>
    /// Validate Accepted response for delete a user by id endpoint
    /// </summary>
    /// <returns></returns>
    private void ValidateDeleteUserByIdAcceptedResponse()
    {
        Assert.AreEqual(HttpStatusCode.Accepted, Response.StatusCode);
    }

    /// <summary>
    /// Validate NotFound response for get a deleted user by id endpoint
    /// </summary>
    /// <returns></returns>
    private void ValidateGetDeletedUserById()
    {
        Assert.AreEqual(HttpStatusCode.NotFound, Response.StatusCode);
    }

    /// <summary>
    /// Send Request get all users and validate response
    /// </summary>
    /// <returns></returns>
    public void SendGetAllUsersRequestAndValidateResponse()
    {
        InitializeEndpoint();
        SendGetAllUsersRequest();
        ValidateGetAllUsersUnauthorizedResponse();
    }

    /// <summary>
    /// Send User login request and validate response
    /// </summary>
    /// <returns></returns>
    public void SendPostLoginUserRequestAndValidateResponse()
    {
        InitializeEndpoint();
        SendPostLoginUserRequest();
        ValidatePostLoginUserOKResponse();
    }

    /// <summary>
    /// Send create User request and validate response
    /// </summary>
    /// <returns></returns>
    public void SendPostUserRequestAndValidateResponse()
    {
        InitializeEndpoint();
        SendPostLoginUserRequest();
        SendPostUserRequest();
        ValidatePostUserOKResponse();
    }

    /// <summary>
    /// Send get User by id request and validate response
    /// </summary>
    /// <returns></returns>
    public void SendGetUserByIdRequestAndValidateResponse()
    {
        InitializeEndpoint();
        SendPostLoginUserRequest();
        SendPostUserRequest();
        ValidatePostUserOKResponse();
        SendGetUserById();
        ValidateGetUserByIdOKResponse();
    }

    /// <summary>
    /// Send delete User by id request and validate response
    /// </summary>
    /// <returns></returns>
    public void SendDeleteUserRequestAndValidateResponse()
    {
        InitializeEndpoint();
        SendPostLoginUserRequest();
        SendPostUserRequest();
        ValidatePostUserOKResponse();
        SendGetUserById();
        ValidateGetUserByIdOKResponse();
        SendDeleteUserById();
        ValidateDeleteUserByIdAcceptedResponse();
    }

    /// <summary>
    /// Send get deleted User by id request and validate response
    /// </summary>
    /// <returns></returns>
    public void SendGetDeletedUserByIdAndValidateResponse()
    {
        InitializeEndpoint();
        SendPostLoginUserRequest();
        SendPostUserRequest();
        ValidatePostUserOKResponse();
        SendGetUserById();
        ValidateGetUserByIdOKResponse();
        SendDeleteUserById();
        ValidateDeleteUserByIdAcceptedResponse();
        SendGetUserById();
        ValidateGetDeletedUserById();
    }
}


