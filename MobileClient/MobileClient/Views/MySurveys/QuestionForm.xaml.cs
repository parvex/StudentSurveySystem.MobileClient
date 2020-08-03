using System;
using System.Collections.ObjectModel;
using Acr.UserDialogs;
using IO.Swagger.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.MySurveys
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionForm : ContentPage
    {
        public QuestionViewModel QuestionViewModel => (QuestionViewModel) BindingContext;

        public QuestionForm(ObservableCollection<QuestionModel> questionList)
        {
            InitializeComponent();
            BindingContext = new QuestionViewModel(questionList);
        }

        public QuestionForm(QuestionModel question, ObservableCollection<QuestionModel> questionList)
        {
            InitializeComponent();
            BindingContext = new QuestionViewModel(question ,questionList);
        }

        private void Submit_OnClicked(object sender, EventArgs e)
        {
            if(((QuestionViewModel) BindingContext).Submit())
                Navigation.PopAsync();
        }

        private async void AddValue_OnClicked(object sender, EventArgs e)
        { 
            var selectText = await DisplayPromptAsync("Add select option", "Type new select text:");
            var questionType = QuestionViewModel.QuestionType;
            PromptResult selectValue = new PromptResult(false, "");
            if (questionType == QuestionType.ValuedSingleSelect)
            {
                selectValue = await UserDialogs.Instance.PromptAsync(new PromptConfig()
                {
                    Title = "Add select option",
                    Message = "Type select value",
                    InputType = InputType.DecimalNumber
                });
            }

            double selValueDouble = 0;
            if(!string.IsNullOrEmpty(selectText) && (questionType != QuestionType.ValuedSingleSelect || double.TryParse(selectValue.Text, out selValueDouble)))
                QuestionViewModel.AddOrUpdateValue(selectText, selValueDouble);
        }

        private async void ValuesListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            string result = await DisplayPromptAsync("Change value", "Type new value:");

            var questionType = QuestionViewModel.QuestionType;
            PromptResult selectValue = new PromptResult(false, "");
            if (questionType == QuestionType.ValuedSingleSelect)
            {
                selectValue = await UserDialogs.Instance.PromptAsync(new PromptConfig()
                {
                    Title = "Add select option",
                    Message = "Type select value",
                    InputType = InputType.DecimalNumber
                });
            }
            double selValueDouble = 0;
            if (!string.IsNullOrEmpty(result) && (questionType != QuestionType.ValuedSingleSelect || double.TryParse(selectValue.Text, out selValueDouble)))
                QuestionViewModel.AddOrUpdateValue(result, selValueDouble, e.ItemIndex);
        }
    }
}