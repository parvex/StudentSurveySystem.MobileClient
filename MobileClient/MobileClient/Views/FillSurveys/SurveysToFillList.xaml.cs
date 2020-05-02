using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Acr.UserDialogs;
using MobileClient.Controllers;
using MobileClient.Models;
using MobileClient.Services;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Extended;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SurveysToFillList : ContentPage
    {
        public ListViewController<SurveyDto> ListViewController { get; set; }

        public SurveysToFillList()
        {
            InitializeComponent();
            BindingContext = this;
            ListViewController = new ListViewController<SurveyDto>(SystemApi.SurveysClient.SurveysMyNotFilledFormGetAsync, ListView, SearchBar);
        }
    }
}