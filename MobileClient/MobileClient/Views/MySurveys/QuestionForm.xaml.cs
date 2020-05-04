using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private QuestionDto Question { get; set; }
        public List<string> QuestionTypes { get; } = Enum.GetNames(typeof(QuestionType)).Select(b => b.SplitCamelCase()).ToList();

        public QuestionType SelectedType { get; set; }

        public QuestionForm(QuestionDto question)
        {
            InitializeComponent();
            Question = new QuestionDto();
        }
    }
}