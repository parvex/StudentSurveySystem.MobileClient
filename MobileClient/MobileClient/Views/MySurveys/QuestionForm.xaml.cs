using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Force.DeepCloner;
using MobileClient.Controllers;
using MobileClient.Extensions;
using StudentSurveySystem.ApiClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.MySurveys
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionForm : ContentPage
    {
        public QuestionForm(ObservableCollection<QuestionDto> questionList)
        {
            InitializeComponent();
            BindingContext = new QuestionViewModel(questionList);
        }

        public QuestionForm(QuestionDto question, ObservableCollection<QuestionDto> questionList)
        {
            InitializeComponent();
            BindingContext = new QuestionViewModel(question ,questionList);
        }

        private void Submit_OnClicked(object sender, EventArgs e)
        {
            if(((QuestionViewModel) BindingContext).Submit())
                Navigation.PopAsync();
        }
    }
}