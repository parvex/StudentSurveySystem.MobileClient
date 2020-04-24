using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MobileClient.Helpers;
using StudentSurveySystem.ApiClient.Api;
using StudentSurveySystem.ApiClient.Client;
using StudentSurveySystem.ApiClient.Model;


namespace MobileClient.Services
{
    public class SystemApi : ApiClient
    {
        private static Configuration ApiConfiguration;

        public static UsersApi UsersClient => new UsersApi(ApiConfiguration);
        public static SurveysApi SurveysClient => new SurveysApi(ApiConfiguration);
        public static SurveyResponsesApi SurveyResponsesClient => new SurveyResponsesApi(ApiConfiguration);


        static SystemApi()
        {
            ApiConfiguration = new Configuration(new Dictionary<string, string>(), 
                new Dictionary<string, string>(),
                new Dictionary<string, string>( ), 
                AppSettings.Settings["Service"]);

        }

        public static async Task<UsosAuthDto> GetUsosAuthData()
        {
            return await UsersClient.UsersUsosAuthDataGetAsync();
        }

        public static async Task<CurrentUserDto> Auth(string username, string password)
        {
            var result = await UsersClient.UsersAuthenticatePostAsync(new AuthenticateDto(username, password));
            ApiConfiguration.AddDefaultHeader("Authorization", "Bearer " + result.Token);
            UserHelper.User = result;
            return result;
        }

        public static async Task<CurrentUserDto> UsosAuth(UsosAuthDto usosAuthDto)
        {
            var result = await UsersClient.UsersUsosPinAuthPostAsync(usosAuthDto);
            ApiConfiguration.ApiKey["Authorization"] = result.Token;
            UserHelper.User = result;
            return result;
        }


        public static void Logout()
        {
            ApiConfiguration.ApiKey["Authorization"] = null;
            UserHelper.User = null;
        }
    }
}