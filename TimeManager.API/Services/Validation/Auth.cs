using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using Newtonsoft.Json;
using System.Text;
using RestSharp;
using Microsoft.AspNetCore.Mvc;

namespace TimeManager.API.Services.Validation
{
    public static class Auth
    {

        public static bool IsAuth(Token token)
        {            
            string endpoint = "http://timemanager.idp:8080/api/Auth/IsAuth/isauth";
            var client = new RestClient(endpoint);
            var request = new RestRequest();

            request.AddJsonBody(token);
            Response<bool> result = client.Post<Response<bool>>(request);
            return result.Data;
        }

    }

}
