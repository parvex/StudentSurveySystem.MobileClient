using System;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;
using Xamarin.Forms.Xaml;

namespace MobileClient.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MultiSelectDialog : ContentPage
    {
        public MultiSelectObservableCollection<string> ItemList { get; }
        public MultiSelectObservableCollection<string> PickedItems { get; }


        public MultiSelectDialog()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public MultiSelectDialog(MultiSelectObservableCollection<string> itemList, MultiSelectObservableCollection<string> pickedItems)
        {
            ItemList = itemList;
            PickedItems = pickedItems;
        }

        private void Submit_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}