using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Model;
using MobileClient.Services;
using Newtonsoft.Json;
using Xamarin.Auth;
using Xamarin.Essentials;
namespace MobileClient.Helpers
{
    public static class UserHelper
    {
        public static CurrentUserDto User { get; set; }

        public static async Task SaveUser(CurrentUserDto user)
        {
            if (user == null) return;
            var account = new Account()
            {
                Username = user.Username,
                Properties =
                {
                    {"Id", user.Id.ToString()},
                    {"FirstName", user.FirstName},
                    {"LastName", user.LastName},
                    {"Username", user.Username},
                    {"UserRole", user.UserRole.ToString()},
                    {"Token", user.Token},
                    {"TokenExpirationDate", user.TokenExpirationDate.ToString()}
                }
            };
            await SaveAsync(account);
        }

        public static async Task<CurrentUserDto> GetUser()
        {
            var account = await FindAccountForServiceAsync();
            if (account == null) return null;
            var user = new CurrentUserDto()
            {
                Id = int.Parse(account.Properties["Id"]),
                FirstName = account.Properties["FirstName"],
                LastName = account.Properties["LastName"],
                Username = account.Properties["Username"],
                UserRole = Enum.Parse<UserRole>(account.Properties["UserRole"]),
                Token = account.Properties["Token"],
                TokenExpirationDate = DateTime.Parse(account.Properties["TokenExpirationDate"])
            };

            return user;
        }

        public static async Task<bool> AutoLogin()
        {
            var user = await GetUser();
            if (user == null || user.TokenExpirationDate < DateTime.Now) return false;
            User = user;
            SystemApi.AuthApi(user.Token);
            return true;
        }

        private static async Task SaveAsync(Account account)
        {
            var accounts = await FindAccountsForServiceAsync();
            accounts.RemoveAll(a => a.Username == account.Username);
            accounts.Add(account);
            var json = JsonConvert.SerializeObject(accounts);
            await SecureStorage.SetAsync(App.AppName, json);
        }

        private static async Task<List<Account>> FindAccountsForServiceAsync()
        {
            var json = await SecureStorage.GetAsync(App.AppName);
            if (json == null) return new List<Account>();
            try
            {
                return JsonConvert.DeserializeObject<List<Account>>(json);
            }
            catch { }
            return new List<Account>();
        }

        public static async Task<Account> FindAccountForServiceAsync()
        {
            var accounts = await FindAccountsForServiceAsync();
            return accounts.FirstOrDefault();
        }

        public static async Task Logout()
        {
            var accounts = await FindAccountsForServiceAsync();
            accounts.RemoveAll(a => a.Username == User.Username);
            User = null;
            SystemApi.Logout();
        }
    }
}