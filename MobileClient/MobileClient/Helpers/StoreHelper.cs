using System.Linq;
using Xamarin.Auth;

namespace MobileClient.Helpers
{
    public class StoreHelper
    {
        public string Password
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
                return (account != null) ? account.Properties["Token"] : null;
            }
        }


        public void SaveCredentials(string token)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                Account account = new Account();
                account.Properties.Add("Token", token);
                AccountStore.Create().Save(account, App.AppName);
            }
        }

        public void DeleteCredentials()
        {
            var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create().Delete(account, App.AppName);
            }
        }
    }
}