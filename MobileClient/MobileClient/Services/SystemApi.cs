using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using MobileClient.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


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
            await UserHelper.SaveUser(result);
            return result;
        }

        public static async Task<CurrentUserDto> UsosAuth(UsosAuthDto usosAuthDto)
        {
            var result = await UsersClient.UsersUsosPinAuthPostAsync(usosAuthDto);
            ApiConfiguration.AddDefaultHeader("Authorization", "Bearer " + result.Token);
            UserHelper.User = result;
            await UserHelper.SaveUser(result);
            await UserHelper.UpdateCourseNotificationSubscribtions();
            return result; 
        }

        public static void AuthApi(string token)
        {
            ApiConfiguration.AddDefaultHeader("Authorization", "Bearer " + token);
        }

        public static void Logout()
        {
            ApiConfiguration.ApiKey["Authorization"] = null;
            UserHelper.User = null;
        }

        public static void HandleException(ApiException exception)
        {
            if (exception.ErrorCode == 400)
            {
                var content = JObject.Parse(exception.ErrorContent.ToString());

                var x = content["errors"];
                Dictionary<string, List<string>> errorDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(content["errors"].ToString());
                var stringBuild = new StringBuilder("Validation errors:\n");
                foreach (var errorList in errorDictionary)
                {
                    foreach (var error in errorList.Value)
                    {
                        stringBuild.Append(error + "\n");
                    }
                }
                UserDialogs.Instance.Toast(stringBuild.ToString());

            }
        }
    }
}