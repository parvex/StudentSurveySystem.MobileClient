using System.Collections.Generic;
using IO.Swagger.Model;
using MobileClient.Extensions;
using MobileClient.Helpers;
using MobileClient.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>();

            menuItems.Add(new HomeMenuItem { Id = MenuItemType.FillSurveys, Title = "Fill surveys", IconSource = ImageHelper.GetImageFromResource("MobileClient.Resources.pen.png") });
            menuItems.Add(new HomeMenuItem { Id = MenuItemType.MyResponses, Title = "My responses", IconSource = ImageHelper.GetImageFromResource("MobileClient.Resources.response.png") });

            if (UserHelper.User.UserRole == UserRole.Lecturer || UserHelper.User.UserRole == UserRole.Admin)
            {
                menuItems.Add(new HomeMenuItem { Id = MenuItemType.MySurveyTemplates, Title = "My survey templates" , IconSource = ImageHelper.GetImageFromResource("MobileClient.Resources.template.png") });
                menuItems.Add(new HomeMenuItem { Id = MenuItemType.MySurveys, Title = "My surveys", IconSource = ImageHelper.GetImageFromResource("MobileClient.Resources.surveyicon.png") });
            }

            if (UserHelper.User.UserRole == UserRole.Admin)
            {
                menuItems.Add(new HomeMenuItem{Id = MenuItemType.AllResponses, Title = "All responses"});
            }

            menuItems.Add(new HomeMenuItem { Id = MenuItemType.UpdateUsosData, Title = "Get courses from USOS", IconSource = ImageHelper.GetImageFromResource("MobileClient.Resources.update.png") });
            menuItems.Add(new HomeMenuItem { Id = MenuItemType.About, Title = "About", IconSource = ImageHelper.GetImageFromResource("MobileClient.Resources.info.png") });
            menuItems.Add(new HomeMenuItem { Id = MenuItemType.Logout, Title = "Logout", IconSource = ImageHelper.GetImageFromResource("MobileClient.Resources.exit.png") });


            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = ((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}