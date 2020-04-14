using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Auth;
using Core.Models.Survey;
using Core.Models.SurveyResponse;
using MobileClient.Helpers;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.NewtonsoftJson;

namespace MobileClient.Services
{
    public class SystemApi
    {
        private static readonly IRestClient Client;

        static SystemApi()
        {
            Client = new RestClient(AppSettings.Settings["Service"]);
            Client.UseNewtonsoftJson();
            //todo: for dev purposes only - remove ssl validation
            Client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }

        public static async Task<CurrentUserDto> Authenticate(string username, string password)
        {
            var request = new RestRequest("users/authenticate", Method.POST);
            request.AddJsonBody(new {Username = username, Password = password});

            var result = await Client.ExecuteAsync<CurrentUserDto>(request);
            if (result.IsSuccessful)
            {
                Client.Authenticator = new JwtAuthenticator(result.Data.Token);
                UserHelper.User = result.Data;
                return result.Data;
            }
            else
            {
                return null;
            }
        }

        public static void Logout()
        {
            Client.Authenticator = null;
            UserHelper.User = null;
        }

        public static async  Task<List<SurveyDto>> GetUserSurveysToBeFilled()
        {
            var request = new RestRequest("surveys/usertobefilled", Method.GET);
            return await Execute<List<SurveyDto>>(request);
        }

        public static async Task<List<SurveyDto>> GetUserSurveysFilled()
        {
            var request = new RestRequest("surveys/userfilled", Method.GET);
            return await Execute<List<SurveyDto>>(request);
        }

        public static async Task<SurveyDto> PostSurveyResponse(SurveyResponseDto surveyResponse)
        {
            var request = new RestRequest("surveyresponses", Method.POST);
            request.AddJsonBody(surveyResponse);

            return await Execute<SurveyDto>(request);
        }

        public static async Task<UsosAuthDto> GetUsosAuthData()
        {
            var request = new RestRequest("users/usosauthdata", Method.GET);

            return await Execute<UsosAuthDto>(request);
        }
        
        public static async Task<CurrentUserDto> UsosPinAuth(UsosAuthDto usosAuth)
        {
            var request = new RestRequest("users/usospinauth", Method.POST);
            request.AddJsonBody(usosAuth);
            var result = await Client.ExecuteAsync<CurrentUserDto>(request);
            if (result.IsSuccessful)
            {
                Client.Authenticator = new JwtAuthenticator(result.Data.Token);
                UserHelper.User = result.Data;
                return result.Data;
            }
            else
            {
                return null;
            }
        }

        public static async Task<SurveyDto> GetSurvey(int id)
        {
            var request = new RestRequest("surveys/" + id, Method.GET);
            return await Execute<SurveyDto>(request);
        }

        public static async Task<List<SurveyResponseDetailsDto>> GetUserSurveyResponses()
        {
            var request = new RestRequest("surveyresponses/userfilled", Method.GET);
            return await Execute<List<SurveyResponseDetailsDto>>(request);
        }

        public static async Task<List<SurveyResponseDetailsDto>> GetSurveyResponses()
        {
            var request = new RestRequest("surveyresponses", Method.GET);
            return await Execute<List<SurveyResponseDetailsDto>>(request);
        }

        public static async Task<SurveyResponseDto> GetSurveyResponseDto(int id)
        {
            var request = new RestRequest("surveyresponses/" + id, Method.GET);
            return await Execute<SurveyResponseDto>(request);
        }

        private static async Task<T> Execute<T>(RestRequest request)
        {
            var response = await Client.ExecuteAsync<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var exception = new Exception(message, response.ErrorException);
                throw exception;
            }
            return response.Data;
        }
    }
}