using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using IO.Swagger.Client;
using IO.Swagger.Model;
using MobileClient.Models;
using MobileClient.Services;
using MobileClient.Views.MySurveys;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<MenuItemType, NavigationPage> MenuPages = new Dictionary<MenuItemType, NavigationPage>();

        public MenuItemType LastPage { get; set; }

        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add(MenuItemType.FillSurveys, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(MenuItemType id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuItemType.MySurveys:
                        MenuPages.Add(id, new NavigationPage(new MySurveysList()));
                        break;
                    case MenuItemType.MySurveyTemplates:
                        MenuPages.Add(id, new NavigationPage(new MySurveyTemplates()));
                        break;
                    case MenuItemType.FillSurveys:
                        MenuPages.Add(id, new NavigationPage(new SurveysToFillList()));
                        break;
                    case MenuItemType.MyResponses:
                        MenuPages.Add(id, new NavigationPage(new CompletedSurveysPage()));
                        break;
                    case MenuItemType.AllResponses:
                        MenuPages.Add(id, new NavigationPage(new AllResponses()));
                        break;
                    case MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            LastPage = id;

            if (id == MenuItemType.Logout)
            {
                SystemApi.Logout();
                Application.Current.MainPage = new AuthPage();
                return;
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;
                IsPresented = false;
            }
        }
    }
}