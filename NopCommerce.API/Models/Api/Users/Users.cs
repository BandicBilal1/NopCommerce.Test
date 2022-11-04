using System.Diagnostics;
using System.Net;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NopCommerce.API.Helpers;
using NUnit.Framework;
using RestSharp;

namespace NopCommerce.API.Models.Api.Users;
public class Users
{
    private string Token { get; set; }
    private string CreatedUserId { get; set; }
    private string ErrorMessage { get; set; }
    private string ResponseContent { get; set; }
    private static RestClient RestClient { get; set; }
    private static RestResponse Response { get; set; }
    private static RestRequest RestRequest { get; set; }

    private void InitializeEndpoint()
    {
        var endpointUri = new Uri("http://restapi.adequateshop.com/");
        RestClient = new RestClient(endpointUri);
    }

    private void SendGetAllUsersRequest()
    {
        RestRequest = new RestRequest("api/users/", Method.Get);
        Response = RestClient.Execute(RestRequest);
        ErrorMessage = JsonConvert.SerializeObject(Response.Content, Formatting.Indented);
    }

    private void SendPostLoginUserRequest()
    {
        var jsonBody = JsonConvert.SerializeObject(Helper.GetUserLoginDataInFormOfBody());

        RestRequest = new RestRequest("api/authaccount/login", Method.Post);
        //RestRequest.AddHeader("Authorization", Token);
        RestRequest.RequestFormat = DataFormat.Json;
        RestRequest.AddParameter("application/json", jsonBody,  ParameterType.RequestBody);
        Response = RestClient.Execute(RestRequest);

        var responseJObject = (JObject)JsonConvert.DeserializeObject(Response.Content);
        Token = $"Bearer {responseJObject["data"]["Token"].ToString()}";

    }

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

    private void SendGetUserById()
    {
        var path = $"api/users/{CreatedUserId}";
        RestRequest = new RestRequest(path, Method.Get);
        RestRequest.AddHeader("Authorization", Token);
        Response = RestClient.Execute(RestRequest);
    }

    private void SendDeleteUserById()
    {
        var path = $"api/users/{CreatedUserId}";
        RestRequest = new RestRequest(path, Method.Delete);
        RestRequest.AddHeader("Authorization", Token);
        Response = RestClient.Execute(RestRequest);
    }

    private void ValidateGetAllUsersUnauthorizedResponse()
    {
        Assert.AreEqual(HttpStatusCode.Unauthorized, Response.StatusCode);
        ErrorMessage.Contains("please send bearer token in header,'Authorization':'bearer your_token'").Should().BeTrue();
    }

    private void ValidatePostLoginUserOKResponse()
    {
        Assert.AreEqual(HttpStatusCode.OK, Response.StatusCode);
    }

    private void ValidatePostUserOKResponse()
    {
        Assert.AreEqual(HttpStatusCode.Created, Response.StatusCode);
    }

    private void ValidateGetUserByIdOKResponse()
    {
        Assert.AreEqual(HttpStatusCode.OK, Response.StatusCode);
    }

    private void ValidateDeleteUserByIdAcceptedResponse()
    {
        Assert.AreEqual(HttpStatusCode.Accepted, Response.StatusCode);
    }

    private void ValidateGetDeletedUserById()
    {
        Assert.AreEqual(HttpStatusCode.NotFound, Response.StatusCode);
    }

    public void SendGetAllUsersRequestAndValidateResponse()
    {
        InitializeEndpoint();
        SendGetAllUsersRequest();
        ValidateGetAllUsersUnauthorizedResponse();
    }

    public void SendPostLoginUserRequestAndValidateResponse()
    {
        InitializeEndpoint();
        SendPostLoginUserRequest();
        ValidatePostLoginUserOKResponse();
    }

    public void SendPostUserRequestAndValidateResponse()
    {
        InitializeEndpoint();
        SendPostLoginUserRequest();
        SendPostUserRequest();
        ValidatePostUserOKResponse();
    }

    public void SendGetUserByIdRequestAndValidateResponse()
    {
        InitializeEndpoint();
        SendPostLoginUserRequest();
        SendPostUserRequest();
        ValidatePostUserOKResponse();
        SendGetUserById();
        ValidateGetUserByIdOKResponse();
    }

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


