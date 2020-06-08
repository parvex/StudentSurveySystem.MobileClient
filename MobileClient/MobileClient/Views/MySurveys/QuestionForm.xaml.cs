using System;
using System.Collections.ObjectModel;
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
            string result = await DisplayPromptAsync("Add value", "Type new value:");
            if(!string.IsNullOrEmpty(result))
                QuestionViewModel.AddOrUpdateValue(result);
        }

        private async void ValuesListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            string result = await DisplayPromptAsync("Change value", "Type new value:");
            if (!string.IsNullOrEmpty(result))
                QuestionViewModel.AddOrUpdateValue(result, e.ItemIndex);
        }
    }
}