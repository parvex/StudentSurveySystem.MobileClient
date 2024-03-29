﻿using System;
using Acr.UserDialogs;
using IO.Swagger.Client;
using IO.Swagger.Model;
using MobileClient.Helpers;
using MobileClient.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        public UsosAuthDto usosAuth;
        public bool UpdateUsosData { get; set; }

        public bool Busy { get; set; }

        public AuthPage(bool updateUsosData = false)
        {
            UpdateUsosData = updateUsosData;
            InitializeComponent();
            BindingContext = this;
        }


        private async void Button_UsosAuth(object sender, EventArgs e)
        {
            using (UserDialogs.Instance.Loading("Loading"))
            {
                usosAuth = await SystemApi.GetUsosAuthData();
                await Launcher.OpenAsync(new Uri(usosAuth.UsosAuthUrl));
            }

            UsosPin.IsVisible = true;
            ConfirmPinButton.IsVisible = true;
        }

        public async void UsosLogin(string oAuthVerifier)
        {
            UsosPin.Text = oAuthVerifier;

            using (UserDialogs.Instance.Loading("Loading"))
            {
                usosAuth.OAuthVerifier = oAuthVerifier;
                try
                {
                    var result = await SystemApi.UsosAuth(usosAuth);
                    if (UpdateUsosData)
                    {
                        await SystemApi.UsersClient.UsersUpdateUserUsosDataPutAsync();
                        await UserHelper.UpdateCourseNotificationSubscribtions();
                        UserDialogs.Instance.Toast("Usos data updated!");
                    }
                    Application.Current.MainPage = new MainPage();
                }
                catch (ApiException e)
                {
                    Console.WriteLine(e);
                    AuthErrorLabel.IsVisible = true;
                }
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        //private async void Button_Login(object sender, EventArgs e)
        //{
        //    using (UserDialogs.Instance.Loading("Loading"))
        //    {
        //        try
        //        {
        //            var result = await SystemApi.Auth(Username.Text, Password.Text);
        //            Application.Current.MainPage = new MainPage();
        //        }
        //        catch (ApiException exception)
        //        {
        //            AuthErrorLabel.IsVisible = true;
        //            Console.WriteLine(exception);
        //        }
        //    }
        //}

        private async void Button_UsosPinAuth(object sender, EventArgs e)
        {
            var oAuthVerifier = UsosPin.Text;
            using (UserDialogs.Instance.Loading("Loading"))
            {
                usosAuth.OAuthVerifier = oAuthVerifier;
                try
                {
                    var result = await SystemApi.UsosAuth(usosAuth);
                    Application.Current.MainPage = new MainPage();

                }
                catch (ApiException exception)
                {
                    Console.WriteLine(exception);
                    AuthErrorLabel.IsVisible = true;
                }
            }
        }
    }
}