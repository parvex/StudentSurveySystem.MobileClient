using System;
using System.Windows.Input;
using MobileClient.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;
using Xamarin.Forms.Xaml;

namespace MobileClient.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MultiSelectDialog : ContentPage
    {
        public MultiSelectObservableCollection<string> ItemList { get; }

        public ICommand SelectedItemCommand { get; set; }

        public MultiSelectDialog(MultiSelectObservableCollection<string> itemList, ICommand selectedItemCommand)
        {
            InitializeComponent();
            ItemList = itemList;
            SelectedItemCommand = selectedItemCommand;
            BindingContext = this;
            DependencyService.Get<IKeyboardHelper>().HideKeyboard();

        }

        private void Clear_OnClicked(object sender, EventArgs e)
        {
            foreach (var item in ItemList)
            {
                item.IsSelected = false;
                SelectedItemCommand.Execute(null);
            }
        }

        private void SelectAll_OnClicked(object sender, EventArgs e)
        {
            foreach (var item in ItemList)
            {
                item.IsSelected = true;
                SelectedItemCommand.Execute(null);
            }
        }
    }
}