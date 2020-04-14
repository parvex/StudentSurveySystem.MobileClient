using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileClient.Models;
using MobileClient.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<MenuItemType, NavigationPage> MenuPages = new Dictionary<MenuItemType, NavigationPage>();
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
                        MenuPages.Add(id, new NavigationPage(new SurveyListPage()));
                        break;
                    case MenuItemType.FillSurveys:
                        MenuPages.Add(id, new NavigationPage(new SurveyListPage()));
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