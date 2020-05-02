using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Acr.UserDialogs;
using MobileClient.Controllers;
using MobileClient.Models;
using MobileClient.Services;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.MySurveys
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MySurveysList : ContentPage
    {
        public ListViewController<SurveyDto> ListViewController;

        public MySurveysList()
        {
            InitializeComponent();
            ListViewController = new ListViewController<SurveyDto>(SystemApi.SurveysClient.SurveysMySurveysGetAsync, ListView, SearchBar);
            BindingContext = this;
        }
    }
}