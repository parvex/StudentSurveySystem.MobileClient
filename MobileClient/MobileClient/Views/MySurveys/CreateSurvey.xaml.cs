using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Survey;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateSurvey : ContentPage
    {
        private SurveyDto Survey;

        public CreateSurvey()
        {
            InitializeComponent();
        }
    }
}