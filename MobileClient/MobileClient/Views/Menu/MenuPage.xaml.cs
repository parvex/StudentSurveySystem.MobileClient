﻿using System.Collections.Generic;
using IO.Swagger.Model;
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

            menuItems.Add(new HomeMenuItem { Id = MenuItemType.FillSurveys, Title = "Fill surveys" });
            menuItems.Add(new HomeMenuItem { Id = MenuItemType.MyResponses, Title = "My responses" });

            if (UserHelper.User.UserRole == UserRole.Lecturer || UserHelper.User.UserRole == UserRole.Admin)
            {
                menuItems.Add(new HomeMenuItem { Id = MenuItemType.MySurveys, Title = "My surveys" });
            }

            if (UserHelper.User.UserRole == UserRole.Admin)
            {
                menuItems.Add(new HomeMenuItem{Id = MenuItemType.AllResponses, Title = "All responses"});
            }

            menuItems.Add(new HomeMenuItem { Id = MenuItemType.About, Title = "About" });
            menuItems.Add(new HomeMenuItem { Id = MenuItemType.Logout, Title = "Logout" });


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