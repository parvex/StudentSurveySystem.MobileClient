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
        public QuestionForm(ObservableCollection<QuestioDtoModel> questionList)
        {
            InitializeComponent();
            BindingContext = new QuestionViewModel(questionList);
        }

        public QuestionForm(QuestioDtoModel question, ObservableCollection<QuestioDtoModel> questionList)
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